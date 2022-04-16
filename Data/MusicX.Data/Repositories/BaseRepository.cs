using Microsoft.EntityFrameworkCore;
using MusicX.Common.Conventions;
using MusicX.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MusicX.Data.Repositories;

public class BaseRepository<T> : IScopedService where T : ApplicationEntity 
{
    protected readonly ApplicationDbContext context;

    public BaseRepository(ApplicationDbContext context)
    {
        this.context = context;
    }

    public virtual async Task<ICollection<T>> GetAllAsync(Expression<Func<T, bool>> filter = null)
    {
        var set = context.Set<T>().AsQueryable();

        if (filter != null)
        {
            set = set.Where(filter);
        }

        return await set.ToListAsync();
    }

    public virtual async ValueTask<T> GetByIdAsync(Guid id)
    {
        return await context.Set<T>().FindAsync(id);
    }

    public virtual async Task CreateAsync(T entity)
    {
        context.Set<T>().Add(entity);
        await context.SaveChangesAsync();
    }

    public virtual async Task UpdateAsync(T entity)
    {
        context.Set<T>().Update(entity);
        await context.SaveChangesAsync();
    }

    public virtual async Task DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);

        if (entity == null)
        {
            throw new ArgumentException($"There is no such {typeof(T)} with id: {id}");
        }

        context.Set<T>().Remove(entity);

        await context.SaveChangesAsync();
    }
}
