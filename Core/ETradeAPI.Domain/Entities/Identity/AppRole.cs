using ETicaretAPI.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace ETradeAPI.Domain.Entities.Identity
{
    public class AppRole : IdentityRole<string>
    {
        public ICollection<Endpoint> Endpoints { get; set; }
    }
}
