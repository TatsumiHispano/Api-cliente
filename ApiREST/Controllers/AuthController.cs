using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiREST.Controllers
{
    // Define la ruta base para el controlador como "api/auth"
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        // Servicio para generar tokens JWT
        private readonly TokenService _tokenService;
        // Constructor que recibe TokenService mediante inyección de dependencias
        public AuthController(TokenService tokenService)
        {
            _tokenService = tokenService;// Asigna el servicio recibido al campo privado
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] UserCredentials credentials)
        {
            
            // En una aplicación real, debes validar contra una base de datos o un servicio de identidad.

            // Por ejemplo, supongamos que estos son los credenciales válidos.
            var usuarioValido = "david";
            var contraseñaValida = "1234";

            // Comprobar si las credenciales son válidas
            if (credentials.UserName == usuarioValido && credentials.Password == contraseñaValida)
            {
                // Si las credenciales son válidas, genera el token JWT.
                var token = _tokenService.GenerateJwtToken();
                return Ok(new { token });
            }
            else
            {
                // Si las credenciales no son válidas, retorna un error de autenticación.
                return Unauthorized("Credenciales no válidas.");
            }
        }
    }
}
