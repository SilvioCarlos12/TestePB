using TestePB.Domain.Entity;

namespace TestePB.Domain.CasoDeUsos.Interfaces;

public interface ICriarCliente
{
    Task CriaCliente(string nomeTelefone, string email, IEnumerable<Contatos> contatos);
}