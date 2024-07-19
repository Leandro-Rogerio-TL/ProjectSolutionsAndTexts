using Microsoft.EntityFrameworkCore;
using TLbankRepositories.Contexts;
using TLbankRepositories.MySQLRepository;
using TLbankServices.DTOs;
using TLbankServices.Implamentations;

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
        var transRepo = new TransferenciaRepository();
        var contaRepo = new ContaRepository(context);
        var transferencia = new CriarTransferenciaDTO()
        {
            PagadorContaNumero = 1,
            BeneficiarioContaNumero = 2,
            Valor = valor
        };
        var transferir = new TransferenciaService(transRepo, contaRepo);

        //act
        //var result = await transferir.Executar(transferencia);

        //assert
        Assert.ThrowsAsync<Exception>(() => transferir.Executar(transferencia));
    }
}