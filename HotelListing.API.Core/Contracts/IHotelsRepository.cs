using HotelListing.API.Data;

namespace HotelListing.API.Core.Contracts
{
    public interface IHotelsRepository : IGenericRepository<Hotel>
    {
        Task<List<Hotel>> GetAll();

        Task<Hotel> GetDetails(int? id);
    }
}
