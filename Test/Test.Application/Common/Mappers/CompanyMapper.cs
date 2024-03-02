using Riok.Mapperly.Abstractions;
using Test.Application.Common.Dto.Company;
using Test.Domain.Entities;

namespace Test.Application.Common.Mappers;

[Mapper]
public static partial class CompanyMapper
{
    public static partial CompanyDetailsDto ToDto(this Company entity);
    
    public static partial IList<CompanyDetailsDto> ToListCompanyDto(this List<Company> entity);

    public static Company ToEntity(this CompanyCreateDto dto)
    {
        return new Company(Guid.NewGuid(), dto.Name, dto.Description);
    }

}