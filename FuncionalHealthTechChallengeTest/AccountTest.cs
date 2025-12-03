using FuncionalHealthTechChallenge.Model;
using FuncionalHealthTechChallenge.Ropository;
using FuncionalHealthTechChallenge.Ropository.Interfaces;
using GraphQL;

namespace FuncionalHealthTechChallengeTest
{
    [TestClass]
    public class AccountTest
    {
        private IAccontService _accontRepository;
        [TestInitialize]
        public void AccountSetup()
        {
            _accontRepository = new AccountServiceTest();
        }
        [TestMethod]
        public void TestAccount()
        {
            int conta = 3;
            decimal balance = 0;
            var account = new Account { Id = conta, Balance = balance };

        }
        [TestMethod]
        public void Balance_whenSendAccount_thenReturnBalance()
        {
            int conta = 2;
            var balance = _accontRepository.Balance(conta);
            Assert.IsTrue(balance >= 0);
        }
        [TestMethod]
        public void Balance_whenSendInexistentAccount_thenThrowsExecutionError()
        {
            int conta = 5;
            Assert.ThrowsException<GraphQL.ExecutionError>(() => _accontRepository.Balance(conta));
        }
        [TestMethod]
        public void Deposit_whenDepositAnyValue_thenReturnNewBalance()
        {
            int conta = 4;
            decimal depositAmount = 100.00M;
            var account = new Account { Id = conta,Balance = depositAmount };
            var balance = _accontRepository.Balance(conta);
            var newAccount = _accontRepository.Deposit(account);
            Assert.IsTrue(balance+depositAmount == newAccount.Balance);
        }
        [TestMethod]
        public void Deposit_whenNegativeValue_thenThrowsExecutionError()
        {
            int conta = 4;
            decimal depositAmount = -100.00M;
            var account = new Account { Id = conta, Balance = depositAmount };
            Assert.ThrowsException<GraphQL.ExecutionError>(() => _accontRepository.Deposit(account));
        }
        [TestMethod]
        public void Deposit_whenInexistentAccount_thenThrowsExecutionError()
        {
            int conta = 40;
            decimal depositAmount = 100.00M;
            var account = new Account { Id = conta, Balance = depositAmount };
            Assert.ThrowsException<GraphQL.ExecutionError>(() => _accontRepository.Deposit(account));
        }
        [TestMethod]
        public void Withdraw_whenWithdrawJustTheBalance_thenReturnNewBalance()
        {
            int conta = 1;
            decimal withdrawAmount = 100.00M;
            var account = new Account { Id = conta, Balance = withdrawAmount };
            var balance = _accontRepository.Balance(conta);
            Assert.IsTrue(balance - withdrawAmount == _accontRepository.Withdraw(account).Balance);
        }
        [TestMethod]
        public void Withdraw_whenWithdrawInexistentAccount_thenThrowsExecutionError()
        {
            int conta = 10;
            decimal withdrawAmount = 100.00M;
            var account = new Account { Id = conta, Balance = withdrawAmount };
            Assert.ThrowsException<GraphQL.ExecutionError>(() => _accontRepository.Withdraw(account));
        }
        [TestMethod]
        public void Withdraw_whenWithdrawMoreThanBalance_thenThrowsExecutionError()
        {
            int conta = 3;
            decimal withdrawAmount = 100.00M;
            var account = new Account { Id = conta, Balance = withdrawAmount };
            Assert.ThrowsException<GraphQL.ExecutionError>(() => _accontRepository.Withdraw(account));
        }
        [TestMethod]
        public void Withdraw_whenWithdrawNegativeBalance_thenThrowsExecutionError()
        {
            int conta = 3;
            decimal withdrawAmount = -100.00M;
            var account = new Account { Id = conta, Balance = withdrawAmount };
            Assert.ThrowsException<GraphQL.ExecutionError>(() => _accontRepository.Withdraw(account));
        }
    }
}