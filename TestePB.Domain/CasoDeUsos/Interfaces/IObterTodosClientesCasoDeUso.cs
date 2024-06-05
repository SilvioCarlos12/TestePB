using TestePB.Domain.Entity;

namespace TestePB.Domain.CasoDeUsos.Interfaces;

public interface IObterTodosClientesCasoDeUso
{
 Task<IEnumerable<Cliente>> ObterTodosClientes(CancellationToken cancellationToken);
}