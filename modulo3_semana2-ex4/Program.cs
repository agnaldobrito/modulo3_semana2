using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using modulo3_semana2_ex4.Configurations;
using modulo3_semana2_ex4.Data;
using modulo3_semana2_ex4.Services;

var builder = WebApplication.CreateBuilder(args);



builder.Services
    .AddControllers().Services
    .AddAuthentication("BasicAuthentication")
        .AddScheme<AuthenticationSchemeOptions, BasicAuthHandler>("BasicAuthentication", null)
        .Services
    .AddDbContext<BasicAuthContext>()
    .AddScoped<IUsuarioService, UsuarioService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContextFactory<BasicAuthContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DB_BasicAuth")));

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
