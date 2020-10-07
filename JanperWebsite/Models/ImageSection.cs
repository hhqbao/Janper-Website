using System.Collections.Generic;

namespace JanperWebsite.Models
{
    public class ImageSection
    {
        public string Title { get; set; }

        public IEnumerable<string> ImageUrls { get; set; }
    }
}