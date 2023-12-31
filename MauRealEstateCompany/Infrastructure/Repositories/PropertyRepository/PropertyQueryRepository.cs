﻿using Domain.Properties;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Repositories.GenericRepository.QueryRepository;
using System.Linq;

namespace Infrastructure.Repositories.PropertyRepository
{
    public class PropertyQueryRepository : IPropertyQueryRepository
    {

        private readonly IQueryRepository<Property> _queryyRepository;
        public PropertyQueryRepository(IQueryRepository<Property> propertyRepository)
        {
            _queryyRepository = propertyRepository;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Property>> GetAllPropertiesAsync()
        {
            return await _queryyRepository.GetList();
        }

        /// <inheritdoc/>
        public async Task<Property?> GetByIdAsync(int id)
        {
            var prperties = await _queryyRepository.GetList(x => x.IdProperty == id);

            return prperties.FirstOrDefault();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Property>> GetPropertiesWithFilterAsync(PropertyFiltersDto propertyFiltersDto)
        {
            IQueryable<Property> propertiesQuery = _queryyRepository.Get(includes: i => i.Include(x => x.Owner).Include(x => x.Address).Include(x => x.Images));

            if (propertyFiltersDto.IdProperty != null)
                propertiesQuery = propertiesQuery.Where(x => x.IdProperty == propertyFiltersDto.IdProperty);

            if(!string.IsNullOrWhiteSpace(propertyFiltersDto.CodeInternal))
                propertiesQuery = propertiesQuery.Where(x => x.CodeInternal.Contains(propertyFiltersDto.CodeInternal));

            if(!string.IsNullOrWhiteSpace(propertyFiltersDto.NameProperty))
                propertiesQuery = propertiesQuery.Where(x => x.Name.Contains(propertyFiltersDto.NameProperty));

            if (propertyFiltersDto.Price != null)
                propertiesQuery = propertiesQuery.Where(x => x.Price == propertyFiltersDto.Price);

            if (propertyFiltersDto.Year != null)
                propertiesQuery = propertiesQuery.Where(x => x.Year == propertyFiltersDto.Year);

            if (!string.IsNullOrWhiteSpace(propertyFiltersDto.NameOwner))
                propertiesQuery = propertiesQuery.Where(x => x.Owner.Name.Contains(propertyFiltersDto.NameOwner));

            if (propertyFiltersDto.IdOwner != null)
                propertiesQuery = propertiesQuery.Where(x => x.Owner.IdOwner == propertyFiltersDto.IdOwner);

            if (!string.IsNullOrWhiteSpace(propertyFiltersDto.Street))
                propertiesQuery = propertiesQuery.Where(x => x.Address.Street.Contains(propertyFiltersDto.Street));

            if (!string.IsNullOrWhiteSpace(propertyFiltersDto.City))
                propertiesQuery = propertiesQuery.Where(x => x.Address.City == propertyFiltersDto.City);

            if (!string.IsNullOrWhiteSpace(propertyFiltersDto.State))
                propertiesQuery = propertiesQuery.Where(x => x.Address.State.Contains(propertyFiltersDto.State));

            if (!string.IsNullOrWhiteSpace(propertyFiltersDto.Country))
                propertiesQuery = propertiesQuery.Where(x => x.Address.Country.Contains(propertyFiltersDto.Country));

            if (!string.IsNullOrWhiteSpace(propertyFiltersDto.ZipCode))
                propertiesQuery = propertiesQuery.Where(x => x.Address.ZipCode == propertyFiltersDto.ZipCode);

            return await propertiesQuery.ToListAsync();
        }
    }
}
