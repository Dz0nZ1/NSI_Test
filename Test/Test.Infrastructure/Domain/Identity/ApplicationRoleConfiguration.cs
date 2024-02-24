using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test.Domain.Entities;

namespace Test.Infrastructure.Domain.Identity;

public class ApplicationRoleConfiguration : IEntityTypeConfiguration<ApplicationRole>
{

    private const string AdminId = "40FEB7B4-B530-4EA2-B96F-582D88277E4B";
    private const string StudentServiceId = "2fc770ab-3846-4496-97c2-f6b197d81c87";
    private const string  TeacherId = "32974250-4c5f-42a6-a3d7-1b45e7d0862b";
    
    
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
                NormalizedName = "EMPLOYEE",
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