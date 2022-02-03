using DocumentMono.API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DocumentMono.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        [Route("login")]
        [HttpPost]
        public async Task<ActionResult> LoginAsync([FromBody] LoginRequestModel model) {
            if (!ModelState.IsValid)
            {
                var message = string.Join(" | ", ModelState.Values
                                .SelectMany(v => v.Errors)
                                .Select(e => e.ErrorMessage));
                return Unauthorized(message);
            }
            return Ok(model);
        }
    }
}
