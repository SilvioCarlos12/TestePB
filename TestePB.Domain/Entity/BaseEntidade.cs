namespace TestePB.Domain.Entity;

public abstract class BaseEntidade<TId>
{


    protected virtual TId? Id { get; set; }
}