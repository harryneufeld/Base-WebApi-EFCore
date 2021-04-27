using Microsoft.AspNetCore.Mvc;

namespace Backend.Service.Controller
{
    [Produces("application/json")]
    [ApiController]
    [Route("v{version:apiVersion}/[controller]")]
    public abstract class BaseApiController : ControllerBase
    {

    }
}