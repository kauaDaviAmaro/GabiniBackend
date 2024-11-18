using Core.Models;
using Core.Repositories;
using Infrastructure.Repositories.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class AddressRepository : IAddressRepository
    {

        private readonly GabiniDbContext _context;

        public AddressRepository(GabiniDbContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<Address>> GetByUserId(string userId)
        {
            return Task.FromResult(_context.Addresses
                .Where(a => a.User.Id == userId)
                .AsEnumerable());
        }


        public async Task<Address> SaveAddress(Address address)
        {
            _context.Addresses.Add(address);
            await _context.SaveChangesAsync();

            return address;
        }

        public async Task<Address> UpdateAddress(Address address)
        {
            var existingAddress = await _context.Addresses
                .FirstOrDefaultAsync(a => a.Id == address.Id);

            if (existingAddress == null)
            {
                throw new KeyNotFoundException($"Address with id '{address.Id}' not found");
            }

            existingAddress.Street = address.Street;
            existingAddress.Number = address.Number;
            existingAddress.Neighborhood = address.Neighborhood;
            existingAddress.City = address.City;
            existingAddress.State = address.State;
            existingAddress.ZipCode = address.ZipCode;

            await _context.SaveChangesAsync();

            return existingAddress;
        }

        public async Task<Address> DeleteAddress(Address address)
        {
            var existingAddress = await _context.Addresses
                .FirstOrDefaultAsync(a => a.Id == address.Id);

            if (existingAddress == null)
            {
                throw new KeyNotFoundException($"Address with id '{address.Id}' not found");
            }

            _context.Addresses.Remove(existingAddress);

            await _context.SaveChangesAsync();

            return address;
        }

        public async Task<Address> GetById(string id)
        {
            var address = await _context.Addresses
                .FirstOrDefaultAsync(a => a.Id == id);

            if (address == null)
            {
                throw new KeyNotFoundException($"Address with id '{id}' not found");
            }

            return address;
        }
    }
}
