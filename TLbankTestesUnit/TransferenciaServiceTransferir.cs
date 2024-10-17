using Microsoft.EntityFrameworkCore;
using TLbankRepositories.Contexts;
using TLbankRepositories.MySQLImplementantion;
using TLbankServices.DTOs;
using TLbankServices.Implementations;

namespace TLbankTestesUnit;

public class TransferenciaServiceTransferir
{
    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public async Task RetornaStatusCode403QuandoOValorEhMenorOuIgualAZero(double valor)
    {
        //arrange
        var context = new TLbankContext(new DbContextOptions<TLbankContext>());
        var transRepo = new TransferenciaRepository(context);
        var contaRepo = new ContaRepository(context);
        var transferencia = new CriarTransferenciaDTO()
        {
            PagadorContaNumero = 1,
            BeneficiarioContaNumero = 2,
            Valor = valor
        };
        var transferir = new TransferenciaService();

        //act
        //var result = await transferir.Executar(transferencia);

        //assert
        Assert.ThrowsAsync<Exception>(() => transferir.Executar(transferencia));
    }
}