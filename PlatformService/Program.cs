using Microsoft.EntityFrameworkCore;
using PlatformService.Data.Context;
using PlatformService.Data.Interfaces.Repository;
using PlatformService.Data.Migration.PrepDbFakeData;
using PlatformService.Data.Repository;

var builder = WebApplication.CreateBuilder(args);

//DB Context
builder.Services.AddDbContext<PlatformDbContext>(opt =>
                opt.UseInMemoryDatabase("InMem"));
//DI
builder.Services.AddScoped<IPlatformRepository, PlatformRepository>();

builder.Services.AddControllers();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
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

//DB Population
PrepDb.PrepPopulation(app);

app.Run();