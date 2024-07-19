namespace TLbankEntities.Entities;

public class ContaLogista : ContaBase
{
    public ContaLogista() : base()
    {
        base.Funcoes = new List<string> {"Receber"};
    }
}