using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;

namespace FerramentaAPI.Controllers
{
    [ApiController]
    [Route("api/Ferramentas")]
    public class FerramentasController : Controller
    {
        [HttpGet]
        public IActionResult Get() => Ok("Testando");
        
        
    }
}
