using App.Domain.IRepositories;

namespace App.Domain.IUnitofWork
{
    public interface IUnitofwork
    {
        IIdentityRepository IdentityRepository { get; }
        IFinanceRequestRepository FinanceRequestRepository { get; }
        int Save();

        Task<int> SaveAsync();
    }
}
