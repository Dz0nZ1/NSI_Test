using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test.Application.Common.Dto.Company;
using Test.Application.Common.Interfaces;
using Test.Application.Common.Mappers;
using Test.Domain.Entities;

namespace Test.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CompanyController(ITestDbContext dbContext) : ControllerBase
{

    [HttpGet("GetAllCompanies")]
    public async Task<IActionResult> GetAllCompanies()
    {
        var companies = await dbContext.Companies.Include(p => p.Products).ToListAsync();
        var dto = companies.ToListCompanyDto();
        return Ok(dto);
    }
    
    
    [HttpGet("details")]
    public async Task<IActionResult> Details(string id)
    {
        var result = await dbContext.Companies.Include(x => x.Products)
            .Where(x => x.Id.ToString().Equals(id)).FirstOrDefaultAsync();
        if (result is null) return BadRequest();
        return Ok(result.ToDto());
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create(CompanyCreateDto companyCreateDto)
    {
        var company = companyCreateDto.ToEntity();
        await dbContext.Companies.AddAsync(company);
        await dbContext.SaveChangesAsync(new CancellationToken());
        return Ok("Company has been created");
    }
}