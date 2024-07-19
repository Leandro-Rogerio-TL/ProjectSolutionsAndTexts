using TLbankEntities.Entities;

namespace TLbankRepositories.Interfaces;

public interface IContaRepository
{
    public Task<ContaBase> BuscaPorIdAsync(long numConta);
}