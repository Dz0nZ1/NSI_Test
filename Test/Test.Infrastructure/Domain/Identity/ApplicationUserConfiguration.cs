using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test.Domain.Entities;

namespace Test.Infrastructure.Domain.Identity;

public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{

    private const string AdminId = "4DAF65CB-CC0E-4C81-9183-20097EA81F5A";
    
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {

        builder.ToTable("Users");


        var admin = new ApplicationUser
        {
            Id = AdminId,
            UserName = "nikola@email.com",
            NormalizedUserName = "NIKOLA@email.com",
            Email = "nikola@email.com",
            NormalizedEmail = "NIKOLA@email.com",
            EmailConfirmed = true,
            PhoneNumberConfirmed = true,
            SecurityStamp = new Guid().ToString("D"),
            FirstName = "Nikola",
            LastName = "Lelekovic",
            ConcurrencyStamp = "c188a435-cfc8-45fd-836c-9a18bb9de405",
            AccessFailedCount = 0
        };

        builder.HasData(admin);
        

        builder.HasMany(x => x.Roles)
               .WithOne()
               .HasForeignKey(x => x.UserId)
               .IsRequired()
               .OnDelete(DeleteBehavior.Cascade);


    }
}