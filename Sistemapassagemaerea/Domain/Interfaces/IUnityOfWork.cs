namespace Sistemapassagemaerea.Domain.Interfaces;

public interface IUnityOfWork
{
    Task SaveChangesAsync();
}
