using BE_E_Commerce.Indentity.Services.IRepositories;

namespace BE_E_Commerce.Indentity;

public interface IUnitOfWork
{
    IAccountRepository AccountRepository { get; }
    Task CompleteAsync();
}