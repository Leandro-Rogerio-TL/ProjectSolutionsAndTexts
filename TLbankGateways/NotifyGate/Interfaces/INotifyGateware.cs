using TLbankEntities.Entities;

namespace TLbankGateways.NotifyGate.Interfaces;

public interface INotifyGateware
{
    public Task<bool> SendNotificacao(Transferencia transferenciaEnt, ContaBase contaBenefic, ContaBase contaPagador);
}