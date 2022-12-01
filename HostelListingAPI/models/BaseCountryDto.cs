using Microsoft.Build.Framework;

namespace HostelListingAPI.models
{
    public abstract class BaseCountryDto
    {
        [Required]
        public string Name { get; set; }
        public string ShortName { get; set; }
    }
}
