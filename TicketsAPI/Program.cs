using TicketsAPI.Application;
using TicketsAPI.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;

services
    .AddInfrastructure(builder.Configuration)
    .AddApplication();

var defaultPolicy = "DefaultPolicy";
services.AddCors(opt =>
{
    opt.AddPolicy(defaultPolicy, (policy) =>
    {
        policy.WithOrigins("http://localhost:3000", "https://localhost:3000")
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(defaultPolicy);

app.UseAuthorization();

app.MapControllers();

app.Run();
