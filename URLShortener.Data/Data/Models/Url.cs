using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URLShortener.Data.Data.Models
{
    public class Url
    {
        public int Id { get; set; }
        public string OriginalUrl { get; set; }
        public string ShortenedUrl { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}
