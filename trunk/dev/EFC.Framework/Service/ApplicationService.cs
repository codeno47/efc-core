using EFC.Framework.Data;
using Microsoft.EntityFrameworkCore;
using System;
using Unity;

namespace EFC.Framework.Service
{
    public abstract class ApplicationService<TContext> where TContext : DbContext, IDisposable
    {
        #region Properties

        /// <summary>
        /// Gets or sets the unity.
        /// </summary>
        /// <value>
        /// The unity.
        /// </value>
        protected IUnityContainer Unity { get; set; }

        /// <summary>
        /// Gets or sets the data context.
        /// </summary>
        /// <value>
        /// The data context.
        /// </value>
        protected IRepositoryContext RepositoryContext { get; set; }

        /// <summary>
        /// Gets or sets the data context.
        /// </summary>
        /// <value>
        /// The data context.
        /// </value>
        protected TContext DataContext { get; set; }

        #endregion

        /// <summary>Initializes a new instance of the <see cref="ApplicationService{TContext}"/> class.</summary>
        /// <param name="unity">The unity.</param>
        /// <param name="repository">The context.</param>
        protected ApplicationService(IUnityContainer unity, IRepositoryContext context)
        {
            Unity = unity;
            RepositoryContext = context;
            InitilizeContext();
        }

        /// <summary>
        /// Saves this current changes to database.
        /// No auditing will be executed.
        /// </summary>
        /// <returns>Status code.</returns>
        protected int Save()
        {
            return RepositoryContext.Commit();
        }


        /// <summary>
        /// Initializes the context.
        /// </summary>
        private void InitilizeContext()
        {
           
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        public void Dispose()
        {
            RepositoryContext.Dispose();
        }
    }
}
