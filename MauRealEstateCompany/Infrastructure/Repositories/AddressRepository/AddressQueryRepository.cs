using Domain.Addresses;
using Infrastructure.Repositories.GenericRepository.QueryRepository;
using Microsoft.EntityFrameworkCore;
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

        /// <inheritdoc/>
        public async Task<IEnumerable<Address>> GetAll()
        {
            return await _addresRepository.GetAll().ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<Address> GetByIdProperty(int idProperty)
        {
            return await _addresRepository.Get(a => a.IdProperty == idProperty);
        }
    }
}
