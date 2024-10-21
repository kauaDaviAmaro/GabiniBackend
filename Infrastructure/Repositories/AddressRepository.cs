using Core.Models;
using Core.Repositories;
using Infrastructure.Repositories.Data;

namespace Infrastructure.Repositories
{
    public class AddressRepository : IAddressRepository
    {

        private readonly GabiniDbContext _context;

        public AddressRepository(GabiniDbContext context)
        {
            _context = context;
        }

        public async Task<Address> SaveAddress(Address address)
        {
            _context.Addresses.Add(address);
            await _context.SaveChangesAsync();

            return address;
        }
    }
}
