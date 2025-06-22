using FamilyStoryApi.Infra.Configuration;
using FamilyStoryApi.Infra.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string connectionString = "Server=localhost,1433;Database=Family_Story;User id=sa;Password=1q2w3e4r@#$;TrustServerCertificate=True;";
builder.Services.AddDbContext<FamilyStoryContext>(options =>  options.UseSqlServer(connectionString));

builder.Services.AddApplicationServices();

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
