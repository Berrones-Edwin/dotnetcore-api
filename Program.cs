using FluentValidation;
using Microsoft.EntityFrameworkCore;
using TodoApi.DTO;
using TodoApi.Models;
using TodoApi.Repository;
using TodoApi.Services;
using TodoApi.Validations;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IPostService,PostService>();
builder.Services.AddScoped<IBeerService,BeerService>();
// builder.Services.AddKeyedScoped<ICommonService<BeerDTO,BeerInsertDTO,BeerUpdateDTO>,BeerService>("CommonServices");

// builder.Services.AddHttpClient("Post",c=>{
//     c.BaseAddress = new Uri(builder.Configuration["BaseUrlPosts"] ?? "");
// });

// HTTP CLIENT
builder.Services.AddHttpClient<IPostService,PostService>(c=>{
    c.BaseAddress = new Uri(builder.Configuration["BaseUrlPosts"] ?? "");
});
// builder.Services.AddHttpClient<IPostService,PostService>("Test",c=>{
//     c.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/users");
// });

// REPOSITORY
builder.Services.AddScoped<IRepository<Beer>,BeerRepository>();


builder.Services.AddControllers();

// DATABASE
var connString = builder.Configuration.GetConnectionString("GameStore") ?? "Data Source=GameStore.db";
builder.Services.AddSqlite<Context>(connString);
// builder.Services.AddDbContext<Context>(opt=>{
//     opt.UseSqlite(connString);
// });

// Validators
builder.Services.AddScoped<IValidator<BeerInsertDTO>,BeerInsertValidation>();
builder.Services.AddScoped<IValidator<BeerUpdateDTO>,BeerUpdateValidation>();

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
