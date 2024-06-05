using TestePB.Domain.CasoDeUsos.Interfaces;
using TestePB.Domain.Entity;
using TestePB.Domain.Interfaces;

namespace TestePB.Domain.CasoDeUsos;

public class ObterClientePorTelefoneCasoDeUso:IObterClientePorTelefoneCasoDeUso
{
    private readonly IClienteRepositorio _clienteRepositorio;

    public ObterClientePorTelefoneCasoDeUso(IClienteRepositorio clienteRepositorio)
    {
        _clienteRepositorio = clienteRepositorio;
    }

    public async Task<Cliente?> ObterClientePorTelefone(string numeroTelefone,CancellationToken cancellationToken)
    {
        return await _clienteRepositorio.ObterClientePorTelefone(numeroTelefone, cancellationToken);
        
    }
}