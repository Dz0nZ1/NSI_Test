using Riok.Mapperly.Abstractions;
using Test.Application.Common.Dto.Product;
using Test.Domain.Entities;

namespace Test.Application.Common.Mappers;

[Mapper]
public static partial class ProductMapper
{
    public static partial ProductDetailsDto ToDto(this Product entity);

    public static partial IList<ProductDetailsDto> ToListDto(this List<Product> entities);

    public static Product ToCustomDto(this ProductCreateDto dto, Company company)
    {
        var product = new Product(Guid.NewGuid(), dto.Name, dto.Description, company);
        return product;
    }





}
