using Domain.Addresses;
using Infrastructure.Repositories.GenericRepository.CommandRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.AddressRepository
{
    public class AddressCommandRepository : IAddressCommandRepository
    {
        private readonly ICommandRepository<Address> _commandRepository;

        public AddressCommandRepository(ICommandRepository<Address> commandRepository)
        {
            _commandRepository = commandRepository;
        }

        public async Task<Address> CreateAsync(Address address)
        {
            return await _commandRepository.Add(address);
        }

        public async Task<Address> UpdateAsync(Address address)
        {
            return await _commandRepository.Update(address);
        }

        public async Task<int> DeleteAasync(Address address)
        {
            return await _commandRepository.Delete(address);
        }
    }
}
