using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.GenericRepository.CommandRepository
{
    /// <summary>
    /// Generic interfaz for commands repository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICommandRepository<T> where T : class, new()
    {
        /// <summary>
        /// Add one record
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<T> Add(T entity);

        /// <summary>
        /// Add more than one record at a times
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> AddRange(IEnumerable<T> entity);

        /// <summary>
        /// Actualiza registros
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<T> Update(T entity);

        /// <summary>
        /// Update more than one record at a time
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> UpdateRange(IEnumerable<T> entities);

        /// <summary>
        /// Delete one record
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<int> Delete(T entity);
        /// <summary>
        /// Delete more than one record at a time
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        Task<int> DeleteRange(IEnumerable<T> entities);
    }
}
