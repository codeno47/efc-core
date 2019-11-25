using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Unity;

namespace EFC.Framework.Data
{
    public abstract class EFRepositoryContext<TContext> : IRepositoryContext where TContext : DbContext
    {
        #region Fields

        /// <summary>
        /// A boolean value indicating whether the current object is disposed or not.
        /// </summary>
        private bool disposed;

        /// <summary>
        /// The entity framework Data Context.
        /// </summary>
        private TContext context;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the entity framework data dontext.
        /// </summary>
        /// <value>The entity framework data context.</value>
        public TContext DbContext
        {
            get
            {
                if (context == null)
                {
                    context = CreateContext();
                }

                return context;
            }
        }

        ///// <summary>
        ///// Gets the entity framework Object Context.
        ///// </summary>
        //private System.Data.Entity.Core.Objects.ObjectContext Context => ((IObjectContextAdapter)DbContext).ObjectContext;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EFRepositoryContext{TContext}"/> class.
        /// </summary>
        public EFRepositoryContext()
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Creates the entity framework data context.
        /// </summary>
        /// <returns>The entity framework data context.</returns>
        protected abstract TContext CreateContext();

        /// <summary>
        /// Flushes the changes made in the unit of work to the data store.
        /// </summary>
        public int Commit()
        {
            return CommitChanges();
        }

        /// <summary>
        /// Commits the with audit.
        /// </summary>
        /// <returns></returns>
        public int CommitWithAudit(IUnityContainer container)
        {
            return DbContext.SaveChanges();
        }

        /// <summary>
        /// Commits the changes.
        /// </summary>
        /// <returns></returns>
        private int CommitChanges()
        {
            return DbContext.SaveChanges();
        }
        /// <summary>
        /// Commits the async.
        /// </summary>
        /// <returns></returns>
        public async Task<int> CommitAsync()
        {
            return await DbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Rollback all the changes made in the unit of work.
        /// </summary>
        public void Rollback()
        {
            foreach (var ent in DbContext.ChangeTracker
                     .Entries()
                     .Where(p => p.State == EntityState.Deleted ||
                                     p.State == EntityState.Modified))
            {
                ent.State = EntityState.Unchanged;
            }

            foreach (var ent in DbContext.ChangeTracker
                    .Entries()
                    .Where(p => p.State == EntityState.Added))
            {
                ent.State = EntityState.Detached;
            }
        }

        /// <summary>
        /// This function is used to create the specified instance of type TEntity.
        /// </summary>
        /// <typeparam name="TEntity">The type of the data item.</typeparam>
        /// <typeparam name="TIdentifier">The identifier that uniquely identifes the data item.</typeparam>
        /// <returns>Instance of Repository.</returns>
        public IRepository<TEntity, TIdentifier> GetRepository<TEntity, TIdentifier>() where TEntity : class, IEntity<TIdentifier>
        {
            var repository = new EFRepository<TEntity, TIdentifier>(this.DbContext);

            return repository;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Refreshes this Data context with original values from database.
        /// </summary>
        //public int Refresh()
        //{
        //    ////var refreshableObjects = GetRefreshableObjects();

        //    ////Context.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, refreshableObjects);
        //    ////return 0;
        //}

        /////// <summary>
        /////// Gets the refreshable objects.
        /////// </summary>
        /////// <returns></returns>
        ////private IEnumerable<object> GetRefreshableObjects()
        ////{
        ////    return (from entry in Context.ObjectStateManager.GetObjectStateEntries(
        ////                                       EntityState.Added
        ////                                       | EntityState.Deleted
        ////                                       | EntityState.Modified
        ////                                       | EntityState.Unchanged)
        ////            where entry.EntityKey != null
        ////            select entry.Entity);
        ////}

        /////// <summary>
        /////// Refreshes the async.
        /////// </summary>
        ////public async void RefreshAsync()
        ////{
        ////    var refreshableObjects = GetRefreshableObjects();

        ////    await this.Context.RefreshAsync(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, refreshableObjects);
        ////}

        /// <summary>
        /// Disposes the managed and unmanaged resources.
        /// </summary>
        /// <param name="disposing">Boolean value indicating whether to dispose or not.</param>
        private void Dispose(bool disposing)
        {
            if (!disposing)
            {
                return;
            }

            if (disposed)
            {
                return;
            }

            disposed = true;
        }

        #endregion
    }
}

