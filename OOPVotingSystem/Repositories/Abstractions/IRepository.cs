namespace OOPVotingSystem.Repositories.Abstractions;

public interface IRepository<TEntity>
{
    Task<TEntity> CreateAsync(TEntity entity);

    Task UpdateAsync(string id, TEntity entity);

    Task DeleteAsync(string id);

    Task<TEntity> GetByIdAsync(string id);

    Task<IEnumerable<TEntity>> GetAllAsync();
}
