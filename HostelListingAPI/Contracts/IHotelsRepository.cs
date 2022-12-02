using HostelListingAPI.Data;

namespace HostelListingAPI.Contracts
{
    public interface IHotelsRepository : IGenericRepository<Hotel>
    {
        Task<List<Hotel>> GetAll();

        Task<Hotel> GetDetails(int? id);
    }
}
