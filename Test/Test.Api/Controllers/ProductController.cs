using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test.Application.Common.Dto.Product;
using Test.Application.Common.Interfaces;
using Test.Application.Common.Mappers;
using Test.Application.Product.Commands;
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
    public async Task<IActionResult> CreateProductMediator(ProductCreateCommand command) => Ok(await Mediator.Send(command));


    // [HttpPost]
    // public async Task<IActionResult> CreateProduct(TestProductCreateDto product)
    // {
    //   var myApi = RestService.For<ITestApi>("http://localhost:5032");  
    //   var result = MyApi.CreateProductAsync(new DemoProductRequestDto(product));
    //   return Ok()
    // }

}