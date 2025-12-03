using GraphQL.Types;

namespace FuncionalHealthTechChallenge.GraphQL.GraphQLType
{
    public class AccountOutputType : ObjectGraphType
    {
        public AccountOutputType()
        {
            Name = "AccountInput";
            Description = "Objeto de entrada da conta";

            Field<NonNullGraphType<IntGraphType>>("conta");
            Field<NonNullGraphType<FloatGraphType>>("saldo");
        }
    }
}
