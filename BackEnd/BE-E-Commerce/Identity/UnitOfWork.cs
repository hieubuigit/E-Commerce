using BE_E_Commerce.DataContext;
using BE_E_Commerce.Identity.Services.IRepositories;
using BE_E_Commerce.Identity.Services.Repositories;

namespace BE_E_Commerce.Identity;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly ECommerceContext _context;
    private readonly ILogger _logger;
    public IAccountRepository AccountRepository { get; private set; }
    
    public UnitOfWork(ECommerceContext context, ILoggerFactory logger)
    {
        _context = context;
        _logger = logger.CreateLogger("logs");
        AccountRepository = new AccountRepository(_context, _logger);
    }
    
    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}