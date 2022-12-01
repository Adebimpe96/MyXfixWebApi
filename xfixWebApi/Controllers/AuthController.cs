using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using xfixWebApi.Models;
using xfixWebApi.Models.ViewModels;

namespace xfixWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }




        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterCustomer customer)
        {
            if (ModelState.IsValid)
            {
                var user  = new ApplicationUser { 
                    UserName = customer.Email,
                    FullName = customer.FullName,
                    Email = customer.Email,
                    PhoneNumber = customer.PhoneNo,
                    HouseAddress = customer.HouseAddress                                        
                };

                var result = await _userManager.CreateAsync(user, customer.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Customer");

                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("RegisterArtisan")]
        public async Task<IActionResult> RegisterArtisan(RegisterArtisan artisan)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = artisan.Email,
                    FullName = artisan.FullName,
                    Email = artisan.Email,
                    PhoneNumber = artisan.PhoneNo,
                    HouseAddress = artisan.HouseAddress
                };

                var result = await _userManager.CreateAsync(user, artisan.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Artisan");

                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest();
            }
     }

        //Login Method
        [HttpPost("Login")]
        public async Task<IActionResult>Login(LoginModel login)
        {
            if (ModelState.IsValid)
            {
                var userExist = await _userManager.FindByEmailAsync(login.Email);

                if (userExist == null)
                {
                    ModelState.AddModelError("Invalid", "Invalid Credentials");
                    return BadRequest(ModelState);
                }

                var result = await _signInManager.PasswordSignInAsync(login.Email, login.Password, false, false);
                if (result.Succeeded)
                {
                    return Ok(result);
                }
            }
            ModelState.AddModelError("Invalid", "Invalid login attempt.");
            return BadRequest();
        }
    }
}

