using HostelListingAPI.Data;

namespace HostelListingAPI.Contracts
{
    public interface ICountriesRepository : IGenericRepository<Country>
    {
        Task<Country> GetDetails(int id);
    }
}
