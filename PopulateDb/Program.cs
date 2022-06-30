using Microsoft.EntityFrameworkCore;
using PopulateDb.DataAccess;
using PopulateDb.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();

builder.Services.AddTransient<BusinessProvider>();

var sqlConnectionString = builder.Configuration.GetConnectionString("DataAccessMySqlProvider");
var serverVersion = new MySqlServerVersion(new Version(10, 8, 3));

builder.Services.AddDbContext<BreweryContext>(options =>
    options.UseMySql(sqlConnectionString, serverVersion));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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