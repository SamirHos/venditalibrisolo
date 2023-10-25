using Microsoft.EntityFrameworkCore;
using WebAPIVenditaSolo.DataSource;
using WebAPIVenditaSolo.Repository;
using WebAPIVenditaSolo.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Logging.ClearProviders();
//builder.Logging.AddEventLog();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//builder.Services.AddDbContext<LibreriaContext>(options =>
//{
//    //modo 1
//    string? cnLibreria = builder.Configuration.GetConnectionString("cnLibreria");
//    //modo 2
//    //string cnNorthwind2 = builder.Configuration.GetValue<string>("ConnectionStrings:cnNW");



//    options.UseSqlServer(cnLibreria);



//});
builder.Services.AddScoped<LibreriaContext, LibreriaContext>();

 builder.Services.AddScoped<IProdottiService, ProdottiService>();

builder.Services.AddScoped<IProdottiRepository, ProdottiRepository>();

builder.Services.AddScoped<IProdottiServiceRepository, ProdottiServiceRepository>();


// CONTEXT per POSTGRES
builder.Services.AddDbContext<LibreriaContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("cnPostgres")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
