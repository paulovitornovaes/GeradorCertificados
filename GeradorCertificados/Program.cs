using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using GeradorCertificados.Data;
using GeradorCertificados.Services;
using GeradorCertificados.Services.Contracts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BaseDbContext>(options => 
    options.UseNpgsql(builder.Configuration.GetConnectionString("GeradorCertificados") ?? throw new InvalidOperationException("Connection string 'GeradorCertificados2Context' not found."))
);

// Adicione essas linhas para configurar o Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Nome do Seu Projeto", Version = "v1" });
});

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddTransient<ICargaService, CargaService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Adicione essas linhas para habilitar o Swagger no pipeline de solicitação HTTP
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Nome do Seu Projeto v1");
    c.RoutePrefix = "swagger";
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();