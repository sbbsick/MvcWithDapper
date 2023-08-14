using MvcWithDapper.Data;
using MvcWithDapper.Repositories.Interfaces;

namespace MvcWithDapper.Repositories;

public sealed class UnitOfWork : IUnitOfWork
{
    private readonly DbSession _session;

    private IBankRepository _bankRepository;
    private IBankTransferRepository _bankTransferRepository;
    private IPaymentRepository _paymentRepository;
    private ICreditCardRepository _creditCardRepository;

    public UnitOfWork(DbSession session)
    {
        _session = session;
    }

    public IBankRepository BankRepository
    {
        get
        {
            _bankRepository ??= new BankRepository(_session);
            return _bankRepository;
        }
    }

    public IBankTransferRepository BankTransferRepository
    {
        get
        {
            _bankTransferRepository ??= new BankTransferRepository(_session);
            return _bankTransferRepository;
        }
    }

    public IPaymentRepository PaymentRepository
    {
        get
        {
            _paymentRepository ??= new PaymentRepository(_session);
            return _paymentRepository;
        }
    }

    public ICreditCardRepository CreditCardRepository
    {
        get
        {
            _creditCardRepository ??= new CreditCardRepository(_session);
            return _creditCardRepository;
        }
    }

    public void BeginTransaction()
    {
        _session.Transaction = _session.Connection.BeginTransaction();
    }

    public void Commit()
    {
        _session.Transaction.Commit();
        Dispose();
    }

    public void Rollback()
    {
        _session.Transaction.Rollback();
        Dispose();
    }

    public void Dispose() => _session.Transaction?.Dispose();
}