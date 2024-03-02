namespace Test.Application.Common.Dto.Company;

public record CompanyDetailsDto(string Name, string Description, IList<Domain.Entities.Product> Products);