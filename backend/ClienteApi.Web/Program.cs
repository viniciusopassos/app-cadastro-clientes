using Microsoft.EntityFrameworkCore;
using projeto_MVC_Angular.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();

// Add services to the container.
var DB_STRING = builder.Configuration.GetConnectionString("Default");

builder.Services.AddEntityFrameworkSqlServer().AddDbContext<AppDbContext>(options => options.UseSqlServer(DB_STRING));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(c => {
    c.AllowAnyHeader();
    c.AllowAnyMethod();
    c.AllowAnyOrigin();
});

app.UseAuthorization();

app.MapControllers();

app.Run();
