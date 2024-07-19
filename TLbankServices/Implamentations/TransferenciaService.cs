using TLbankRepositories.Interfaces;
using TLbankEntities.Entities;
using TLbankServices.Interfaces;
using TLbankServices.DTOs;
using TLbankInfra.ExceptionsCustomize;

namespace TLbankServices.Implamentations;

public class TransferenciaService : ITransferenciaService
{
    private readonly ITransferenciaRepository _transferenciaRepo;
    private readonly IContaRepository _contaRepo;
    public TransferenciaService(ITransferenciaRepository transferenciaRepo, IContaRepository contaRepo)
    {
        _transferenciaRepo = transferenciaRepo;
        _contaRepo = contaRepo;
    }
    public async Task Executar(CriarTransferenciaDTO transferencia)
    {
        if (transferencia.Valor <= 0)
        {
            throw new HttpResponseException(403, "Valor não permitido");
        }

        var contaBenefic = await _contaRepo.BuscaPorIdAsync(transferencia.PagadorContaNumero);
        var contaPagador = await _contaRepo.BuscaPorIdAsync(transferencia.BeneficiarioContaNumero);
        if (contaPagador == null)
        {
            throw new HttpResponseException(404, "Conta do pagador, não encontrada");
        }
        if (contaBenefic == null)
        {
            throw new HttpResponseException(404, "Conta do beneficiário, não encontrada");
        }

        if (contaPagador.GetType().Equals(typeof(ContaLogista)))
        {
            throw new HttpResponseException(403, "Conta Logista não pode realizar transferencia");
        }

        if (contaPagador.Equals(contaBenefic))
        {
            throw new HttpResponseException(403, "Não é permitido realizar transferencia para a propria conta");
        }

        if (contaPagador.Saldo < transferencia.Valor)
        {
            throw new HttpResponseException(409, "Saldo insuficiente");
        }
    }
}