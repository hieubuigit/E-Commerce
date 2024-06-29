using BE_E_Commerce.DataContext;
using Microsoft.EntityFrameworkCore;

namespace BE_E_Commerce.Admin.Services;

public class GenericRepository<T> : IGenericRepository<T> where T: class
{
    protected ECommerceContext _context;
    protected DbSet<T> dbSet;
    protected readonly ILogger _logger;

    public GenericRepository(ECommerceContext context, DbSet<T> dbSet, ILogger logger)
    {
        _context = context;
        this.dbSet = dbSet;
        _logger = logger;
    }

    public virtual async Task<IEnumerable<T>> All()
    {
        return await dbSet.ToListAsync();
    }

    public virtual async Task<T> GetById(int id)
    {
        try
        {
            return await dbSet.FindAsync(id);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error getting entity with id {Id}");
            return null;
        }
    }

    public virtual async Task<bool> Add(T entity)
    {
        try
        {
            await dbSet.AddAsync(entity);
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error adding entity");
            return false;
        }
    }

    public virtual async Task<bool> Delete(int id)
    {
        try
        {
            var entity = await dbSet.FindAsync(id);
            if (entity != null)
            {
                dbSet.Remove(entity);
                return true;
            }
            else
            {
                _logger.LogError("Entity with id {Id} not found for deletion", id);
                return false;
            }
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error deleting entity with id {Id}", id);
            return false;
        }
    }

    public Task<bool> Update(T entity)
    {
        throw new NotImplementedException();
    }
}