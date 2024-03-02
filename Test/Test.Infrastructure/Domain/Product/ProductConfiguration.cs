using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Test.Infrastructure.Domain.Product;

public class ProductConfiguration : IEntityTypeConfiguration<Test.Domain.Entities.Product>
{
    public void Configure(EntityTypeBuilder<Test.Domain.Entities.Product> builder)
    {
        builder.ToTable("Products");

        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.Property<Guid>("CompanyId");
        builder.HasIndex("CompanyId");
        
        builder
            .HasOne(c => c.Company)
            .WithMany(p => p.Products)
            .HasForeignKey("CompanyId")
            .IsRequired();
    }
}