using Dapper;
using MvcWithDapper.Data;
using MvcWithDapper.Repositories.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcWithDapper.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly DbSession _session;

    protected Repository(DbSession session)
    {
        _session = session;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        var tableName = GetTableName<T>();
        return await _session.Connection.QueryAsync<T>($"SELECT * FROM {tableName}");
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
        var tableName = GetTableName<T>();
        var sql = $"SELECT * FROM {tableName} WHERE Id = @Id";
        return await _session.Connection.QueryFirstOrDefaultAsync<T>(sql, new { Id = id });
    }

    public Task<T> AddAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public Task<T> UpdateAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public Task<T> DeleteAsync(T entity)
    {
        throw new NotImplementedException();
    }

    //Pega o nome das minhas tabelas, lembrando que o nome da tabela é o nome da classe
    private string GetTableName<T>()
    {
        var type = typeof(T);

        if (type.GetCustomAttributes(typeof(TableAttribute), true)
                .FirstOrDefault() is TableAttribute attribute)
        {
            return attribute.Name;
        }

        throw new InvalidOperationException($"TableAttribute not found on type {type.Name}");
    }

    //Pega o nome das minhas colunas, lembrando que o nome da coluna é o nome da propriedade
    private string GetColumns(object entity)
    {
        var properties = entity.GetType().GetProperties();
        return string.Join(", ", properties.Select(p => p.Name));
    }
}