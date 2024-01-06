using BookStore.Data;
using BookStore.Repositories;
using BookStore.Repositories.Implementation;
using BookStore.Services;
using BookStore.Services.Implementation;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Reflection;

namespace BookStore.Extensions;

public static class RegisterServicesConfiguration
{
    public static void RegisterServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<BookStoreContext>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("BookStore"));
        });

        builder.Services
            .AddEndpointsApiExplorer()
            .AddSwaggerGen();

        builder.Host.UseSerilog((context, configuration) =>
        {
            configuration.ReadFrom.Configuration(context.Configuration);
        });

        builder.Services.AddScoped<IBookService, BookService>();
        builder.Services.AddScoped<IBookRepository, BookRepository>();

        // In your ConfigureServices method in Startup.cs
        builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());


    }
}