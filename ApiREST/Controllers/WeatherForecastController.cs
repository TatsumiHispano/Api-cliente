using Microsoft.AspNetCore.Mvc;

namespace ApiREST.Controllers
{
    // El controlador est� configurado para manejar peticiones HTTP relacionadas con el pron�stico del tiempo.
    // La ruta base para este controlador es "api/weatherforecast".
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        // Array est�tico que contiene diferentes res�menes del clima.
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
        // Inyecci�n de dependencias: se inyecta un logger para registrar informaci�n y errores en el controlador.
        private readonly ILogger<WeatherForecastController> _logger;
        // Constructor que recibe un logger para la clase WeatherForecastController.
        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;// Asigna el logger recibido al campo privado _logger.
        }
        // M�todo HTTP GET para obtener el pron�stico del tiempo.
        // El nombre del m�todo GET se especifica como "GetWeatherForecast" para uso en rutas.
        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            // Genera una lista de 5 pron�sticos del clima, con una fecha, temperatura y resumen aleatorio.
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast// Genera un rango de n�meros del 1 al 5 (5 elementos).
            {
                Date = DateTime.Now.AddDays(index),// Establece la fecha como el d�a actual m�s el �ndice (d�as consecutivos).
                TemperatureC = Random.Shared.Next(-20, 55),// Genera una temperatura aleatoria entre -20 y 55 grados Celsius.
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]// Selecciona aleatoriamente un resumen del clima.
            })
            .ToArray();// Convierte el resultado a un arreglo.
        }
    }
}