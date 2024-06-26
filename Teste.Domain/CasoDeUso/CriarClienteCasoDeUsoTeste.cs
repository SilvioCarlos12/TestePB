using FluentValidation;
using NSubstitute;
using Shouldly;
using TestePB.Domain.CasoDeUsos;
using TestePB.Domain.Entity;
using TestePB.Domain.Enum;
using TestePB.Domain.Interfaces;
using Xunit;

namespace Teste.Domain.CasoDeUso;

public class CriarClienteCasoDeUsoTeste
{
    private readonly IClienteRepositorio _clienteRepositorio;

    public CriarClienteCasoDeUsoTeste()
    {
        _clienteRepositorio = Substitute.For<IClienteRepositorio>();
    }

    [Fact]

    public async Task CriandoClienteSemErro()
    {
        //arrange
        var email = "silvio.net.ma@gmail.com";
        var nome = "silvio";

        var telefone = "98987246527";
        var tipoDeTelefone = TipoTelefone.Celular;

        var telefoneFixo = "9832324242";
        var tipoDeTelefoneFixo = TipoTelefone.Fixo;

        var contatosTelefoneCelular = Contato.Criar(telefone, tipoDeTelefone);
        var contatosTelefoneFixo = Contato.Criar(telefoneFixo, tipoDeTelefoneFixo);

        var cliente = Cliente.Criar(nome, email, new List<Contato>()
        {
            contatosTelefoneCelular,
            contatosTelefoneFixo
        });
        
        //act
        var casoUso = new CriarClienteCasoDeUso(_clienteRepositorio);

        var resultado=await casoUso.CriaCliente(nome, email, new List<Contato>()
        {
            contatosTelefoneCelular,
            contatosTelefoneFixo
        },CancellationToken.None);
        //assert
       
      resultado.Contatos.ShouldBe(cliente.Contatos);
      resultado.NomeCompleto.ShouldBe(cliente.NomeCompleto);
      resultado.Email.ShouldBe(cliente.Email);
    }
    [Theory]
    [InlineData("plainaddress")]
    [InlineData("@no-local-part.com")]
    [InlineData("local-part.@domain.com")]
    [InlineData("local-part@-domain.com")]
    [InlineData("local-part@domain-.com")]
    [InlineData("")]

    public async Task CriandoClienteComErroDeEmaiInvalido( string email)
    {
        //arrange
        var nome = "silvio";

        var telefone = "98987246527";
        var tipoDeTelefone = TipoTelefone.Celular;

        var telefoneFixo = "9832324242";
        var tipoDeTelefoneFixo = TipoTelefone.Fixo;

        var contatosTelefoneCelular = Contato.Criar(telefone, tipoDeTelefone);
        var contatosTelefoneFixo = Contato.Criar(telefoneFixo, tipoDeTelefoneFixo);
        
        
        //act
        var casoUso = new CriarClienteCasoDeUso(_clienteRepositorio);

   
        //assert

        var result=await Should.ThrowAsync<ValidationException>(casoUso.CriaCliente(nome, email, new List<Contato>()
        {
            contatosTelefoneCelular,
            contatosTelefoneFixo
        },CancellationToken.None));
        
        result.Errors.ShouldContain(x=>x.ErrorMessage=="Email está Inválido");

    }
    [Theory]
    [InlineData("")]
    public async Task CriandoClienteComErroNomeEObrigatorio( string nome)
    {
        //arrange

        var email = "silvio.net.ma@gmail.com";
        var telefone = "98987246527";
        var tipoDeTelefone = TipoTelefone.Celular;

        var telefoneFixo = "9832324242";
        var tipoDeTelefoneFixo = TipoTelefone.Fixo;

        var contatosTelefoneCelular = Contato.Criar(telefone, tipoDeTelefone);
        var contatosTelefoneFixo = Contato.Criar(telefoneFixo, tipoDeTelefoneFixo);
        
        
        //act
        var casoUso = new CriarClienteCasoDeUso(_clienteRepositorio);

   
        //assert

        var result=await Should.ThrowAsync<ValidationException>(casoUso.CriaCliente(nome, email, new List<Contato>()
        {
            contatosTelefoneCelular,
            contatosTelefoneFixo
        },CancellationToken.None));
        
        result.Errors.ShouldContain(x=>x.ErrorMessage=="Campo obrigatário");

    }
    
    [Theory]
    [InlineData("098987246527898")]
    [InlineData("032987246527898")]
    [InlineData("000123456")]
    public async Task CriandoClienteComErroComNumeroDeTelefoneCelular(string telefoneCelular)
    {
        //arrange
        var tipoDeTelefone = TipoTelefone.Celular;
        
        //act

       var result= Should.Throw<ValidationException>(() => Contato.Criar(telefoneCelular, tipoDeTelefone));
   
        //assert
        result.Errors.ShouldContain(x=>x.ErrorMessage=="Telefone celular está inválido");
    }
    
    [Theory]
    [InlineData("098987246527898")]
    [InlineData("032987246527898")]
    [InlineData("000123456")]
    public async Task CriandoClienteComErroComNumeroDeTelefoneFixo(string telefoneFixo)
    {
        //arrange
        var tipoDeTelefone = TipoTelefone.Fixo;
        
        //act

        var result= Should.Throw<ValidationException>(() => Contato.Criar(telefoneFixo, tipoDeTelefone));
   
        //assert
        result.Errors.ShouldContain(x=>x.ErrorMessage=="Telefone Fixo está inválido");
    }
}