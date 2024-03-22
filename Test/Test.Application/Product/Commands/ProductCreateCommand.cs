using MediatR;
using Microsoft.EntityFrameworkCore;
using Test.Application.Common.Dto.Product;
using Test.Application.Common.Exceptions;
using Test.Application.Common.Interfaces;
using Test.Application.Common.Mappers;

namespace Test.Application.Product.Commands;

public record ProductCreateCommand(ProductCreateDto Product) : IRequest<ProductDetailsDto?>;

public class ProductCreateCommandHandler(ITestDbContext dbContext) : IRequestHandler<ProductCreateCommand, ProductDetailsDto?>
{
    public async Task<ProductDetailsDto?> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
    {
        var company = await dbContext.Companies.Where(x => x.Id.Equals(request.Product.CompanyId))
            .FirstOrDefaultAsync(cancellationToken: cancellationToken) ?? throw new NotFoundException("Company not found");

        var product = request.Product.FromCreateDtoToEntity().AddCompany(company);
        
        await dbContext.Products.AddAsync(product,
            cancellationToken: cancellationToken);

        return product.ToDto();
    }
}