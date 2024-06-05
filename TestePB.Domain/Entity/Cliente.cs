using System.Text.RegularExpressions;
using FluentValidation;

namespace TestePB.Domain.Entity;

public class Cliente:BaseEntidade<Guid>
{

    public string NomeCompleto { get; private set; }
    public string Email { get; private set; }
    public IEnumerable<Contatos> Contatos { get; private set; }



    private Cliente(string nomeCompleto,string email,IEnumerable<Contatos> contatos) : base()
    {
        NomeCompleto = nomeCompleto;
        Email = email;
        Contatos = contatos;
    }


    public static Cliente Criar(string nomeCompleto, string email, IEnumerable<Contatos> contatos)
    {
        var cliente = new Cliente(nomeCompleto, email, contatos);
        GetValidador.ValidateAndThrow(cliente);
        return cliente;
    }
    
    private static readonly ClienteValidador GetValidador=new ();
    public class ClienteValidador:AbstractValidator<Cliente>
    {
        public ClienteValidador()
        {
            var regexValidarEmail = new Regex("^[a-zA-Z0-9._%+-]+(?<!\\.)@[a-zA-Z0-9]" +
                                              "(?:[a-zA-Z0-9-]*[a-zA-Z0-9])?(?:\\.[a-zA-Z0-9](?:[a-zA-Z0-9-]*[a-zA-Z0-9])?)*\\.[a-zA-Z]{2,}$");
            
            RuleFor(x => x.NomeCompleto)
                .MaximumLength(300)
                .WithMessage("Passou de 300 caracteres")
                .NotEmpty()
                .WithMessage("Campo obrigatário");
            RuleFor(x => x.Email)
                .Matches(regexValidarEmail)
                .WithMessage("Email está Inválido");
            
        }
    }


 
}