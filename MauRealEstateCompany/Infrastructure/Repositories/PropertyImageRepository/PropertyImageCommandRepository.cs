using Domain.PropertyImages;
using Infrastructure.Repositories.GenericRepository.CommandRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.PropertyImageRepository
{
    public class PropertyImageCommandRepository: IPropertyImageCommandRepository
    {
        private ICommandRepository<PropertyImage> _commandRepository;

        public PropertyImageCommandRepository(ICommandRepository<PropertyImage> commandRepository)
        {
            _commandRepository = commandRepository;
        }

        public async Task<PropertyImage> CreateAsync(PropertyImage propertyImage)
        {
            return await _commandRepository.Add(propertyImage);
        }
    }
}
