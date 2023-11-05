using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.PropertyImages
{
    public interface IPropertyImageCommandRepository
    {
        /// <summary>
        /// Create Property Image
        /// </summary>
        /// <param name="propertyImage"></param>
        /// <returns></returns>
        Task<PropertyImage> CreateAsync(PropertyImage propertyImage);
    }
}
