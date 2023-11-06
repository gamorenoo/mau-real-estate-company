using Domain.Properties;
using Infrastructure.Repositories.GenericRepository.CommandRepository;
using Infrastructure.Repositories.GenericRepository.QueryRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.PropertyRepository
{
    public class PropertyCommandRepository : IPropertyCommandRepository
    {
        private readonly ICommandRepository<Property> _commandRepository;

        public PropertyCommandRepository(ICommandRepository<Property> commandRepository)
        {
            _commandRepository = commandRepository;
        }

        /// <inheritdoc/>
        public async Task<Property> CreateAsync(Property property)
        {
            return await _commandRepository.Add(property);
        }

        /// <inheritdoc/>
        public async Task<Property> UpdateAsync(Property property)
        {
            return await _commandRepository.Update(property);
        }

    }
}
