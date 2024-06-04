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
    
    private static ClienteValidador GetValidador=new ();
    public class ClienteValidador:AbstractValidator<Cliente>
    {
        public ClienteValidador()
        {
            RuleFor(x => x.NomeCompleto).NotEmpty();
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();
            
        }
    }


 
}