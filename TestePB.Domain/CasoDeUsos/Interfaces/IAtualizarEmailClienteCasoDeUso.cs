using TestePB.Domain.Entity;

namespace TestePB.Domain.CasoDeUsos.Interfaces;

public interface IAtualizarEmailClienteCasoDeUso
{
    Task<Cliente?> AtualizarEmailDoCliente(Guid id, string email,CancellationToken cancellationToken);
}