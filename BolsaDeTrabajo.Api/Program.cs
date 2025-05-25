using BolsaDeTrabajo.Data;
using BolsaDeTrabajo.Data.Repos;
using BolsaDeTrabajo.Handlers;
using Microsoft.EntityFrameworkCore;
using MediatR;
using BolsaDeTrabajo.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Cadena de conexión
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<BolsaDeTrabajoContext>(options =>
    options.UseSqlServer(connectionString));

// Validar longitud de clave JWT
var jwtKey = builder.Configuration["Jwt:Key"];
if (string.IsNullOrEmpty(jwtKey) || jwtKey.Length < 32)
{
    throw new Exception("La clave JWT debe tener al menos 32 caracteres.");
}


builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins(
                "http://localhost:8080",   // Vue CLI dev server
                "http://localhost:3000",   // React/otros
                "http://localhost:5173",   // Vite
                "http://localhost:4200",   // Angular
                "https://localhost:8080",  // HTTPS variants
                "https://localhost:3000",
                "https://localhost:5173",
                "https://localhost:4200"
              )
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials()
              .SetIsOriginAllowed(origin =>
              {
                  // Permitir localhost en cualquier puerto para desarrollo
                  return Uri.TryCreate(origin, UriKind.Absolute, out var uri) &&
                         (uri.Host == "localhost" || uri.Host == "127.0.0.1");
              });
    });
});

// Autenticación JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
        };
    });

// Repositorios y servicios
builder.Services.AddMediatR(typeof(DummyMarker).Assembly);
builder.Services.AddScoped<IUsuarioRepo, UsuarioRepo>();
builder.Services.AddScoped<IEmpresaRepo, EmpresaRepo>();
builder.Services.AddScoped<IAspiranteRepo, AspiranteRepo>();
builder.Services.AddScoped<IContactoRepo, ContactoRepo>();
builder.Services.AddScoped<IDireccionRepo, DireccionRepo>();
builder.Services.AddScoped<IDocumentoRepo, DocumentoRepo>();
builder.Services.AddScoped<IHabilidadRepo, HabilidadRepo>();
builder.Services.AddScoped<IRecomendacionRepo, RecomendacionRepo>();
builder.Services.AddScoped<IPublicacionRepo, PublicacionRepo>();
builder.Services.AddScoped<IExperienciaRepo, ExperienciaRepo>();
builder.Services.AddScoped<IFormacionRepo, FormacionRepo>();
builder.Services.AddScoped<ICertificacionRepo, CertificacionRepo>();
//probar
builder.Services.AddScoped<ILogroRepo, LogroRepo>();
builder.Services.AddScoped<IEventoRepo, EventoRepo>();
builder.Services.AddScoped<IExamenRepo, ExamenRepo>();
builder.Services.AddScoped<IIdiomaRepo, IdiomaRepo>();
builder.Services.AddScoped<IOfertaRepo, OfertaRepo>();
builder.Services.AddScoped<IAplicacionOfertaRepo, AplicacionOfertaRepo>();

builder.Services.AddSingleton<JwtTokenGenerator>();

// Swagger con soporte para JWT
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "BolsaDeTrabajo API", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Introduce el token JWT como: Bearer {token}"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
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

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();