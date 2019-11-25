using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EFC.Framework.Data
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Commits this instance.
        /// </summary>
        /// <returns></returns>
        int Commit();

        /// <summary>
        /// Commits the async.
        /// </summary>
        /// <returns></returns>
        Task<int> CommitAsync();

    }
}
