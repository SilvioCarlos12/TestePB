using TestePB.Domain.Entity;

namespace TestePB.Domain.CasoDeUsos.Interfaces;

public interface ICriarClienteCasoDeUso
{
    Task<Cliente> CriaCliente(string nomeTelefone, 
        string email, 
        IEnumerable<Contato> contatos,
        CancellationToken cancellationToken);
}