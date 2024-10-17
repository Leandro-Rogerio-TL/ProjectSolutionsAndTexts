using TLbankServices.DTOs;

namespace TLbankServices.Interfaces;

public interface ITransferenciaService
{
    public Task<string> Executar(CriarTransferenciaDTO transferencia);
}