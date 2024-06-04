using FluentValidation;
using TestePB.Domain.Enum;

namespace TestePB.Domain.Entity;

public class Contatos:BaseEntidade<Guid>
{
    public string NumeroTelefone { get; private set; } = string.Empty;
    public TipoTelefone TipoTelefone { get; private set; }

    public Contatos()
    {
        
    }

    private Contatos(string numeroTelefone, TipoTelefone tipoTelefone)
    {
        NumeroTelefone = numeroTelefone;
        TipoTelefone = tipoTelefone;
    }

    public static Contatos Criar(string numeroTelefone, TipoTelefone tipoTelefone)
    {   
        var contatos = new Contatos(numeroTelefone, tipoTelefone);
        
        GetValidador.ValidateAndThrow(contatos);
        
        return contatos;
    }
    public static ContatosValidador GetValidador=new ();
    
    public class ContatosValidador:AbstractValidator<Contatos>
    {
        public ContatosValidador()
        {
            RuleFor(x => x.NumeroTelefone).NotEmpty();
            RuleFor(x => x.TipoTelefone).IsInEnum();
            
        }
    }
}