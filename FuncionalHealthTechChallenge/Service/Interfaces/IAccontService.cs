using FuncionalHealthTechChallenge.Model;

namespace FuncionalHealthTechChallenge.Ropository.Interfaces
{
    public interface IAccontService
    {
        public decimal Balance(int Id);
        public Account Withdraw(Account account);
        public Account Deposit(Account account);

    }
}
