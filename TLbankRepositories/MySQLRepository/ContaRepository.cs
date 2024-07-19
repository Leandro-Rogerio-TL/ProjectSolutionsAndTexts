using Microsoft.EntityFrameworkCore;
using TLbankEntities.Entities;
using TLbankRepositories.Contexts;
using TLbankRepositories.Interfaces;

namespace TLbankRepositories.MySQLRepository;

public class ContaRepository : IContaRepository
{
    private readonly TLbankContext _context;

    public ContaRepository(TLbankContext context)
    {
        _context = context;
    }

    public async Task<ContaBase?> BuscaPorIdAsync(long numConta)
    {
        throw new NotImplementedException();
        //return await _context.Contas.FirstOrDefaultAsync(c => c.Numero == numConta);
    }
}