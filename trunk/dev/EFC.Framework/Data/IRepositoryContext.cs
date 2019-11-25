using System;
using System.Collections.Generic;
using System.Text;

namespace EFC.Framework.Data
{
    /// <summary>
    /// The interface that manages the repository context.
    /// 
    /// </summary>
    public interface IRepositoryContext : IUnitOfWork
    {
        /// <summary>
        /// This method will return the repository of the specified entity.
        /// 
        /// </summary>
        /// <typeparam name="TEntity">The type of the data item.</typeparam><typeparam name="TIdentifier">The identifier that uniquely identifes the data item.</typeparam>
        /// <returns>
        /// Instance of the repository.
        /// </returns>
        IRepository<TEntity, TIdentifier> GetRepository<TEntity, TIdentifier>() where TEntity : class, IEntity<TIdentifier>;
    }
}
