using TLbankEntities.Entities;

namespace TLbankRepositories.Interfaces;

public interface IUsuarioRepository
{
    public Task<UsuarioBase> BuscaPorAsync();
}