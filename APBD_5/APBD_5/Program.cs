using APBD_5.Repositories;
using APBD_5.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers(); //

builder.Services.AddScoped<IAnimalsService, AnimalsService>();
builder.Services.AddScoped<IAnimalsRepository, AnimalRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers(); //

app.Run();