using MvcWithDapper.Data;
using MvcWithDapper.Models;
using MvcWithDapper.Repositories.Interfaces;

namespace MvcWithDapper.Repositories;

public class BankTransferRepository : Repository<BankTransfer>, IBankTransferRepository
{
    private readonly DbSession _session;

    public BankTransferRepository(DbSession session) : base(session)
    {
        _session = session;
    }

    public Task<IEnumerable<BankTransfer>> GetByBankIdAsync(Guid bankId)
    {
        throw new NotImplementedException();
    }
}