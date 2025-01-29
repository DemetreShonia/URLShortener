using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using URLShortener.BusinessLogic.Services.Interfaces;
using URLShortener.Data.Data;
using URLShortener.Data.Data.Models; 

namespace URLShortener.BusinessLogic.Services.Implementations
{
    public class UrlService : IUrlService
    {
        private readonly ApplicationDbContext _context;

        public UrlService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<string> ShortenUrl(string longUrl)
        {
            var existingUrl = _context.Urls.FirstOrDefault(u => u.OriginalUrl == longUrl);
            if (existingUrl != null)
            {
                return existingUrl.ShortenedUrl;
            }

            var shortUrl = Guid.NewGuid().ToString().Substring(0, 6); // generate simple short url for now 

            var urlRecord = new Url
            {
                OriginalUrl = longUrl,
                ShortenedUrl = shortUrl,
                CreatedAt = DateTime.UtcNow
            };

            _context.Urls.Add(urlRecord);
            await _context.SaveChangesAsync();

            return shortUrl;
        }

        public async Task<string> GetOriginalUrl(string shortUrl)
        {
            var urlRecord = await _context.Urls
                .FirstOrDefaultAsync(u => u.ShortenedUrl == shortUrl);

            if (urlRecord == null)
            {
                return null; 
            }

            return urlRecord.OriginalUrl;
        }
    }
}
