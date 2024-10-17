using TLbankEntities.Entities;

namespace TLbankRepositories.Interfaces;

public interface ITransferenciaRepository
{
    public Task AddTrasacaoAsync(Transferencia transferencia);
}