using Microsoft.AspNetCore.Mvc;
using WebAPI.Component;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        [HttpGet]
        public UserModel GetUserProfile(string username)
        {
            return UserComponent.GetUser(username);
        }

        [HttpPost]
        [Route("AutoExpertise")]
        public CarResponse AutoExpertise([FromBody] CarInfo car)
        {
            return AutoComponent.GetAutoExpert(car);
        }
    }
}