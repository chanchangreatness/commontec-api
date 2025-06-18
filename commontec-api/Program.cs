using ComonTecApi.Endpoints;
using ComonTecApi.Infrastracture;
using ComonTecApi.Infrastracture.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureServices(builder.Configuration);

var app = builder.Build();

//for seeding products tbl
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    var seeder = new DataSeeder(context);

    seeder.SeedProducts();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(opt =>
    {
        opt.OpenApiVersion = Microsoft.OpenApi.OpenApiSpecVersion.OpenApi2_0;
    });
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapAuthEndpoint();
app.MapUsersEndpoint();
app.MapProductsEndpoint();

app.Run();