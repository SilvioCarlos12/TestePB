using TestePB.Domain.Entity;

namespace TestePB.Domain.CasoDeUsos.Interfaces;

public interface IObterClientePorTelefoneCasoDeUso
{
    Task<Cliente?> ObterClientePorTelefone(string numeroTelefone,CancellationToken cancellationToken);
}