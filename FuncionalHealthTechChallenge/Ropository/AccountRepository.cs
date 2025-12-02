using FuncionalHealthTechChallenge.Data;
using FuncionalHealthTechChallenge.Model;
using FuncionalHealthTechChallenge.Ropository.Interfaces;

namespace FuncionalHealthTechChallenge.Ropository
{
    public class AccountRepository : IAccontRepository
    {
        private readonly FuncionalHealthDataContext _context;
        public AccountRepository(FuncionalHealthDataContext funcionalHealthDataContext)
        {
            _context = funcionalHealthDataContext;
        }
        public double Withdraw(int Id)
        {
            return _context.Accounts
             .Where(a => a.Id == Id)
             .Select(a => a.Balance)
             .FirstOrDefault();
        }
    }
}
