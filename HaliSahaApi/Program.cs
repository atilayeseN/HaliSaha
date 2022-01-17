using Microsoft.EntityFrameworkCore;
using HaliSahaApi.Context;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
                      });
});

builder.Services.AddControllers();

builder.Services.AddDbContext<MainContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("MainContext")));

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.UseSession();

app.MapControllers();

app.Run();

