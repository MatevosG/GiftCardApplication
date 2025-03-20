using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GiftCard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        public int ClientId => Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
    }
}
