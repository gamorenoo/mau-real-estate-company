using Domain.Properties;
using Infrastructure.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class PropertyRepository : IPropertyRepository
    {

        private readonly IGenericRepository<Property> _propertyRepository;
        public PropertyRepository(IGenericRepository<Property> propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }

        public async Task<Property> CreateAsync(Property property)
        {
             return await _propertyRepository.Add(property);
        }

        public async Task<IEnumerable<Property>> GetAllPropertiesAsync()
        {
            return await _propertyRepository.GetList();
        }

        public async Task<Property> GetByIdAsync(int id)
        {
            var prperties = await _propertyRepository.GetList(x => x.IdProperty == id);

            return prperties.FirstOrDefault();
        }

        public async Task<Property> UpdateAsync(Property property)
        {
            return await _propertyRepository.Update(property);
        }
    }
}
