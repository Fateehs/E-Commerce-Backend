using Microsoft.AspNetCore.Identity;

namespace ETradeAPI.Domain.Entities.Identity
{
    public class AppUser : IdentityUser<string>
    {
        public string NameSurname { get; set; }
    }
}
