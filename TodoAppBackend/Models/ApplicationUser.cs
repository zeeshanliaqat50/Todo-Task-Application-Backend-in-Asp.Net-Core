using Microsoft.AspNetCore.Identity;
using TodoAppBackend.Data;

namespace TodoAppBackend.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string firstName { get; set; } = "";
        public string lastName { get; set; } = "";

        public ICollection<Data.Tasks> tasks { get; set; }


    }
}
