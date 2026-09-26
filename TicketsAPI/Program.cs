using Asp.Versioning;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using TicketsAPI.Application;
using TicketsAPI.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;

var configuration = builder.Configuration;
services
    .AddInfrastructure(configuration)
    .AddApplication();

var defaultPolicy = nameof(Policies.Cors.DefaultPolicy);
services.AddCors(opt =>
{
    opt.AddPolicy(defaultPolicy, (policy) =>
    {
        policy.WithOrigins("http://localhost:3000", "https://localhost:3000")
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

services.AddAuthorization(options =>
{
    options.AddPolicy(nameof(Policies.Scopes.GrantTicketAccess), policy =>
    {
        policy.RequireClaim("scope", Policies.Scopes.GrantTicketAccess);
    });
});

services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
{
    var secret = configuration["Authentication:JWT:Secret"] ?? string.Empty;
    if (string.IsNullOrWhiteSpace(secret)) throw new InvalidDataException("Invalid Client Secret");

    options.TokenValidationParameters =
    new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,

        ValidIssuer = configuration["Authentication:JWT:Issuer"],
        ValidAudience = configuration["Authentication:JWT:Audience"],

        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(secret)
        )
    };
});

services.AddControllers();

// 2. Configurar el Versionado de la API (AddApiVersioning)
services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
    options.ApiVersionReader = new UrlSegmentApiVersionReader();
})
.AddApiExplorer(options => // 3. Explorador de versiones (después de AddApiVersioning)
{
    // Formato para Swagger: 'v'1, 'v'2, etc.
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API",
        Version = "v1"
    });

    options.AddSecurityDefinition("Bearer",
    new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Introduce: Bearer {token}"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
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

app.UseCors(defaultPolicy);

app.UseAuthorization();

app.MapControllers();

app.Run();
