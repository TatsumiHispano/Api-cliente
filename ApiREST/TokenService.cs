using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace ApiREST
{
    public class TokenService
    {
        private readonly IConfiguration _configuration;// Se inyecta la configuración de la aplicación (como la clave secreta, el emisor, etc.).
        // El constructor recibe la configuración, que se utiliza para obtener las claves y parámetros del JWT.
        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // Método para generar el token JWT.
        public string GenerateJwtToken()
        {
            // Se obtiene la clave secreta desde la configuración (asegúrate de tener una sección en appsettings.json para "Jwt:Key").
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            // Las credenciales de firma se configuran utilizando la clave secreta y el algoritmo de firma (HmacSha256).
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            // Se crea el token JWT con los siguientes parámetros:
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],// Emisor del token, generalmente es tu aplicación o servicio.
                audience: _configuration["Jwt:Audience"],// Audiencia del token, generalmente los clientes a los que se les otorga acceso.
                expires: DateTime.Now.AddHours(1),// Tiempo de expiración del token, en este caso, 1 hora.
                signingCredentials: credentials);// Las credenciales de firma que se usarán para firmar el token.
            // El token generado se convierte en una cadena (string) utilizando el 'JwtSecurityTokenHandler'.
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
