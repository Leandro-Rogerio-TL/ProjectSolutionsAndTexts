namespace TLbankGateways.AutorizaGate.Interfaces;

public interface IAutorizaGateware
{
    public Task<bool> GetAutorizacaoAsync();
}