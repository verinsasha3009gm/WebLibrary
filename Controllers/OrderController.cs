using Microsoft.AspNetCore.Mvc;

namespace WebLibrary.API.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class OrderController : ControllerBase
    {
    }
}
