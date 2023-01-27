using AutoMapper;
using FluentValidation;
using MagicVila_CouponAPI;
using MagicVila_CouponAPI.Data;
using MagicVila_CouponAPI.EndPoints;
using MagicVila_CouponAPI.Models;
using MagicVila_CouponAPI.Models.DTO;
using MagicVila_CouponAPI.Repository;
using MagicVila_CouponAPI.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Runtime.CompilerServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MappingConfig));
builder.Services.AddValidatorsFromAssemblyContaining<Program>();
builder.Services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<ICouponRepository, CouponRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.ConfigureCouponsEndPoint();
app.UseHttpsRedirection();



app.Run();


