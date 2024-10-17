using TLbankGateways.AutorizaGate.Interfaces;

namespace TLbankGateways.AutorizaGate.Implementations;

public class AutorizaGateware : IAutorizaGateware
{
    public async Task<bool> GetAutorizacaoAsync()
    {
        using HttpClient client = new HttpClient();
        var uri = "https://run.mocky.io/v3/8fafdd68-a090-496f-8c9a-3442cf30dae6";
        HttpResponseMessage resposta = await client.GetAsync(uri);
        resposta.EnsureSuccessStatusCode();
        var result = await resposta.Content.ReadAsStringAsync();
        return result.Contains("authorized");
    }
}