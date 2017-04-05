using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeekWeb.Data;
using System.Threading.Tasks;

namespace promoengine.Api
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class AdsController : Controller
    {
        private readonly PromotionEngineContext _context;
        public AdsController(PromotionEngineContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Produces(typeof(string[]))]
        public async Task<IActionResult> Get()
        {
            return Ok(await _context.Ads.ToListAsync());
        }
    }
}
