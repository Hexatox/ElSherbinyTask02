using ElsherbinyTasks02.API.Data;
using ElsherbinyTasks02.API.Repositories;
using ElsherbinyTasks02.API.Services;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"), o => o.UseNodaTime());

});


builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();

builder.Services.AddScoped<BookService>();
builder.Services.AddScoped<AuthorService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(option =>
    {
        //  option
        //  .WithPreferredScheme("Bearer")
        //   .WithHttpBearerAuthentication(bearer =>
        // {
        //     bearer.Token = "your-bearer-token";
        // });

    });

    app.MapGet("/", () => Results.Redirect("http://localhost:5200/scalar/v1")).ExcludeFromDescription();
}





app.UseHttpsRedirection();





app.UseAuthorization();

app.MapControllers();

app.Run();
