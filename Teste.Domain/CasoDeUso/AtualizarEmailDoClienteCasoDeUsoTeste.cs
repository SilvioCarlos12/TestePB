using FluentValidation;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Shouldly;
using Teste.Domain.Build;
using TestePB.Domain.CasoDeUsos;
using TestePB.Domain.Interfaces;
using Xunit;

namespace Teste.Domain.CasoDeUso;

public class AtualizarEmailDoClienteCasoDeUsoTeste
{
    private readonly IClienteRepositorio _clienteRepositorio;
    
    public AtualizarEmailDoClienteCasoDeUsoTeste()
    {
        _clienteRepositorio = Substitute.For<IClienteRepositorio>();
    }

    [Fact]

    public async Task AtualizarEmailDeUmCliente()
    {
        //Arrange
        var cliente = new ClienteBuild().Build();

        _clienteRepositorio.ObterPorId(Arg.Any<Guid>(), CancellationToken.None).Returns(cliente);

        var email = "silvio.net.ma@gmail.com";
        
        //Act

        var casoDeUso = new AtualizarEmailDoClienteCasoDeUso(_clienteRepositorio);

        var resultado=await casoDeUso.AtualizarEmailDoCliente(Guid.NewGuid(), email, CancellationToken.None);
        
        //Assert
        
        resultado!.Email.ShouldBe(email);


    }
    
    
    [Fact]

    public async Task NaoFoiEncontradoClienteParaAtualizarCliente()
    {
        //Arrange

        _clienteRepositorio.ObterPorId(Arg.Any<Guid>(), CancellationToken.None).ReturnsNull();

        var email = "silvio.net.ma@gmail.com";
        
        //Act

        var casoDeUso = new AtualizarEmailDoClienteCasoDeUso(_clienteRepositorio);

        var resultado=await casoDeUso.AtualizarEmailDoCliente(Guid.NewGuid(), email, CancellationToken.None);
        
        //Assert
        
        resultado.ShouldBe(null);
    }
    
    [Fact]

    public async Task NaoFoiPossuiAtualizarEmailDeUmClientePosEstaInvalido()
    {
        //Arrange
        var cliente = new ClienteBuild().Build();

        _clienteRepositorio.ObterPorId(Arg.Any<Guid>(), CancellationToken.None).Returns(cliente);

        var email = "silvio.net.magmail.com";
        
        //Act

        var casoDeUso = new AtualizarEmailDoClienteCasoDeUso(_clienteRepositorio);

        var resultado =
            await Should.ThrowAsync<ValidationException>(
                casoDeUso.AtualizarEmailDoCliente(Guid.NewGuid(), email, CancellationToken.None));
        
        //Assert
        
        resultado.Errors.ShouldContain(x=>x.ErrorMessage=="Email está Inválido");


    }
    
}