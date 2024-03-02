using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test.Domain.Entities;

namespace Test.Infrastructure.Domain.Identity;

public class ApplicationRoleConfiguration : IEntityTypeConfiguration<ApplicationRole>
{

    private const string AdminId = "40FEB7B4-B530-4EA2-B96F-582D88277E4B";
    private const string StudentServiceId = "34DE6D7C-4270-425B-987F-8D2CC41CD857";
    private const string  TeacherId = "A40CBDF3-70EF-4BC2-B035-2BE930154EB6";
    
    
    public void Configure(EntityTypeBuilder<ApplicationRole> builder)
    {
        builder.ToTable("Roles");
        builder.HasData(

            new ApplicationRole
            {
                Id = AdminId,
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR",
                ConcurrencyStamp = "a09ab67f-02d6-4910-8659-3385759d8036"
            },
            new ApplicationRole()
            {
                Id = StudentServiceId,
                Name = "StudentService",
                NormalizedName = "STUDENTSERVICE",
                ConcurrencyStamp = "a09ab67f-02d6-4910-8659-3385759d8037"
            },
            new ApplicationRole()
            {
                Id = TeacherId,
                Name = "Teacher",
                NormalizedName = "DELIVERYCOMPANY",
                ConcurrencyStamp = "a09ab67f-02d6-4910-8659-3385759d8038"
            }

        );
    }
}