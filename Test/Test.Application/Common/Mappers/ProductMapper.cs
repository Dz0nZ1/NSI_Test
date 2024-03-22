using Riok.Mapperly.Abstractions;
using Test.Application.Common.Dto.Product;
using Test.Domain.Entities;

namespace Test.Application.Common.Mappers;

[Mapper]
public static partial class ProductMapper
{
    public static partial ProductDetailsDto ToDto(this Domain.Entities.Product entity);

    public static partial IList<ProductDetailsDto> ToListDto(this List<Domain.Entities.Product> entities);

    public static Domain.Entities.Product FromCreateDtoToEntity(this ProductCreateDto dto)
    {
        var product = new Domain.Entities.Product(dto.Name, dto.Description);
        return product;
    }





}
