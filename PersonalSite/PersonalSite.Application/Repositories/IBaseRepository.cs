using System.Collections.Immutable;

namespace PersonalSite.Application.Repositories;

public interface ISqlBaseRepository<T, U>
{
    public Task<ImmutableList<T>> GetAllAsync();

    public Task<T> GetByIdAsync(Guid id);

    public Task<bool> AddAsync(U input);

    public Task<bool> UpdateAsync(Guid id,U input);

    public Task<bool> DeleteAsync(Guid id);
}   