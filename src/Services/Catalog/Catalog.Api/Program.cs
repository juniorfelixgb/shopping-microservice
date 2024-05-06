using Carter;
using Catalog.Application;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCarter();

builder.Services.AddEndpointsApiExplorer()
                .AddSwaggerGen()
                .AddApplication(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapCarter();

app.Run();
