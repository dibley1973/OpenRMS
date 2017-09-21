//-----------------------------------------------------------------------
// <copyright file="IUnitOfWork.cs" company="Chesil Media">
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// </copyright>
//-----------------------------------------------------------------------

namespace ORMS.Shared.SharedKernel.Interfaces
{
    using System;

    /// <summary>
    /// An interface that provides access to a unit of work.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Completes the current atomic transaction
        /// </summary>
        void Complete();
    }
}