using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using NetMatch.MyClientMobile.Business.Data;
using NetMatch.MyClientMobile.Business.Services;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowAnyOrigin();
                      });
});

// Add services to the container.
builder.Services.AddSingleton<IActivityService, ActivityService>();
builder.Services.AddSingleton<IActivityData, ActivityData>();
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();
app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapHealthChecks("/ping", new HealthCheckOptions
    {
        AllowCachingResponses = false,
        ResponseWriter = async (context, report) =>
        {
            await context.Response.WriteAsync("pong");
        }
    });
    endpoints.MapControllers();
});
app.MapControllers();

app.Run();
