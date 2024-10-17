using TLbankRepositories.Interfaces;
using TLbankEntities.Entities;
using TLbankServices.Interfaces;
using TLbankServices.DTOs;
using TLbankInfra.ExceptionsCustomize;
using AutoMapper;
using TLbankGateways.AutorizaGate.Interfaces;
using TLbankGateways.NotifyGate.Interfaces;

namespace TLbankServices.Implementations;

public class TransferenciaService : ITransferenciaService
{
    private readonly ITransferenciaRepository _transferenciaRepo;
    private readonly IContaRepository _contaRepo;
    private readonly IAutorizaGateware _autorizaGate;
    private readonly INotifyGateware _notify;
    private readonly IMapper _mapper;
    public TransferenciaService(ITransferenciaRepository transferenciaRepo, IContaRepository contaRepo, 
                                IAutorizaGateware autorizaGate, INotifyGateware notify, IMapper mapper)
    {
        _transferenciaRepo = transferenciaRepo;
        _contaRepo = contaRepo;
        _autorizaGate = autorizaGate;
        _notify = notify;
        _mapper = mapper;
    }
    public async Task<string> Executar(CriarTransferenciaDTO transferencia)
    {
        TestaDadosDeTransferenciaValidos(transferencia);
        var contaBenefic = await _contaRepo.BuscaPorIdAsync(transferencia.PagadorContaNumero);
        var contaPagador = await _contaRepo.BuscaPorIdAsync(transferencia.BeneficiarioContaNumero);
        TestaEntidadesValidas(contaPagador, contaBenefic);
        TestaSaldoSuficiente(contaPagador.Saldo, transferencia.Valor);
        await TestaAutorizacao();
        contaBenefic.Saldo = contaBenefic.Saldo + transferencia.Valor;
        contaPagador.Saldo = contaPagador.Saldo + transferencia.Valor;
        Transferencia transferenciaEnt = _mapper.Map<Transferencia>(transferencia);
        await _transferenciaRepo.AddTrasacaoAsync(transferenciaEnt);
        var mensagem = await EnviarNotificacao(transferenciaEnt, contaBenefic, contaPagador);
        return mensagem;
    }
    private void TestaDadosDeTransferenciaValidos(CriarTransferenciaDTO transferencia){
        if (transferencia.Valor <= 0)
        {
            throw new HttpResponseException(400, "O Valor deve ser maior que 0");
        }
        if (transferencia.PagadorContaNumero == transferencia.BeneficiarioContaNumero)
        {
            throw new HttpResponseException(403, "Não é permitido realizar transferencia para a propria conta");
        }
    }
    private void TestaEntidadesValidas(ContaBase contaPagador, ContaBase contaBenefic){
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
    }
    private void TestaSaldoSuficiente(double saldoPagador, double valorTransferencia){
        if (saldoPagador < valorTransferencia)
        {
            throw new HttpResponseException(409, "Saldo insuficiente");
        }
    }
    private async Task TestaAutorizacao(){
        var autorizado = await _autorizaGate.GetAutorizacaoAsync();
        if (!autorizado){
            throw new HttpResponseException(401, "Transação não Autorizada");
        }
    }
    private async Task<string> EnviarNotificacao(Transferencia transferenciaEnt, ContaBase contaBenefic, ContaBase contaPagador){
        var notificado = await _notify.SendNotificacao(transferenciaEnt, contaBenefic, contaPagador);
        var mensagem = "Notificação enviada com sucesso";
        if (!notificado){
            mensagem = "Falha ao enviar a notificação";
        }
        return mensagem;
    }
}