using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.GenericRepository.QueryRepository
{
    /// <summary>
    /// Generic inmplementation for query repository
    /// </summary>
    public class QueryRepository<TEntity> : IQueryRepository<TEntity> where TEntity : class, new()
    {
        private readonly ApplicationDbContext _appDBcontext;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="ApiDBcontext"></param>
        public QueryRepository(ApplicationDbContext appDBcontext)
        {
            _appDBcontext = appDBcontext;
        }

        /// <summary>
        /// Get One record applying filters
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public async Task<TEntity?> Get(Expression<Func<TEntity, bool>> filter)
        {
            return await _appDBcontext.Set<TEntity>().FirstOrDefaultAsync(filter);
        }

        /// <summary>
        /// Get records applying filters
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TEntity>> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            return await (filter == null ? _appDBcontext.Set<TEntity>().ToListAsync() : _appDBcontext.Set<TEntity>().Where(filter).ToListAsync());
        }

        public virtual IQueryable<TEntity> GetAll()
        { 
            return _appDBcontext.Set<TEntity>().AsQueryable();
        }

        public virtual IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            IQueryable<TEntity> query = GetAll();

            if (filter != null)
                query = query.Where(filter);

            if (includes != null)
                query = includes(query);

            if (orderBy != null)
                query = orderBy(query);

            return query;
        }
    }
}
