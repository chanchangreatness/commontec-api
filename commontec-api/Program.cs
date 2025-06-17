using ComonTecApi.EndPoints;
using ComonTecApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapAuthEndpoint();
app.MapUsersEndpoint();
app.MapProductsEndpoint();

app.Run();