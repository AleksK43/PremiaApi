﻿using PremiaApi.Data;
using Microsoft.EntityFrameworkCore; 

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddDbContext<PremiaDbContext>(options => options.UseInMemoryDatabase("PremiaAPPSample"));

builder.Services.AddDbContext<PremiaDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("UsersApiConnectionString")));

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

