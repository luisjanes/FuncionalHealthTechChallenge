using FuncionalHealthTechChallenge.Data;
using FuncionalHealthTechChallenge.GraphQL.GraphQLQuery;
using FuncionalHealthTechChallenge.GraphQL.GraphQLScheme;
using FuncionalHealthTechChallenge.GraphQL.GraphQLType;
using FuncionalHealthTechChallenge.Ropository;
using FuncionalHealthTechChallenge.Ropository.Interfaces;
using GraphQL;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<FuncionalHealthDataContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<IAccontRepository, AccountRepository>();
builder.Services.AddScoped<AppQuery>();
builder.Services.AddScoped<AppScheme>();
builder.Services.AddScoped<AppMutation>();
builder.Services.AddScoped<AccountType>();
builder.Services.AddScoped<AccountOutputType>();
builder.Services.AddGraphQL(b =>
{
    b.AddSchema<AppScheme>(GraphQL.DI.ServiceLifetime.Scoped);
    b.AddSystemTextJson();
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<FuncionalHealthDataContext>();
    db.Database.Migrate();
}
app.MapControllers();
app.UseGraphQL<AppScheme>();
app.UseGraphQLPlayground();

app.Run();
