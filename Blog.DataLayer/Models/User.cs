using Microsoft.AspNetCore.Identity;

namespace Blog.DataLayer.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
    }
}
