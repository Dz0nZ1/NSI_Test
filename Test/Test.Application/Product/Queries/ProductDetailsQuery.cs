using System.Diagnostics;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Test.Application.Common.Dto.Product;
using Test.Application.Common.Interfaces;
using Test.Application.Common.Mappers;

namespace Test.Application.Product.Queries;

public record ProductDetailsQuery(string Id) : IRequest<ProductDetailsDto?>;


public class ProductDetailsQueryHandler(ITestDbContext dbContext) : IRequestHandler<ProductDetailsQuery, ProductDetailsDto?>
{
    public async Task<ProductDetailsDto?> Handle(ProductDetailsQuery request, CancellationToken cancellationToken)
    {
        var product = await dbContext.Products.Include(c => c.Company)
            .Where(x => x.Id.Equals(Guid.Parse(request.Id))).FirstOrDefaultAsync(cancellationToken: cancellationToken);
        return product?.ToDto();
    }
}