using System.Linq;
using System.Threading.Tasks;
using MicroservicesTutorial.IdentityServer.Dtos;
using MicroservicesTutorial.IdentityServer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MicroservicesTutorial.IdentityServer.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignupDto model)
        {
            var user = new ApplicationUser()
            {
                UserName = model.UserName,
                Email = model.Email,
                City = model.City
            };

            var result =await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                //TODO replace with shared response
                return BadRequest(result.Errors.Select(x=>x.Description).ToList());
            }
    
            //TODO replace with shared response
            return Ok();
        }
    }
}