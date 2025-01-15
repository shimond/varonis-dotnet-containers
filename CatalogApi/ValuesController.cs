using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CatalogApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        public ActionResult<int> GET()
        {

            return Ok("312321");
        }
    }
}
