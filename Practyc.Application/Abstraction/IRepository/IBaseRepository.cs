using Practyc.Domain.Entities;
using System.Data;
using System.Linq.Expressions;

namespace Practyc.Application.Abstraction.IRepository
{
    public interface IBaseRepository<T> where T : BaseModel,new()
    {
        #region async versions
        Task<int> InsertAsync(T model);

        Task<int> UpdateAsync(T model);

        Task<int> DeleteAsync(Guid id);

        Task <IEnumerable<T>> GetAllAsync();


        Task<T> GetById(Guid id);

        Task<int> DeleteRangeAsync(List<Guid> ids);


        Task<int> DeleteRangeAsync(List<T> lists);

        Task<IEnumerable<T>> FindByAsync(Expression<Func<T,bool>> expression);


        Task <bool> IsExists(Expression<Func<T,bool>> expression);


        Task<T> FirstOrDeafault(Expression<Func<T, bool>> expression);

        #endregion


        #region Dapper Version

       /*  Task<int> ExecuteAsync<T>(string query, object? param, CommandType commandType = CommandType.Text, IDbTransaction? transaction = null);


         Task<IEnumerable<T?>> QueryAsync<T>(string query,object? param ,CommandType commandType=CommandType.Text,IDbTransaction? transaction = null);


         Task<T?> FirstOrDefaultAsync<T>(string query, object? param, CommandType commandType = CommandType.Text, IDbTransaction? transaction = null);


         Task<T?> SingleorDefaultAsync<T>(string query, object? param, CommandType commandType = CommandType.Text, IDbTransaction? transaction = null);*/










        #endregion
    }
}
