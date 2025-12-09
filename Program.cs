using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

var builder = WebApplication.CreateBuilder(args);

// 1. Додаємо сервіси
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 2. НАЛАШТУВАННЯ ПОРТУ ДЛЯ RAILWAY (Критично важливо!)
var port = Environment.GetEnvironmentVariable("PORT") ?? "5005";
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(Int32.Parse(port));
});

var app = builder.Build();

// 3. Вмикаємо Swagger завжди (щоб бачити його в інтернеті)
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();
app.MapControllers();

app.Run();