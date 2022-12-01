using Microsoft.AspNetCore.Identity;

namespace xfixWebApi.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string FullName { get; set; } = null!; 
        public string HouseAddress { get; set; }        
        public Location? Location { get; set; }
       
    }
}
