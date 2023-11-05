using Domain.Addresses;
using Infrastructure.Repositories.GenericRepository.QueryRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.AddressRepository
{
    public class AddressQueryRepository: IAddressQueryRepository
    {
        private readonly IQueryRepository<Address> _addresRepository;

        public AddressQueryRepository(IQueryRepository<Address> addresRepository)
        {
            _addresRepository = addresRepository;
        }

        public async Task<Address> GetByIdProperty(int idProperty)
        {
            return await _addresRepository.Get(a => a.IdProperty == idProperty);
        }
    }
}
