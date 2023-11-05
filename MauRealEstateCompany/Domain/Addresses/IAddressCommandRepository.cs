using Domain.Addresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Addresses
{
    public interface IAddressCommandRepository
    {
        /// <summary>
        /// Create Address
        /// </summary>
        /// <returns></returns>
        Task<Address> CreateAsync(Address address);

        /// <summary>
        /// Update Address
        /// </summary>
        /// <returns></returns>
        Task<Address> UpdateAsync(Address address);

        /// <summary>
        /// Delte Address
        /// </summary>
        /// <returns></returns>
        Task<int> DeleteAasync(Address address);
    }
}
