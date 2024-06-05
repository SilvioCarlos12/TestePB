using TestePB.Domain.CasoDeUsos.Interfaces;
using TestePB.Domain.Entity;
using TestePB.Domain.Interfaces;

namespace TestePB.Domain.CasoDeUsos;

public class AtualizarEmailDoClienteCasoDeUso:IAtualizarEmailClienteCasoDeUso
{
    private readonly IClienteRepositorio _clienteRepositorio;

    public AtualizarEmailDoClienteCasoDeUso(IClienteRepositorio clienteRepositorio)
    {
        _clienteRepositorio = clienteRepositorio;
    }

    public async Task<Cliente?> AtualizarEmailDoCliente(Guid id, string email,CancellationToken cancellationToken)
    {
        var cliente = await _clienteRepositorio.ObterPorId(id, cancellationToken);

        if (cliente is null)
            return null;
        
        cliente.AtualizarEmailDoCliente(email);
        
        return cliente;
    }
}