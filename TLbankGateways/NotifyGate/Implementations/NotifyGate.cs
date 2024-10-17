
using TLbankEntities.Entities;
using TLbankGateways.NotifyGate.Interfaces;

namespace TLbankGateways.NotifyGate.Implementations;

public class NotifyGateware : INotifyGateware
{
    public Task<bool> SendNotificacao(Transferencia transferenciaEnt, ContaBase contaBenefic, ContaBase contaPagador)
    {
        throw new NotImplementedException();
    }
}