using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Test.Infrastructure.Domain.Company;

public class CompanyConfiguration : IEntityTypeConfiguration<Test.Domain.Entities.Company>
{
    public void Configure(EntityTypeBuilder<Test.Domain.Entities.Company> builder)
    {
        builder.ToTable("Companies");
        builder.Property(x => x.Id).ValueGeneratedNever();

    }
}