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

        [HttpGet]
        public IActionResult ShortenUrl()
        {
            return View("Url"); 
        }


        [HttpPost]
        public async Task<IActionResult> ShortenUrl(string longUrl)
        {
            if (string.IsNullOrEmpty(longUrl))
            {
                return BadRequest("The url cannot be empty!");
            }

            var shortUrl = await _urlService.ShortenUrl(longUrl);

            return View("Url", shortUrl.ToString());
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
