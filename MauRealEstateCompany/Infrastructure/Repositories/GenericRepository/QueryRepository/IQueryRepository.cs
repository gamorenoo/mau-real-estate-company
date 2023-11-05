using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.GenericRepository.QueryRepository
{
    /// <summary>
    /// Generic interfaz for query repository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IQueryRepository<T> where T : class, new()
    {
        /// <summary>
        /// Get One record applying filters
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<T> Get(Expression<Func<T, bool>> filter = null);

        /// <summary>
        /// Get records applying filters
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetList(Expression<Func<T, bool>> filter = null);
    }
}
