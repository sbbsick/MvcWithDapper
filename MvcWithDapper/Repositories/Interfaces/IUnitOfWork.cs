namespace MvcWithDapper.Repositories.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IBankRepository BankRepository { get; }
    IBankTransferRepository BankTransferRepository { get; }
    IPaymentRepository PaymentRepository { get; }
    ICreditCardRepository CreditCardRepository { get; }

    void BeginTransaction();
    void Commit();
    void Rollback();
}