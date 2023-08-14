using MvcWithDapper.Models;

namespace MvcWithDapper.Repositories.Interfaces;

public interface IBankTransferRepository : IRepository<BankTransfer>
{
    Task<IEnumerable<BankTransfer>> GetByBankIdAsync(Guid bankId);
}