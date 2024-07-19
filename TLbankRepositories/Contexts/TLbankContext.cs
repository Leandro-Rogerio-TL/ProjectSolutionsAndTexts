using Microsoft.EntityFrameworkCore;

using TLbankEntities.Entities;

namespace TLbankRepositories.Contexts;

public class TLbankContext: DbContext
{
    public TLbankContext(DbContextOptions<TLbankContext> opts) : base(opts)
    {

    }
    public DbSet<UsuarioBase> Usuarios { get; set; }
    public DbSet<UsuarioPJ> UsuariosPJ { get; set; }
    public DbSet<UsuarioPF> UsuariosPF { get; set; }
    public DbSet<ContaBase> Contas { get; set; }
    public DbSet<ContaComum> ContasComum { get; set; }
    public DbSet<ContaLogista> ContasLigista { get; set; }
    public DbSet<Transferencia> Transferencias { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<UsuarioBase>()
               .HasDiscriminator<string>("Tipo")
               .IsComplete(true);

        builder.Entity<UsuarioPF>().Property(u => u.NomeCompleto).HasColumnName("Nome");
        builder.Entity<UsuarioPF>().Property(u => u.CPF).HasColumnName("Documento");
        builder.Entity<UsuarioPJ>().Property(u => u.RazaoSocial).HasColumnName("Nome");
        builder.Entity<UsuarioPJ>().Property(u => u.CNPJ).HasColumnName("Documento");

        builder.Entity<ContaBase>()
               .HasDiscriminator<string>("Tipo")
               .HasValue<ContaComum>("Comum")
               .HasValue<ContaLogista>("Logista")
               .IsComplete(true);
        
        builder.Entity<Transferencia>().HasOne(t => t.BeneficiarioConta).WithMany(t => t.TransacaoCredito);
        builder.Entity<Transferencia>().Navigation<ContaBase>(t => t.BeneficiarioConta).AutoInclude();
        builder.Entity<Transferencia>().HasOne(t => t.PagadorConta).WithMany(t => t.TransacaoDebito);
        builder.Entity<Transferencia>().Navigation<ContaBase>(t => t.PagadorConta).AutoInclude();

        builder.Entity<ContaBase>().Navigation<UsuarioBase>(t => t.Usuario).AutoInclude();
    }
}