namespace IntegrationTests.Common;

public partial class TestBase
{
    protected async Task<TEntity> FindAsync<TEntity>(params object[] keyValues) where TEntity : class
    {
        using var scope = ApplicationFactory.Services.CreateScope();
        var context = scope.ServiceProvider.GetService<AppDbContext>();
        return await context.FindAsync<TEntity>(keyValues);
    }

    protected async Task<TEntity> FindAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
    {
        using var scope = ApplicationFactory.Services.CreateScope();
        var context = scope.ServiceProvider.GetService<AppDbContext>();
        return await context.Set<TEntity>().FirstOrDefaultAsync(predicate);
    }

    protected async Task<List<TEntity>> GetAllAsync<TEntity>() where TEntity : class
    {
        using var scope = ApplicationFactory.Services.CreateScope();
        var context = scope.ServiceProvider.GetService<AppDbContext>();
        return await context.Set<TEntity>().ToListAsync();
    }

    protected async Task<List<TEntity>> GetAllAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
    {
        using var scope = ApplicationFactory.Services.CreateScope();
        var context = scope.ServiceProvider.GetService<AppDbContext>();
        return await context.Set<TEntity>().Where(predicate).ToListAsync();
    }

    protected async Task AddAsync<TEntity>(TEntity entity) where TEntity : class
    {
        using var scope = ApplicationFactory.Services.CreateScope();
        var context = scope.ServiceProvider.GetService<AppDbContext>();
        context.Add(entity);
        await context.SaveChangesAsync();
    }

    protected async Task AddRangeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
    {
        using var scope = ApplicationFactory.Services.CreateScope();
        var context = scope.ServiceProvider.GetService<AppDbContext>();
        await context.AddRangeAsync(entities);
        await context.SaveChangesAsync();
    }

    protected async Task RemoveAsync<TEntity>(TEntity entity) where TEntity : class
    {
        using var scope = ApplicationFactory.Services.CreateScope();
        var context = scope.ServiceProvider.GetService<AppDbContext>();
        context.Remove(entity);
        await context.SaveChangesAsync();
    }
}
