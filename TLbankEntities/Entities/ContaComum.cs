namespace TLbankEntities.Entities;

public class ContaComum : ContaBase
{
    public ContaComum() : base()
    {
        base.Funcoes = new List<string> {"Pagar", "Receber"};
    }
}