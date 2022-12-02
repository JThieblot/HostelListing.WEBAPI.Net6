using HostelListingAPI.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace HostelListingAPI.models
{
    public class HotelDto : BaseHotelDto
    {
        public int Id { get; set; }
    }
}
