namespace HelloRender.Api;

public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();
        
        var isRenderEnvironment = Environment.GetEnvironmentVariable("RENDER") == "true";

        if (app.Environment.IsDevelopment() || isRenderEnvironment)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        
        var disableHttpsRedirection = app.Environment.IsProduction() && isRenderEnvironment;

        if (!disableHttpsRedirection)
        {
            app.UseHttpsRedirection();
        }

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}