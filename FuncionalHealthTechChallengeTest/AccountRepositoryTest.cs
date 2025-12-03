using FuncionalHealthTechChallenge.Model;
using FuncionalHealthTechChallenge.Ropository.Interfaces;
using GraphQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncionalHealthTechChallengeTest
{
    internal class AccountRepositoryTest : IAccontRepository
    {
        private readonly List<Account> accounts;
        public AccountRepositoryTest()
        {
            accounts = new List<Account>()
            {
                new(){Id = 1, Balance = 100.00},
                new(){Id = 2, Balance = 1000.00},
                new(){Id = 3, Balance = 0.00},
                new(){Id = 4, Balance = 1.00}
            };
            
        }
        public double Balance(int Id)
        {
            var balance = accounts
             .Where(a => a.Id == Id)
             .FirstOrDefault();
            if (balance != null)
            {
                return balance.Balance;
            }
            throw new ExecutionError("Conta não existe");
        }

        public Account Deposit(Account account)
        {
            var accountData = accounts.Where(a => a.Id == account.Id).FirstOrDefault();
            if (accountData != null)
            {
                accountData.Balance = (accountData.Balance) + (account.Balance);
                accounts[accounts.FindIndex(a => a.Id == account.Id)].Balance=accountData.Balance;
                var accountNew = accounts.Where(a => a.Id == account.Id).FirstOrDefault();
                return accountNew;
            }
            else
            {
                throw new ExecutionError("Conta não existe");
            }
        }

        public Account Withdraw(Account account)
        {
            var accountData = accounts.Where(a => a.Id == account.Id).FirstOrDefault();

            if (accountData != null)
            {
                var leftBalance = accountData.Balance - account.Balance;
                if (leftBalance >= 0)
                {
                    accountData.Balance = leftBalance;
                    accounts[accounts.FindIndex(a => a.Id == account.Id)].Balance=accountData.Balance;
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
