using FuncionalHealthTechChallenge.GraphQL.GraphQLType;
using FuncionalHealthTechChallenge.Model;
using FuncionalHealthTechChallenge.Ropository.Interfaces;
using GraphQL;
using GraphQL.Types;

namespace FuncionalHealthTechChallenge.GraphQL.GraphQLQuery
{
    public class AppQuery : ObjectGraphType
    {
        public AppQuery(IAccontRepository accontRepository)
        {
            //Field<AccountType>("saldo").Resolve(context => accontRepository.Withdraw(1));
            Field<FloatGraphType>("saldo")
            .Arguments(new QueryArguments(
                new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "conta" }
            ))
            .Resolve(context =>
            {
                var contaId = context.GetArgument<int>("conta");
                return accontRepository.Balance(contaId);
            });
        }
    }
}
