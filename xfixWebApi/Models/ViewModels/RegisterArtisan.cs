using System.ComponentModel.DataAnnotations;

namespace xfixWebApi.Models.ViewModels
{
    public class RegisterArtisan
    {
        [Required]
        public string FullName { get; set; }

        [Required]
        public string PhoneNo { get; set; }

        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        [Required]
        public string ConfirmPassword { get; set; }

        [Required]
        public string HouseAddress { get; set; }

        
    };
}
