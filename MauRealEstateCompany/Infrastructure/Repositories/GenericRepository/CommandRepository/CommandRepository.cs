using Infrastructure.Persistence;
using Infrastructure.Repositories.GenericRepository.QueryRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.GenericRepository.CommandRepository
{
    internal class CommandRepository<TEntity> : ICommandRepository<TEntity> where TEntity : class, new()
    {
        private readonly ApplicationDbContext _appDBcontext;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="ApiDBcontext"></param>
        public CommandRepository(ApplicationDbContext appDBcontext)
        {
            _appDBcontext = appDBcontext;
        }

        /// <summary>
        /// Add one record
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<TEntity> Add(TEntity entity)
        {
            await _appDBcontext.AddAsync(entity);
            await _appDBcontext.SaveChangesAsync();
            return entity;
        }

        /// <summary>
        ///  Add more than one record at a times
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TEntity>> AddRange(IEnumerable<TEntity> entity)
        {
            await _appDBcontext.AddRangeAsync(entity);
            await _appDBcontext.SaveChangesAsync();
            return entity;
        }

        /// <summary>
        /// Actualiza registros
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<TEntity> Update(TEntity entity)
        {
            var addedEntry = _appDBcontext.Update(entity);
            await _appDBcontext.SaveChangesAsync();
            return entity;
        }

        /// <summary>
        /// Update more than one record at a time
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TEntity>> UpdateRange(IEnumerable<TEntity> entities)
        {
            _appDBcontext.UpdateRange(entities);
            await _appDBcontext.SaveChangesAsync();
            return entities;
        }

        /// <summary>
        /// Delete one record
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<int> Delete(TEntity entity)
        {
            var addedEntry = _appDBcontext.Remove(entity);
            return await _appDBcontext.SaveChangesAsync();
        }

        /// <summary>
        /// Delete more than one record at a time
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<int> DeleteRange(IEnumerable<TEntity> entities)
        {
            _appDBcontext.RemoveRange(entities);
            return await _appDBcontext.SaveChangesAsync();
        }
    }
}
