using Domain.Owners;
using Infrastructure.Repositories.GenericRepository.QueryRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.OwnersRepository
{
    public class OwnerQueryRepository: IOwnerQueryRepository
    {
        private readonly IQueryRepository<Owner> _queryyRepository;
        
        public OwnerQueryRepository(IQueryRepository<Owner> queryyRepository)
        {
            _queryyRepository = queryyRepository;
        }

        /// <inheritdoc/>
        public async Task<Owner?> GetByIdAsync(int idOwner)
        {
            return await _queryyRepository.Get(x => x.IdOwner == idOwner);
        }
    }
}
