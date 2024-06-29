using BE_E_Commerce.Identity.Services.IRepositories;

namespace BE_E_Commerce.Identity;

public interface IUnitOfWork
{
    IAccountRepository AccountRepository { get; }
    Task CompleteAsync();
}