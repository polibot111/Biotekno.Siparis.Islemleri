using Biotekno.Data.Abstract;
using Biotekno.Data.Concrete;
using Biotekno.Data.Concrete.Contexts;
using Biotekno.Presentation.Data;
using Biotekno.Shared.Concrete.Ef;
using Biotekno.Shared.Data.Abstract;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Events;

Log.Logger = new LoggerConfiguration().
             MinimumLevel.Override("Microsoft", LogEventLevel.Information).
             Enrich.FromLogContext().
             WriteTo.File("Log.txt").
             CreateBootstrapLogger();

try
{
    Log.Information("Starting the web Host clock => " + DateTime.Now);
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    builder.Services.AddDbContext<DataContext>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    });
    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();


    //AddScoped Start

    builder.Services.AddTransient(typeof(IEntityRepository<>), typeof(EfEntityRepositoryBase<>));

    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

    builder.Services.AddLogging(x =>
    {

    });




    //AddScoped Finish

    var app = builder.Build();


    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
    return 1;
}
finally
{
    Log.CloseAndFlush();
}
return 0;