using Serilog;

namespace BookStore.Extensions;

public static class RegisterMiddlewaresConfiguration
{
    public static void RegisterMiddlewares(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger()
               .UseSwaggerUI();
        }
        app.UseSerilogRequestLogging();
        app.UseHttpsRedirection();
    }
}