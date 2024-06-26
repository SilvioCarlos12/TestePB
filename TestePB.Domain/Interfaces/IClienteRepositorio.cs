﻿using TestePB.Domain.Entity;

namespace TestePB.Domain.Interfaces;

public interface IClienteRepositorio:IBaseRepositorio<Cliente,Guid>
{
    Task<Cliente?> ObterClientePorTelefone(string numeroTelefone,CancellationToken cancellationToken);
}