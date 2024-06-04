using TestePB.Domain.CasoDeUsos.Interfaces;
using TestePB.Domain.Entity;
using TestePB.Domain.Interfaces;

namespace TestePB.Domain.CasoDeUsos;

public class CriarCliente:ICriarCliente
{
    private readonly IClienteRepositorio _clienteRepositorio;

    public CriarCliente(IClienteRepositorio clienteRepositorio)
    {
        _clienteRepositorio = clienteRepositorio;
    }

    public async Task CriaCliente(string nomeTelefone, string email, IEnumerable<Contatos> contatos)
    {
        var cliente = Cliente.Criar(nomeTelefone, email, contatos);

        await _clienteRepositorio.Adicionar(cliente);

    }
}