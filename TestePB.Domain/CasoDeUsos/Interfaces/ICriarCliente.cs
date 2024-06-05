using TestePB.Domain.Entity;

namespace TestePB.Domain.CasoDeUsos.Interfaces;

public interface ICriarCliente
{
    Task<Cliente> CriaCliente(string nomeTelefone, string email, IEnumerable<Contatos> contatos);
}