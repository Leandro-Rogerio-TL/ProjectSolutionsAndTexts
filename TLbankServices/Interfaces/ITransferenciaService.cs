using TLbankServices.DTOs;

namespace TLbankServices.Interfaces;

public interface ITransferenciaService
{
    public Task Executar(CriarTransferenciaDTO transferencia);
}