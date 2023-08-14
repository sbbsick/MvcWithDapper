using Microsoft.Data.SqlClient;
using System.Data;

namespace MvcWithDapper.Data;

public sealed class DbSession : IDisposable
{
    public IDbConnection Connection { get; }
    public IDbTransaction Transaction { get; set; }
    private IConfiguration Configuration { get; }

    public DbSession()
    {
        Configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        Connection = new SqlConnection(Configuration.GetConnectionString("DefaultConnection"));
        Connection.Open();
    }

    public void Dispose() => Connection?.Dispose();
}