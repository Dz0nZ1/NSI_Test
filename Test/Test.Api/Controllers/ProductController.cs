using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test.Application.Common.Dto.Product;
using Test.Application.Common.Interfaces;
using Test.Application.Common.Mappers;
using Test.Application.Product.Queries;

namespace Test.Api.Controllers;


public class ProductController(ITestDbContext dbContext) : ApiBaseController
{
    

    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
       var result = await dbContext.Products.Include(c => c.Company).ToListAsync();
       return Ok(result.ToListDto());
    }

    [HttpGet]
    public async Task<IActionResult> Details([FromQuery] ProductDetailsQuery query) => Ok(await Mediator.Send(query));
  

    [HttpPost]
    public async Task<IActionResult> Create(ProductCreateDto productDto)
    {
        var company = await dbContext.Companies.Where(x => x.Id.Equals(productDto.CompanyId)).FirstOrDefaultAsync();
        
        if (company == null) return BadRequest();
        var product = productDto.ToCustomDto(company);
        
        await dbContext.Products.AddAsync(product);
        await dbContext.SaveChangesAsync(new CancellationToken());
        
        return Ok("Product has been created");
    }


}