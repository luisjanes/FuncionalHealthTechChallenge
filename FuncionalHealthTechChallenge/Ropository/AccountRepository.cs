using FuncionalHealthTechChallenge.Data;
using FuncionalHealthTechChallenge.Model;
using FuncionalHealthTechChallenge.Ropository.Interfaces;
using GraphQL;

namespace FuncionalHealthTechChallenge.Ropository
{
    public class AccountRepository : IAccontRepository
    {
        private readonly FuncionalHealthDataContext _context;
        public AccountRepository(FuncionalHealthDataContext funcionalHealthDataContext)
        {
            _context = funcionalHealthDataContext;
        }
        public double Balance(int Id)
        {
            var balance = _context.Accounts
             .Where(a => a.Id == Id)
             .FirstOrDefault();
            if(balance != null)
            {
                return balance.Balance;
            }
            throw new ExecutionError("Conta não existe");
        }

        public Account Deposit(Account account)
        {
            var accountData = _context.Accounts.Where(a => a.Id == account.Id).FirstOrDefault();
            if (accountData != null)
            {
                accountData.Balance = (accountData.Balance)+(account.Balance);
                _context.Accounts.Update(accountData);
                _context.SaveChanges();
                var accountNew = _context.Accounts.Where(a => a.Id == account.Id).FirstOrDefault();
                return accountNew;
            }
            else
            {
                throw new ExecutionError("Conta não existe");
            }
        }

        public Account Withdraw(Account account)
        {
            if (account.Balance <= 0)
            {
                throw new ExecutionError("Valor precisa ser maior que zero");
            }
            var accountData = _context.Accounts.Where(a => a.Id == account.Id).FirstOrDefault();
            
            if (accountData != null) 
            {
                var leftBalance = accountData.Balance - account.Balance;
                if (leftBalance>=0)
                {
                    accountData.Balance = leftBalance;
                    _context.Accounts.Update(accountData);
                    _context.SaveChanges();
                    return accountData;
                }
                throw new ExecutionError("Saldo insuficiente");
            } 
            else
            {
                throw new ExecutionError("Conta não existe");
            }
        }
    }
}
