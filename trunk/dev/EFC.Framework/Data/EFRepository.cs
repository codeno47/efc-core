using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace EFC.Framework.Data
{

    /// <summary>
    /// Implementation of <see cref="RepositoryBase{TEntity,TIdentifier}"/> class that uses Entity Framework
    /// for the repository operations.
    /// </summary>
    /// <typeparam name="TEntity">The type of entity that the repository encapsulates.</typeparam>
    /// <typeparam name="TIdentifier">The identifier that uniquely identifes the entity.</typeparam>
    public class EFRepository<TEntity, TIdentifier> : RepositoryBase<TEntity, TIdentifier> where TEntity : class, IEntity<TIdentifier>
    {

        #region Properties

        /// <summary>
        /// Gets the entity framework Data Context.
        /// </summary>
        public DbContext DbContext { get; set; }


        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of EFRepository.
        /// </summary>
        /// <param name="context">The DbContext.</param>
        public EFRepository(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            this.DbContext = context;

        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns list of entities from the repository or store.
        /// </summary>
        /// <param name="filterType">The filter type.</param>
        /// <returns>Strongly typed <see cref="IEnumerable{TEntity}"/>.</returns>
        public override IEnumerable<TEntity> GetAll()
        {
            return DbContext.Set<TEntity>();
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
        public override IEnumerable<TEntity> GetBySpecification(Specification<TEntity> specification, bool useCSharpNullComparisonBehavior = false)
        {
            IEnumerable<TEntity> items;

            if (specification.Predicate == null)
            {
                throw new System.Data.InvalidExpressionException("Argument Predicate is missing");
            }


            items = DbContext.Set<TEntity>().Where(specification.Predicate.Compile());


            // This code is added to ensure that the above query executed properly.
            // For example, if data connection is invalid, the above statement will not throw an exception.
            // So, while accessing the items, an exception shall be thrown in case of any failurs.
            var count = items.Count();

            return items;
        }

        /// <summary>
        /// Returns an entity that has the specified entity key.
        /// </summary>
        /// <param name="id">Entity key value.</param>
        /// <returns>Entity.</returns>
        /// <exception cref="NotSupportedException">Occurs if the Entity Type(TEntity) is not stored in the given repository.</exception>
        public override TEntity GetById(TIdentifier id)
        {
           return DbContext.Set<TEntity>()
                .FirstOrDefault(e => this.Compare(e.Id,id));
        }

        public bool Compare<T>(T x, T y)
        {
            return EqualityComparer<T>.Default.Equals(x, y);
        }
        /// <summary>
        /// Add an entity to the repository.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <returns>The entity.</returns>
        public override TEntity Add(TEntity entity)
        {
            if (Equals(entity, default(TEntity)))
            {
                throw new InvalidExpressionException("Argument could not be default");
            }

            DbContext.Set<TEntity>().Add(entity);
            ////DbContext.SaveChanges();
            return entity;
        }

        /// <summary>
        /// Update an entity in the repository.
        /// </summary>
        /// <param name="entity">Entity instance.</param>
        public override void Update(TEntity entity)
        {
            if (Equals(entity, default(TEntity)))
            {
                throw new InvalidExpressionException("Argument could not be default");
            }

            DbContext.Set<TEntity>().Update(entity);
            ////DbContext.SaveChanges();
        }

        /// <summary>
        /// Mark an entity for deletion in the repository.
        /// </summary>
        /// <param name="entity">The entity to delete.</param>
        public override void Delete(TEntity entity)
        {
            if (Equals(entity, default(TEntity)))
            {
                throw new InvalidExpressionException("Argument could not be default");
            }

            var entityData = GetById(entity.Id);
            DbContext.Set<TEntity>().Remove(entity);
            ////DbContext.SaveChanges();
        }


       #endregion
    }
}
