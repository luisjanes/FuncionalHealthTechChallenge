using FuncionalHealthTechChallenge.GraphQL.GraphQLQuery;
using GraphQL;
using GraphQL.Types;

namespace FuncionalHealthTechChallenge.GraphQL.GraphQLScheme
{
    public class AppScheme : Schema
    {
        public AppScheme(IServiceProvider provider, AppQuery appQuery) : base(provider) 
        {
            Query = appQuery;
        }
    }
}
