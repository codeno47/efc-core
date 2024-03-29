﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFC.Framework.Data
{
    public interface IRepository<TEntity, TIdentifier> where TEntity : class, IEntity<TIdentifier>
    {
        /// <summary>
        /// Returns list of entities from the repository or store.
        /// 
        /// </summary>
        /// <param name="filterType">The filter type.</param>
        /// <returns>
        /// Strongly typed <see cref="T:System.Collections.Generic.IEnumerable`1"/>.
        /// </returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Gets all asynchronous.
        /// </summary>
        /// <param name="filterType">Type of the filter.</param>
        /// <returns>TEntity collection.</returns>
        Task<IEnumerable<TEntity>> GetAllAsync();

        /// <summary>
        /// Returns a list of entities from the repository based on the given specification.
        /// </summary>
        /// <param name="specification">The specification.</param>
        /// <param name="filterType">The filter type.</param>
        /// <param name="useCSharpNullComparisonBehavior">Set this flag off when equating nullable types..</param>
        /// <returns>
        /// The list of entities.
        /// </returns>
        /// <exception cref="System.Data.InvalidExpressionException">Argument Predicate is missing</exception>
        IEnumerable<TEntity> GetBySpecification(
            Specification<TEntity> specification,
           bool useCSharpNullComparisonBehavior = false);

        /// <summary>
        /// Gets the by specification asynchronous.
        /// </summary>
        /// <param name="specification">The specification.</param>
        /// <returns>TEntity Collection.</returns>
        Task<IEnumerable<TEntity>> GetBySpecificationAsync(Specification<TEntity> specification);

        /// <summary>
        /// Returns an entity that has the specified entity key.
        ///  </summary>
        /// <param name="id">Entity key value.</param>
        /// <returns>
        /// The entity.
        /// </returns>
        TEntity GetById(TIdentifier id);

        /// <summary>
        /// Gets the by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>TEntity.</returns>
        Task<TEntity> GetByIdAsync(TIdentifier id);

        /// <summary>
        /// Add entity to the repository.
        /// 
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <returns>
        /// The added entity.
        /// </returns>
        TEntity Add(TEntity entity);

        /// <summary>
        /// Adds the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>TEntity</returns>
        Task AddAsync(TEntity entity);

             /// <summary>
        /// Updates entity within the the repository.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        void Update(TEntity entity);

        /// <summary>
        /// Updates the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Task</returns>
        Task UpdateAsync(TEntity entity);

        /// <summary>
        /// Mark entity to be deleted within the repository.
        /// </summary>
        /// <param name="entity">The entity to delete.</param>
        void Delete(TEntity entity);

        /// <summary>
        /// Deletes the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Task</returns>
        Task DeleteAsync(TEntity entity);
    }
}
