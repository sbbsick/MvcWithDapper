using MvcWithDapper.Data;
using MvcWithDapper.Models;
using MvcWithDapper.Repositories.Interfaces;

namespace MvcWithDapper.Repositories;

public class PaymentRepository : Repository<Payment>, IPaymentRepository
{
    private readonly DbSession _session;

    public PaymentRepository(DbSession session) : base(session)
    {
        _session = session;
    }
}