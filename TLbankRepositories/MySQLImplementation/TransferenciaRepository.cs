using TLbankEntities.Entities;
using TLbankRepositories.Contexts;
using TLbankRepositories.Interfaces;

namespace TLbankRepositories.MySQLImplementantion;

public class TransferenciaRepository : ITransferenciaRepository
{
    private readonly TLbankContext _context;

    public TransferenciaRepository(TLbankContext context)
    {
        _context = context;
    }

    public async Task AddTrasacaoAsync(Transferencia transferencia)
    {
        await _context.Transferencias.AddAsync(transferencia);
    }
}