namespace SmellIt.Domain.Interfaces.Abstract;

public interface IRepository
{
    Task CommitAsync();
}