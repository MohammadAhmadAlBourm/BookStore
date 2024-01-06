using BookStore.Endpoints;
using BookStore.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.RegisterServices();

var app = builder.Build();

app.RegisterMiddlewares();
app.RegisterBookEndpoints();
app.Run();