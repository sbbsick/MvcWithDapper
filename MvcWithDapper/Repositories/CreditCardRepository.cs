using MvcWithDapper.Data;
using MvcWithDapper.Models;
using MvcWithDapper.Repositories.Interfaces;

namespace MvcWithDapper.Repositories;

public class CreditCardRepository : Repository<CreditCard>, ICreditCardRepository
{
    private readonly DbSession _session;

    public CreditCardRepository(DbSession session) : base(session)
    {
        _session = session;
    }
}