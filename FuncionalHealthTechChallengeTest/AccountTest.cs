using FuncionalHealthTechChallenge.Model;
using FuncionalHealthTechChallenge.Ropository;
using FuncionalHealthTechChallenge.Ropository.Interfaces;
using GraphQL;

namespace FuncionalHealthTechChallengeTest
{
    [TestClass]
    public class AccountTest
    {
        private readonly IAccontRepository _accontRepository;
        public AccountTest()
        {
            _accontRepository = new AccountRepositoryTest();
        }
        [TestMethod]
        public void TestAccount()
        {
            int conta = 3;
            double balance = 0;
            var account = new Account { Id = conta, Balance = balance };

        }
        [TestMethod]
        public void TestBalance()
        {
            for (int i = 1; i <= 4; i++)
            {
                int conta = i;
                var balance = _accontRepository.Balance(conta);
                Assert.IsTrue(balance >= 0);
            }
        }
        [TestMethod]
        public void TestDeposit()
        {
            for (int i = 1; i <= 4; i++) {
                int conta = i;
                double depositAmount = 100.00;
                var account = new Account { Id = conta,Balance = depositAmount };
                var balance = _accontRepository.Balance(conta);
                var newAccount = _accontRepository.Deposit(account);
                Assert.IsTrue(balance+depositAmount == newAccount.Balance);
            }
        }
        [TestMethod]
        public void TestWithdraw()
        {
            for (int i = 1; i <= 4; i++)
            {
                int conta = i;
                double withdrawAmount = 100.00;
                var account = new Account { Id = conta, Balance = withdrawAmount };
                var balance = _accontRepository.Balance(conta);
                if(balance < withdrawAmount)
                {
                    Assert.ThrowsException<GraphQL.ExecutionError>(() => _accontRepository.Withdraw(account));
                }
                else
                {
                    Assert.IsTrue(balance - withdrawAmount == _accontRepository.Withdraw(account).Balance);
                }
                
            }
        }
    }
}