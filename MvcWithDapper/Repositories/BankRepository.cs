using MvcWithDapper.Data;
using MvcWithDapper.Models;
using MvcWithDapper.Repositories.Interfaces;

namespace MvcWithDapper.Repositories;

public class BankRepository : Repository<Bank>, IBankRepository
{
    private readonly DbSession _session;

    public BankRepository(DbSession session) : base(session)
    {
        _session = session;
    }
}