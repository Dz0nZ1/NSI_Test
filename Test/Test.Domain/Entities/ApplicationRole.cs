using Microsoft.AspNetCore.Identity;

namespace Test.Domain.Entities;

public class ApplicationRole : IdentityRole
{
    public IList<ApplicationUserRole> UserRoles { get; set; }
}