using ApiREST;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ApiREST.Data;
using ApiREST.Repositories;
using ApiREST.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        // Crear el builder de la aplicación para configurar servicios y middlewares
        var builder = WebApplication.CreateBuilder(args);

        // Agregar servicios al contenedor
        builder.Services.AddControllers();

        // Configurar Swagger para la documentación de la API
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options =>
        {
            // Configurar Swagger para soportar autenticación JWT
            options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                In = Microsoft.OpenApi.Models.ParameterLocation.Header,// El token se pasa en el encabezado de la solicitud
                Description = "Por favor ingresa el token JWT",// Descripción que se muestra en la documentación de Swagger
                Name = "Authorization",// Nombre del encabezado
                Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,// Tipo de esquema de seguridad (API Key)
                Scheme = "Bearer"// El tipo de esquema es Bearer (usado con tokens JWT)
            });
            // Requerir que el token sea pasado en todas las solicitudes a la API
            options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
            {
                {
                    new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                    {
                        Reference = new Microsoft.OpenApi.Models.OpenApiReference
                        {
                            Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                            Id = "Bearer"// Identificador del esquema de seguridad que configuramos arriba
                        }
                    },
                    new string[] {}
                }
            });
        });

        // Configurar Entity Framework con MySQL
        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseMySql(
                builder.Configuration.GetConnectionString("DefaultConnection"),// Obtiene la cadena de conexión
                new MySqlServerVersion(new Version(8, 0, 30)) // Especifica la versión de MySQL a usar
            ));

        // Registrar servicios y repositorios
        builder.Services.AddScoped<LibroRepository>();// Servicio para manejar libros
        builder.Services.AddScoped<LibroService>();// Servicio que llama al repositorio de libros
        builder.Services.AddScoped<TokenService>();// Servicio para generar tokens JWT

        // Configuración de JWT para autenticación
        var parameters = new TokenValidationParameters
        {
            ValidateIssuer = true,// Validar el emisor del token
            ValidateAudience = true,// Validar el público (audiencia) del token
            ValidateLifetime = true,// Validar la fecha de expiración del token
            ValidateIssuerSigningKey = true,// Validar que la clave de firma sea válida
            ValidIssuer = builder.Configuration["Jwt:Issuer"],// Definir el emisor del token desde la configuración
            ValidAudience = builder.Configuration["Jwt:Audience"],// Definir el público del token desde la configuración
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))// Clave secreta para firmar el token
        };
        // Configurar la autenticación con JWT usando el esquema de JWT Bearer
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = parameters;// Proporcionar los parámetros de validación del token
            });

        // Construcción de la aplicación
        var app = builder.Build();

        // Configuración del pipeline de solicitudes HTTP
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage(); // Mostrar detalles de errores en desarrollo
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        else
        {
            // Manejo global de excepciones para producción
            app.UseExceptionHandler(errorApp =>
            {
                errorApp.Run(async context =>
                {
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    context.Response.ContentType = "application/json";//tipo de contenido json
                    // Obtener el detalle del error desde el contexto
                    var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                    if (exceptionHandlerFeature != null)
                    {
                        var logger = app.Services.GetRequiredService<ILogger<Program>>();// Obtener el servicio de logging
                        logger.LogError(exceptionHandlerFeature.Error, "Ocurrió un error inesperado.");// Registrar el error en los logs
                        await context.Response.WriteAsync(new
                        {
                            Error = "Ha ocurrido un error en el servidor."
                        }.ToString());
                    }
                });
            });
        }

        // Middleware de enrutamiento y autenticación
        app.UseRouting();
        app.UseAuthentication(); // Requiere autenticación
        app.UseAuthorization();  // Autoriza las solicitudes autenticadas

        // Configurar rutas para los controladores
        app.MapControllers();

        // Ejecutar la aplicación
        app.Run();
    }
}