using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
