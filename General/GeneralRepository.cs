using System.Linq.Expressions;

namespace ativa_recife.General;

public interface GeneralRepository<T>
{
    Task<T> Create(T entity);
    Task<T> Update(T entity); 
    Task<T> Delete(T entity);

    Task<T> GetEventByTitle(T entity);
}