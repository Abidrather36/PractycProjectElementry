using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Practyc.Application.Abstraction.IRepository;
using Practyc.Domain.Entities;
using Practyc.Persistence.Data;
using System.Data;
using System.Linq.Expressions;
namespace Practyc.Persistence.Repository
{
    public class BaseRepository<T>:IBaseRepository<T> where T : BaseModel,new()
    {
        private readonly PractycDbContext context;


        #region Async Version
        public BaseRepository(PractycDbContext context)
        {
            this.context = context;
        }
        public async Task<int> InsertAsync(T model)
        {
           await context.Set<T>().AddAsync(model);
          return await context.SaveChangesAsync();
        }
        public async Task<int> DeleteAsync(Guid id)
        {
            var res = new T();
            res.Id = id;
            await Task.Run(()=> context.Set<T>().Remove(res));
            return await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> FindByAsync(Expression<Func<T, bool>> expression)
        {
         return await Task.Run(() => context.Set<T>().Where(expression));
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Task.Run(()=>context.Set<T>());
        }

        public async Task<T> GetById(Guid id)
        {
           return await context.Set<T>().FindAsync(id);
        }

       

        public async Task<bool> IsExists(Expression<Func<T, bool>> expression)
        {
          return await Task.Run(()=> context.Set<T>().Any(expression));
        }

        public async Task<int> UpdateAsync(T model)
        {
           await Task.Run(()=> context.Set<T>().Update(model));
           return await context.SaveChangesAsync();
        }

        public Task<int> DeleteRangeAsync(List<Guid> ids)
        {
            throw new NotImplementedException();
        }
        public async Task<T> FirstOrDeafault(Expression<Func<T, bool>> expression)
        {
            return await context.Set<T>().FirstOrDefaultAsync(expression);
        }
        public Task<int> DeleteRangeAsync(List<T> lists)
        {
            throw new NotImplementedException();
        }
        #endregion



        #region Dapper Version

      /*  public async Task<int> ExecuteAsync<T1>(string query, object? param=default, CommandType commandType = CommandType.Text, IDbTransaction? transaction = null)
        {
           return await  context.ExecuteAsyncDapperExtensionMethod<T1>(query, param, commandType,transaction);
        }

        public async Task<IEnumerable<T1>> QueryAsync<T1>(string query, object? param=default, CommandType commandType = CommandType.Text, IDbTransaction? transaction = null)
        {
           return await context.QueryAsyncDapperExtensionMethod<T1>(query,param, commandType,transaction);
        }

        public async Task<T1> FirstOrDefaultAsync<T1>(string query, object? param=default, CommandType commandType = CommandType.Text, IDbTransaction? transaction = null)
        {
            return await context.FirstOrDefaultAsyncDapperExtensionMethod<T1>(query, param, commandType, transaction);
        }

        public async Task<T1> SingleorDefaultAsync<T1>(string query, object? param=default, CommandType commandType = CommandType.Text, IDbTransaction? transaction = null)
        {
            return await context.SingleOrDefaultAsyncDapperExtensionMethod<T1>(query, param, commandType, transaction);
        }
*/
       

        #endregion
    }

    /*public static class DapperAsExtensionEfCore
    {

        public static async Task<IEnumerable<T>> QueryAsyncDapperExtensionMethod<T>(this PractycDbContext context, string query, object? param = default, CommandType commandType = CommandType.Text,
           IDbTransaction? transaction = null)
        {
            try
            {
                SqlConnection connection = new(context.Database.GetConnectionString());
                return await connection.QueryAsync<T>(query, param, transaction, null, commandType);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static async Task<int> ExecuteAsyncDapperExtensionMethod<T>(this PractycDbContext context ,string query,object ? param =default ,
            CommandType commandType=CommandType.Text,IDbTransaction? transaction=null)
        {
            try
            {
                SqlConnection connection = new (context.Database.GetConnectionString());
                return await connection.ExecuteAsync(query, param, transaction, null, commandType);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public static async Task<T?> SingleOrDefaultAsyncDapperExtensionMethod<T>(this PractycDbContext context ,string query ,object? param =default,
            CommandType commandType= CommandType.Text,IDbTransaction transaction=null)
        {
            try
            {
                SqlConnection connection = new(context.Database.GetConnectionString());
                return await connection.QuerySingleOrDefaultAsync<T>(query, param, transaction, null, commandType);
            }
            catch(Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }

        public static async Task<T?> FirstOrDefaultAsyncDapperExtensionMethod<T>(this PractycDbContext context, string query, object? param = default,
            CommandType commandType = CommandType.Text, IDbTransaction transaction = null)
        {
            try
            {
                SqlConnection connection = new(context.Database.GetConnectionString());
                return await connection.QueryFirstOrDefaultAsync<T>(query, param, transaction, null, commandType);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

       


    }*/

}
