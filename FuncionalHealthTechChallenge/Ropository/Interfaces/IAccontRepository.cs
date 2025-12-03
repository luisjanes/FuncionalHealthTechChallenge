using FuncionalHealthTechChallenge.Model;

namespace FuncionalHealthTechChallenge.Ropository.Interfaces
{
    public interface IAccontRepository
    {
        public double Balance(int Id);

        public Account Withdraw(Account account);
        public Account Deposit(Account account);

    }
}
