﻿using System.Text.RegularExpressions;
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
    private static readonly ContatosValidador GetValidador=new ();
    
    public class ContatosValidador:AbstractValidator<Contatos>
    {
        public ContatosValidador()
        {
            RuleFor(x => x.NumeroTelefone).NotEmpty();
            RuleFor(x => x.TipoTelefone).IsInEnum();
            When(x => x.TipoTelefone == TipoTelefone.Celular, () =>
            {
                var regexTelefoneCelular = new Regex("^0?[1-9]{2}9[0-9]{7,8}$");
                RuleFor(x => x.NumeroTelefone)
                    
                    .Matches(regexTelefoneCelular)
                    .WithMessage("Telefone celular está inválido");
            });
            When(x => x.TipoTelefone == TipoTelefone.Fixo, () =>
            {
                var regexTelefoneFixo = new Regex("^0?[1-9]{2}[2-5][0-9]{7}$");
                RuleFor(x => x.NumeroTelefone)
                    .Matches(regexTelefoneFixo)
                    .WithMessage("Telefone Fixo está inválido");
            });
        }
    }
}