using Microsoft.AspNetCore.Mvc;

namespace ApiREST.Controllers
{
    // El controlador está configurado para manejar peticiones HTTP relacionadas con el pronóstico del tiempo.
    // La ruta base para este controlador es "api/weatherforecast".
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        // Array estático que contiene diferentes resúmenes del clima.
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
        // Inyección de dependencias: se inyecta un logger para registrar información y errores en el controlador.
        private readonly ILogger<WeatherForecastController> _logger;
        // Constructor que recibe un logger para la clase WeatherForecastController.
        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;// Asigna el logger recibido al campo privado _logger.
        }
        // Método HTTP GET para obtener el pronóstico del tiempo.
        // El nombre del método GET se especifica como "GetWeatherForecast" para uso en rutas.
        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            // Genera una lista de 5 pronósticos del clima, con una fecha, temperatura y resumen aleatorio.
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast// Genera un rango de números del 1 al 5 (5 elementos).
            {
                Date = DateTime.Now.AddDays(index),// Establece la fecha como el día actual más el índice (días consecutivos).
                TemperatureC = Random.Shared.Next(-20, 55),// Genera una temperatura aleatoria entre -20 y 55 grados Celsius.
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]// Selecciona aleatoriamente un resumen del clima.
            })
            .ToArray();// Convierte el resultado a un arreglo.
        }
    }
}