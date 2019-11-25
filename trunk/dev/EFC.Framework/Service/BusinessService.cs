using System;
using System.Collections.Generic;
using System.Text;
using Unity;

namespace EFC.Framework.Service
{
    public abstract class BusinessService : IDisposable
    {
        #region Properties

        /// <summary>
        /// Gets or sets the unity.
        /// </summary>
        /// <value>
        /// The unity.
        /// </value>
        protected IUnityContainer Unity { get; set; }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessService"/> class.
        /// </summary>
        /// <param name="unity">The unity.</param>
        protected BusinessService(IUnityContainer unity)
        {
            Unity = unity;
        }

        /// <summary>
        /// Saves this Current changes to database.
        /// </summary>
        /// <returns>Status code.</returns>
        public virtual int Save()
        {
            return 0;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public abstract void Dispose();
    }
}

