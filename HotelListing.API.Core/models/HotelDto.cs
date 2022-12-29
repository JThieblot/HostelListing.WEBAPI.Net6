using HotelListing.API.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelListing.API.Core.models
{
    public class HotelDto : BaseHotelDto
    {
        public int Id { get; set; }
    }
}
