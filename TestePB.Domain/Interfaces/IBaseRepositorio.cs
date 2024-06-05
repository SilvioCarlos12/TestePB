using TestePB.Domain.Entity;

namespace TestePB.Domain.Interfaces;

public interface IBaseRepositorio<TEntity,TId> where TEntity:BaseEntidade<TId>
{
    Task Adicionar(TEntity entidade,CancellationToken cancellationToken);
    Task Deletar(TEntity entidade,CancellationToken cancellationToken);
    Task<IEnumerable<TEntity>> ObterTodos(CancellationToken cancellationToken);
    Task<TEntity?> ObterPorId(TId id,CancellationToken cancellationToken);
    Task Atualizar(TEntity entidade, CancellationToken cancellationToken);
}