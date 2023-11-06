using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Addresses
{
    public interface IAddressQueryRepository
    {
        /// <summary>
        /// Get Addrea By Property Id
        /// </summary>
        /// <param name="idProperty"></param>
        /// <returns></returns>
        Task<Address> GetByIdProperty(int idProperty);

        /// <summary>
        /// Get All Address
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Address>> GetAll();
    }
}
