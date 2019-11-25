using System;
using System.Collections.Generic;
using System.Text;

namespace EFC.Framework.Data
{
    /// <summary>
    /// Base contract for storing and retrieving the unique identifier of an entity.
    /// </summary>
    /// <typeparam name="TIdentifier">The type of identifier that uniquely identifes the entity.</typeparam>
    public interface IEntity<TIdentifier>
    {
        /// <summary>
        /// Gets an identifier that uniquely identifies an entity.
        /// </summary>
        /// <value>The identifier that uniquely identifes the entity.</value>
        TIdentifier Id { get; }
    }
}
