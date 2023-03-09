using EctakoTest.Infrastructure.Data;
using EctakoTest.WebApp.Configuration;
using EctakoTest.WebApp.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(c =>
{
    // NB! in UseDbSeed migrate=false
    c.UseInMemoryDatabase("EctakoTest");

    // NB! NEED TO COMMENT OUT CreateIndex() in Migrations
    // Dont know if it's a bug or what...
    // var folder = Environment.SpecialFolder.LocalApplicationData;
    // var path = Environment.GetFolderPath(folder);
    // var dbPath = Path.Join(path, "ectako.dbectako.db");
    // Console.Out.WriteLine(dbPath);
    // c.UseSqlite($"Data Source={dbPath}");
});

builder.Services.AddMapperServices();
builder.Services.AddCoreServices();
builder.Services.AddWebServices();

var app = builder.Build();
await app.UseDbSeed(false);

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ectako Test"));
}
// app.UseHttpsRedirection();
// app.UseAuthorization();

app.UseRouting();
app.MapControllers();
app.Run();