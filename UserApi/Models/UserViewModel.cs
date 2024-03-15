using Microsoft.AspNetCore.Identity;

namespace UserApi.Models;

public class UserViewModel : IdentityUser
{
    public DateTime DateBirth { get; set; }

    public UserViewModel() : base() { }
}
