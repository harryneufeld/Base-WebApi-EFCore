using Microsoft.AspNetCore.Mvc;

namespace Backend.Service.Controller
{
    [ApiController]
    [Route("v{version:apiVersion}/[controller]")]
    public abstract class BaseApiController : ControllerBase
    {

    }
}