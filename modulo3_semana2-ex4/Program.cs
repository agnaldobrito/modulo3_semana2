using Microsoft.AspNetCore.Authentication;
using Microsoft.OpenApi.Models;
using modulo3_semana2_ex4.Configurations;
using modulo3_semana2_ex4.Data;
using modulo3_semana2_ex4.Services;

var builder = WebApplication.CreateBuilder(args);



builder.Services
    .AddControllers();
builder.Services
    .AddAuthentication("BasicAuthentication")
    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);
builder.Services
    .AddDbContext<BasicAuthContext>()
    .AddScoped<IUsuarioService, UsuarioService>()
    .AddEndpointsApiExplorer()
    .AddSwaggerGen(swagger=>
    {
        swagger.AddSecurityDefinition("basic", new OpenApiSecurityScheme
        {
            Name = "Basic",
            Type = SecuritySchemeType.Http,
            Scheme = "basic",
            In = ParameterLocation.Header,
            Description = "Basic Authorization Header"
        });

        swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id="basic"
                    }
                },
                Array.Empty<string>()
            }
        });
    });



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
