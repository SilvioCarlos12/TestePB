using TestePB.Domain.Entity;

namespace TestePB.Domain.Interfaces;

public interface IBaseRepositorio<TEntity,TId> where TEntity:BaseEntidade<TId>
{
    Task Adicionar(TEntity entity);
    Task Deletar(TEntity entity);
    Task<IEnumerable<TEntity>> ObterTodos();
    Task<TEntity> ObterPorId(TId id);
}