using TLbankEntities.Entities;

namespace TLbankRepositories.Interfaces;

public interface ITransferenciaRepository
{
    public Task LancarAsync(Transferencia transferencia);
}