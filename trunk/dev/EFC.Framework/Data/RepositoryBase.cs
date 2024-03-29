﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFC.Framework.Data
{
    /// <summary>
    /// An abstract base class for <see cref="IRepository{TEntity,TIdentifier}"/>.
    /// </summary>
    /// <typeparam name="TEntity">The type of entity that the repository encapsulates.</typeparam>
    /// <typeparam name="TIdentifier">The identifier that uniquely identifes the entity.</typeparam>
    public abstract class RepositoryBase<TEntity, TIdentifier> : IRepository<TEntity, TIdentifier> where TEntity : class, IEntity<TIdentifier>
    {

        #region Methods

        /// <summary>
        /// Returns list of entities from the repository or store.
        /// </summary>
        /// <param name="filterType">The filter type.</param>
        /// <returns>Strongly typed <see cref="IEnumerable{TEntity}"/>.</returns>
        public abstract IEnumerable<TEntity> GetAll();

        /// <summary>
        /// Gets all asynchronous.
        /// Don't user base return value. Just use overridden version of method.
        /// </summary>
        /// <param name="filterType">Type of the filter.</param>
        /// <returns></returns>
        public virtual Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return null;
        }

        /// <summary>
        /// Gets the by specification asynchronous.
        /// </summary>
        /// <param name="specification">The specification.</param>
        /// <returns></returns>
        public virtual Task<IEnumerable<TEntity>> GetBySpecificationAsync(Specification<TEntity> specification)
        {
            return null;
        }

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
        public abstract IEnumerable<TEntity> GetBySpecification(
            Specification<TEntity> specification,
            bool useCSharpNullComparisonBehavior = false);

        /// <summary>
        /// Returns an entity that has the specified entity key.
        /// </summary>
        /// <param name="id">Entity key value.</param>
        /// <returns>The entity.</returns>
        public abstract TEntity GetById(TIdentifier id);

        /// <summary>
        /// Gets the by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public virtual Task<TEntity> GetByIdAsync(TIdentifier id)
        {
            return null;
        }

        /// <summary>
        /// Adds the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>
        /// TEntity.
        /// </returns>
        public virtual Task AddAsync(TEntity entity)
        {
            return null;
        }

        /// <summary>
        /// Add entity to the repository.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <returns>The added entity.</returns>
        public abstract TEntity Add(TEntity entity);

        /// <summary>
        /// Updates entity within the the repository.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        public abstract void Update(TEntity entity);

        /// <summary>
        /// Updates the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Task.</returns>
        public virtual Task UpdateAsync(TEntity entity)
        {
            return null;
        }

        /// <summary>
        /// Mark entity to be deleted within the repository.
        /// </summary>
        /// <param name="entity">The entity to delete.</param>
        public abstract void Delete(TEntity entity);

        /// <summary>
        /// Deletes the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual Task DeleteAsync(TEntity entity)
        {
            return null;
        }

     
        #endregion
    }
}
