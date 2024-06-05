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

    public async Task<Cliente> CriaCliente(string nomeCompleto, string email, IEnumerable<Contatos> contatos)
    {

        try
        {
            var cliente = Cliente.Criar(nomeCompleto, email, contatos);
            await _clienteRepositorio.Adicionar(cliente);
            return cliente;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

    }
}