using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Properties
{
    public interface IPropertyCommandRepository
    {
        /// <summary>
        /// Create Properties
        /// </summary>
        /// <returns></returns>
        Task<Property> CreateAsync(Property property);

        /// <summary>
        /// Update Property
        /// </summary>
        /// <returns></returns>
        Task<Property> UpdateAsync(Property property);
    }
}
