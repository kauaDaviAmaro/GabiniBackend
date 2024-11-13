using Core.Models;

namespace Core.Repositories
{
    public interface IAddressRepository
    {
        public Task<Address> SaveAddress(Address address);
        public Task<IEnumerable<Address>> GetByUserId(string userId);
        public Task<Address> GetById(string id);
        public Task<Address> UpdateAddress(Address address);
        public Task<Address> DeleteAddress(Address address);
    }
}
