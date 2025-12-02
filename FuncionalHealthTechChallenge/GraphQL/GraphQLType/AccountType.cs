using FuncionalHealthTechChallenge.Model;
using GraphQL.Types;

namespace FuncionalHealthTechChallenge.GraphQL.GraphQLType
{
    public class AccountType : ObjectGraphType<Account>
    {
        public AccountType()
        {
            Field(x=>x.Id, type:typeof(IdGraphType)).Description("Id da conta");
            Field(x=>x.Balance, type:typeof(DecimalGraphType)).Description("Saldo da conta");
        }
    }
}
