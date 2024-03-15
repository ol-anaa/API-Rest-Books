using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UserApi.Models;

namespace UserApi.Data;

public class UserDbContext : IdentityDbContext<UserViewModel>
{
    public UserDbContext(DbContextOptions<UserDbContext> opts) : base(opts)
    {
        
    }
}
