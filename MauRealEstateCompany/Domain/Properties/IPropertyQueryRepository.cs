

namespace Domain.Properties
{
    public interface IPropertyQueryRepository
    {
        /// <summary>
        /// Get All Properties
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Property>> GetAllPropertiesAsync();

        /// <summary>
        /// Get Properties by Id
        /// </summary>
        /// <returns></returns>
        Task<Property?> GetByIdAsync(int id);

        /// <summary>
        /// Get Properties With Filters
        /// </summary>
        /// <param name="propertyFiltersDto"></param>
        /// <returns></returns>
        Task<IEnumerable<Property>> GetPropertiesWithFilterAsync(PropertyFiltersDto propertyFiltersDto);
    }
}
