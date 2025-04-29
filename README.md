📚 Proyecto API REST + Cliente de Consola
Descripción General
Este proyecto consiste en dos partes principales:

ApiREST: Una API RESTful desarrollada en ASP.NET Core para gestionar libros.

ClienteRest: Una aplicación de consola en C# que interactúa con la API a través de solicitudes HTTP.

Ambas soluciones trabajan de forma conjunta para permitir operaciones CRUD sobre libros, con autenticación mediante JWT.

⚙️ Requisitos Previos para Ejecutar el Proyecto
Antes de ejecutar el proyecto, ten en cuenta lo siguiente:

Usuario por defecto: david

Contraseña por defecto: 1234

🛠️ Base de Datos
La API está conectada a una base de datos. Para que funcione correctamente:

Crea una base de datos en HeidiSQL o la herramienta de tu preferencia.

Asegúrate de que tenga los siguientes campos:

id (auto-incremental)

titulo

autor

Configura el archivo JSON de conexión con la ruta correcta a tu base de datos.

Se recomienda usar XAMPP para activar el servicio SQL si estás trabajando localmente.

🖥️ Recomendaciones de Ejecución
Para ejecutar ambos proyectos desde Visual Studio:

Abre la solución principal.

Ve a las propiedades de la solución.

Activa la opción "Varios proyectos de inicio" para que la API y el cliente se ejecuten simultáneamente.

🌐 ApiREST – Servidor y Lógica de Negocio
🔧 Estructura
Controladores:

LibrosController: CRUD de libros (GET, POST, PUT, DELETE).

AuthController: Autenticación y generación de JWT.

Servicios:

LibroService: Lógica de negocio separada de los controladores.

LibroRepository: Acceso a datos mediante Entity Framework.

Modelo:

Libro.cs: Contiene las propiedades Id, Titulo y Autor.

Base de datos:

AppDbContext.cs: Contexto de EF Core para interactuar con la base de datos relacional.

Seguridad:

Autenticación mediante JWT: el token se incluye en las solicitudes que requieren autorización.

Manejo de Errores:

Respuestas con códigos HTTP claros (404 Not Found, 401 Unauthorized, etc.).

🧪 ClienteRest – Aplicación de Consola
📋 Funcionalidades
Menú interactivo en consola para:

Iniciar sesión.

Ver todos los libros.

Buscar un libro por ID.

Crear, actualizar o eliminar un libro.

Probar excepciones y respuestas de error.

Al iniciar sesión correctamente, se obtiene un JWT Token que se guarda y se utiliza en todas las peticiones posteriores.

Comunicación a través de HttpClient y serialización/deserialización en JSON con Newtonsoft.Json.

Muestra mensajes de éxito o errores detallados con base en la respuesta de la API.

🔗 Comunicación entre API y Cliente
Todas las operaciones se hacen mediante solicitudes HTTP a la API.

Las operaciones protegidas requieren el token JWT.

Datos enviados y recibidos en formato JSON.

✅ Conclusión
Este proyecto demuestra cómo construir una API RESTful completa con autenticación y una aplicación cliente para consumirla. Es una solución ideal para practicar:

Desarrollo full-stack con C#.

Uso de Entity Framework Core.

Seguridad con JWT.

Interacción cliente-servidor mediante HTTP y JSON.
