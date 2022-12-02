using HostelListingAPI.Contracts;
using HostelListingAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace HostelListingAPI.Abstractions
{
    public class HotelsRepository : GenericRepository<Hotel>, IHotelsRepository
    {
        private readonly HotelListingDbContext _context;

        public HotelsRepository(HotelListingDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Hotel>> GetAll()
        {
            return await _context.Hotels.Include(q => q.Country).ToListAsync();
        }

        public async Task<Hotel> GetDetails(int? id)
        {
            if(id is null)
            {
                return null;
            }

            return await _context.Hotels.Include(q => q.Country).FirstOrDefaultAsync(q => q.Id == id);
        }
    }
}
