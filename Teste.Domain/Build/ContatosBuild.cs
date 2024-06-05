using TestePB.Domain.Entity;
using TestePB.Domain.Enum;

namespace Teste.Domain.Build;

public class ContatosBuild
{
    private string _numeroTelefone = "98987246527";
    private TipoTelefone _tipoTelefone = TipoTelefone.Celular;

    public ContatosBuild()
    {
        
    }

    public ContatosBuild ComNumeroTelefone(string numeroTelefone)
    {
        _numeroTelefone = numeroTelefone;

        return this;
    }

    public ContatosBuild ComTipoTelefone(TipoTelefone tipoTelefone)
    {
        _tipoTelefone = tipoTelefone;
        return this;
    }

    public Contato Build()
    {
        return Contato.Criar(_numeroTelefone, _tipoTelefone);
    }
}