using TestePB.Domain.Entity;
using TestePB.Domain.Enum;

namespace Teste.Domain.Build;

public class ClienteBuild
{

    private string _email = "silvio.net.ma@gmail.com";
    private string _nomeCompleto = "Silvio Carlos";

    private IEnumerable<Contato> _contatos = new List<Contato>()
    {
        new ContatosBuild().Build(),
        new ContatosBuild()
            .ComTipoTelefone(TipoTelefone.Fixo)
            .ComNumeroTelefone("9832324555")
            .Build()
    };

    public ClienteBuild()
    {
        
    }

    public ClienteBuild ComEmail(string email)
    {
        _email = email;
        return this;
    }
    
    public ClienteBuild ComNomeCompleto(string nomeCompleto)
    {
        _nomeCompleto = nomeCompleto;
        return this;
    }
    
    public ClienteBuild ComContatos(IEnumerable<Contato> contatos)
    {
        _contatos = contatos;
        return this;
    }

    public Cliente Build()
    {
        return Cliente.Criar(_nomeCompleto, _email, _contatos);
    }

}