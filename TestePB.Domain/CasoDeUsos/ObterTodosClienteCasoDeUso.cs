using TestePB.Domain.CasoDeUsos.Interfaces;
using TestePB.Domain.Entity;
using TestePB.Domain.Interfaces;

namespace TestePB.Domain.CasoDeUsos;

public class ObterTodosClienteCasoDeUso:IObterTodosClientesCasoDeUso
{
    private readonly IClienteRepositorio _clienteRepositorio;

    public ObterTodosClienteCasoDeUso(IClienteRepositorio clienteRepositorio)
    {
        _clienteRepositorio = clienteRepositorio;
    }

    public async Task<IEnumerable<Cliente>> ObterTodosClientes(CancellationToken cancellationToken)
    {
        return await _clienteRepositorio.ObterTodos(cancellationToken);
    }
}