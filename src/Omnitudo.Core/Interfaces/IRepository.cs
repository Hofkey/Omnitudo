﻿using Omnitudo.Core.Entities;
using System.Linq.Expressions;

namespace Omnitudo.Core.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        /// <summary>
        /// Get a results from LINQ query.
        /// </summary>
        /// <param name="filter">Conditional statements.</param>
        /// <param name="orderBy">Order the results.</param>
        /// <param name="includeProperties">Properties you want to load (e.g. extra relation).</param>
        /// <returns>IQueryable containing query results.</returns>
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>>? filter,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            string includeProperties = "");

        /// <summary>
        /// Get entity by id.
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>Entity</returns>
        TEntity? GetById(Guid id);

        /// <summary>
        /// Create an entity.
        /// </summary>
        /// <param name="entity">Entity to create.</param>
        Task Create(TEntity entity);

        /// <summary>
        /// Update an entity.
        /// </summary>
        /// <param name="entity">New entity data</param>
        Task Update(TEntity entity);

        /// <summary>
        /// Remove an identity.
        /// </summary>
        /// <param name="id">Id of identity</param>
        Task Delete(Guid id);
    }
}
