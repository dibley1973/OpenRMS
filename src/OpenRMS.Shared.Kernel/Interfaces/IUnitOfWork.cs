namespace OpenRMS.Shared.Kernel.Interfaces
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// Commits the current atomic transaction
        /// </summary>
        void Commit();
    }
}