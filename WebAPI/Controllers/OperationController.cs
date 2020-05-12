using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationController : ControllerBase
    {
        public OperationController(AuthenticationContext context)
        {
        }

        [HttpPost]
        [Route("AutoExpertise")]
        public void Post([FromBody] CarInfo info)
        {
        }
    }
}
