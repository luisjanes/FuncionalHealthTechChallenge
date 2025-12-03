using FuncionalHealthTechChallenge.GraphQL.GraphQLType;
using FuncionalHealthTechChallenge.Model;
using FuncionalHealthTechChallenge.Ropository;
using FuncionalHealthTechChallenge.Ropository.Interfaces;
using GraphQL;
using GraphQL.Types;

namespace FuncionalHealthTechChallenge.GraphQL.GraphQLQuery
{
    public class AppMutation : ObjectGraphType
    {
        public AppMutation(IAccontRepository accontRepository)
        {
            Field<AccountOutputType>("sacar")
            .Arguments(new QueryArguments(
                new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "conta" },
                new QueryArgument<NonNullGraphType<FloatGraphType>> { Name = "valor" }
            ))
            .Resolve(context =>
            {
                var contaId = context.GetArgument<int>("conta");
                var valor = context.GetArgument<double>("valor");
                var account = new Account { Id = contaId, Balance = valor };
                var accountBalance = accontRepository.Withdraw(account);
                return new
                {
                    conta = accountBalance.Id,
                    saldo = accountBalance.Balance
                };
            });

            Field<AccountOutputType>("depositar")
            .Arguments(new QueryArguments(
                new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "conta" },
                new QueryArgument<NonNullGraphType<FloatGraphType>> { Name = "valor" }
            ))
            .Resolve(context =>
            {
                var contaId = context.GetArgument<int>("conta");
                var valor = context.GetArgument<double>("valor");
                var account = new Account { Id = contaId, Balance = valor };

                var accountBalance = accontRepository.Deposit(account);
                return new
                {
                    conta = accountBalance.Id,
                    saldo = accountBalance.Balance
                };
            });
        }
    }
}
