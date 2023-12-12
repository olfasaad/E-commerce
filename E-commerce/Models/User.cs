using Microsoft.AspNetCore.Identity;

namespace E_commerce.Models
{
    public class User :IdentityUser
    {
        public string Fullname { get; set; }
    }
}
