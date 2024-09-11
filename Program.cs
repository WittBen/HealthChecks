using HealthChecks.HealthChecks;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




builder.Services.AddHealthChecks()
                .AddCheck<MyFirstHealthCheck>("MyFirstHealthCheck", tags: new[] { "First_Health_Check" })
                .AddCheck<MySecondHealthCheck>("MySecondHealthCheck", tags: new[] { "custom2" })
                .AddCheck<DatabaseConnectionCheck>("DatabaseConnectionCheck", tags: new[] { "database" });


builder.Services.AddHealthChecksUI().AddInMemoryStorage();


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

app.MapHealthChecks("/_health", new HealthCheckOptions
{
  ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});
app.MapHealthChecksUI();

app.Run();
