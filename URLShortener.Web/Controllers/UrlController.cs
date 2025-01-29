using Microsoft.AspNetCore.Mvc;
using URLShortener.BusinessLogic.Services.Interfaces;

namespace URLShortener.Web.Controllers
{
    public class UrlController : Controller
    {
        readonly IUrlService _urlService;
        public UrlController(IUrlService service) 
        { 
            _urlService = service;
        }

        [HttpPost]
        public async Task<IActionResult> ShortenUrl(string longUrl)
        {
            if (string.IsNullOrEmpty(longUrl))
            {
                return BadRequest("The url cannot be empty!");
            }

            var shortUrl = _urlService.ShortenUrl(longUrl);
            return Ok(new { shortUrl }); // can change this to view
        }

        [HttpGet]
        public async Task<IActionResult> GetOriginalUrl(string shortUrl)
        {
            if (string.IsNullOrEmpty(shortUrl))
            {
                return BadRequest("The url cannot be empty!");
            }

            string original = await _urlService.GetOriginalUrl(shortUrl);

            if (string.IsNullOrEmpty(original))
            {
                return BadRequest("Url was not found");
            }

            return Redirect(original);
        }

    }
}
