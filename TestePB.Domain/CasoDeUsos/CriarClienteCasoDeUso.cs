using TestePB.Domain.CasoDeUsos.Interfaces;
using TestePB.Domain.Entity;
using TestePB.Domain.Interfaces;

namespace TestePB.Domain.CasoDeUsos;

public class CriarClienteCasoDeUso:ICriarClienteCasoDeUso
{
    private readonly IClienteRepositorio _clienteRepositorio;

    public CriarClienteCasoDeUso(IClienteRepositorio clienteRepositorio)
    {
        _clienteRepositorio = clienteRepositorio;
    }

    public async Task<Cliente> CriaCliente(
        string nomeCompleto, 
        string email, 
        IEnumerable<Contato> contatos,
        CancellationToken cancellationToken)
    {

            var cliente = Cliente.Criar(nomeCompleto, email, contatos);
            await _clienteRepositorio.Adicionar(cliente,cancellationToken);
            return cliente;

    }
}