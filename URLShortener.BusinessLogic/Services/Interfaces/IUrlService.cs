using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URLShortener.BusinessLogic.Services.Interfaces
{
    public interface IUrlService
    {
        Task<string> ShortenUrl(string longUrl);
        Task<string> GetOriginalUrl(string shortUrl);
    }

}
