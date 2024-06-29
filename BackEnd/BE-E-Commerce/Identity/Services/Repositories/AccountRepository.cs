using BE_E_Commerce.DataContext;
using BE_E_Commerce.Identity.Services.IRepositories;
using BE_E_Commerce.Models;

namespace BE_E_Commerce.Identity.Services.Repositories;

public class AccountRepository : IAccountRepository
{
    public AccountRepository()
    {
    }

    public AccountRepository(ECommerceContext context, ILogger logger)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Account>> All()
    {
        throw new NotImplementedException();
    }

    public Task<Account> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Add(Account entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Update(Account entity)
    {
        throw new NotImplementedException();
    }
}