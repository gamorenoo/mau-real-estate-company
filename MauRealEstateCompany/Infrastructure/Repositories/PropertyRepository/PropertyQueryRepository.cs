using Domain.Properties;
using Infrastructure.Repositories.GenericRepository;
using Infrastructure.Repositories.GenericRepository.QueryRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.PropertyRepository
{
    public class PropertyQueryRepository : IPropertyQueryRepository
    {

        private readonly IQueryRepository<Property> _queryyRepository;
        public PropertyQueryRepository(IQueryRepository<Property> propertyRepository)
        {
            _queryyRepository = propertyRepository;
        }

        public async Task<IEnumerable<Property>> GetAllPropertiesAsync()
        {
            return await _queryyRepository.GetList();
        }

        public async Task<Property?> GetByIdAsync(int id)
        {
            var prperties = await _queryyRepository.GetList(x => x.IdProperty == id);

            return prperties.FirstOrDefault();
        }
    }
}
