using System.ComponentModel.DataAnnotations;

namespace xfixWebApi.Models.ViewModels
{
    public class RegisterCustomer
    {
        [Required, MaxLength(50)]
        public string FullName { get; set; }
        [Required, MaxLength(15)]
        public string PhoneNo { get; set; }
        [Required, MaxLength(30)]
        public string Email { get; set; }
        [Required, MaxLength(20)]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }

        [Required]
        public string HouseAddress { get; set; }
    }
}
