using Domain.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Owners
{
    public interface IOwnerQueryRepository
    {
        /// <summary>
        /// Get Owner by Id
        /// </summary>
        /// <returns></returns>
        Task<Owner?> GetByIdAsync(int idOwner);
    }
}
