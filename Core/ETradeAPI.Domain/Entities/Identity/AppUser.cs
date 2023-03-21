using Microsoft.AspNetCore.Identity;

namespace ETradeAPI.Domain.Entities.Identity
{
    public class AppUser : IdentityUser<string>
    {
        public string NameSurname { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenEndDate { get; set; }
        public ICollection<Basket> Baskets { get; set; } // Each user can have "n" baskets
    }
}
