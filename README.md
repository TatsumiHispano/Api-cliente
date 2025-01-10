DATOS IMPORTANTES:
Si quieres ejecutar el programa primero de todo tienes que saber que el usuario es david y la contraseña es 1234
Por ultimo tienes que saber que el programa esta vinculado a una base de datos tendras que cambiar el json y poner
el enlace a tu base de datos te recomiendo hacerla en heidiSQl y la activacion de sql te recomiendo descargar xampp 
la base de datos tiene tres atributos el id que tiene que ser auto incrementado(el id es auto incrementado porque cuando el usario borra un titulo con id 2 el titulo con id 3 pasara a la posicion 2) , el titulo y el autor.

Recuerda para ejecutar este proyecto te recomiendo visual studio cuando lo hayas puesto tiene que ir a la solucion principal ir a propiedades y darle a la opcion de varios proyecto de inicio para que asi el la base de datos y el cliente se ejecute a la vez.

ApiREST: El Servidor y la Lógica de Negocio
La solución ApiREST se encarga de proporcionar una API RESTful para gestionar libros en una base de datos. Esta API está desarrollada con ASP.NET Core, y proporciona una interfaz para realizar operaciones como crear, leer, actualizar y eliminar libros de una base de datos a través de solicitudes HTTP.

Estructura general de la API
Controladores : Los controladores son responsables de manejar las solicitudes HTTP (GET, POST, PUT, DELETE) y devolver respuestas apropiadas al cliente.
Los controladores actúan como la capa de presentación del servidor, procesando las solicitudes y respondiendo a ellas. En este proyecto, existen varios controladores:

LibrosController : Gestiona las operaciones CRUD para los libros. 
Permite obtener todos los libros, obtener un libro por ID, crear, actualizar y eliminar libros.
AuthController : Este controlador se encarga de la autenticación de los usuarios. 
Permite a los usuarios iniciar sesión con un nombre de usuario y contraseña, y devuelve un JWT Token que el cliente puede utilizar para autenticar futuras peticiones.
Servicios : Los servicios en ApiREST contienen la lógica de negocio.
En el caso de la gestión de libros, el servicio llamado LibroService se encarga de interactuar con la base de datos, utilizando el repositorio LibroRepository para realizar las operaciones CRUD.
Esto mantiene la lógica de negocio separada de los controladores, lo que facilita la mantenibilidad y la escalabilidad del proyecto.

Modelo : El modelo Libro es una clase simple que representa un libro, con propiedades como Id , Titulo y Autor .
Esta clase es utilizada por los controladores y los servicios para trabajar con los datos de los libros. 
Se utiliza con Entity Framework Core para mapear los datos a una base de datos relacional.

Base de datos : AppDbContext es la clase que gestiona la conexión con la base de datos a través de Entity Framework Core. 
Proporciona un conjunto de operaciones sobre la base de datos, como consultar, agregar, actualizar o eliminar registros de la tabla Libros .

Autenticación y Seguridad : La autenticación en la API se maneja utilizando JWT (JSON Web Tokens) . 
Cuando un usuario inicia sesión con credenciales válidas, el servidor genera un token JWT que se incluye en los encabezados de las solicitudes posteriores.
Este token permite al cliente acceder a las rutas protegidas, como aquellas que realizan cambios en los datos (crear, actualizar, eliminar libros).

Excepciones y Manejo de Errores : En la API se manejan excepciones y errores, como cuando no se encuentra un libro por ID o cuando el usuario no está autenticado.
Se responde adecuadamente con códigos de estado HTTP, como 404 Not Found o 401 Unauthorized , y se proporciona un mensaje claro.

ClienteRest: El Cliente para Interactuar con la API
La solución ClienteRest está diseñada para interactuar con la API proporcionada por ApiREST . 
Se trata de una aplicación cliente en consola que permite al usuario realizar las operaciones disponibles en la API (login, CRUD de libros, etc.) a través de la interfaz de consola.

Interfaz de usuario : La aplicación de consola proporciona un menú donde el usuario puede elegir qué acción tomar.
Las opciones disponibles incluyen iniciar sesión, obtener todos los libros, obtener un libro por ID, crear un libro, actualizar un libro, eliminar un libro y probar excepciones en la API.

Autenticación : El cliente comienza pidiendo al usuario sus credenciales (nombre de usuario y contraseña).
Estas credenciales se envían a la API para obtener un JWT Token. Este token se almacena en el cliente y se utiliza en las solicitudes posteriores para autenticar al usuario.

Operaciones CRUD : El cliente permite interactuar con los libros a través de las operaciones CRUD:

Obtener todos los libros : El cliente envía una solicitud GET a la API y muestra la lista de libros.
Obtener un libro por ID : El cliente pide un ID y obtiene la información del libro correspondiente.
Crear un libro : El cliente envía una solicitud POST con los detalles del nuevo libro (título y autor) a la API.
Actualizar un libro : El cliente envía una solicitud PUT con los nuevos datos de un libro existente.
Eliminar un libro : El cliente envía una solicitud DELETE para eliminar un libro por su ID.
Autorización : Cada vez que se realiza una operación CRUD, el cliente incluye el token JWT en los encabezados de la solicitud para asegurarse de que la acción sea autorizada.
Si el token es válido, la solicitud se procesa; si no lo es, se muestra un error.

Manejo de Excepciones : El cliente también incluye una opción para probar excepciones en la API. Si el servidor lanza un error (por ejemplo, si no se encuentra un libro), el cliente muestra el mensaje de error al usuario.

Interacción Entre ApiREST y ClienteRest
Comunicación con la API : El cliente utiliza HTTP para interactuar con la API. Realiza solicitudes utilizando HttpClient en C# para enviar solicitudes GET, POST, PUT y DELETE a las rutas definidas en la API.
Cada solicitud que requiere autorización lleva el token JWT en los encabezados para garantizar que el usuario esté autenticado.

Formato de Datos : El cliente envía y recibe datos en formato JSON .
Cuando se crean o actualizan libros, el cliente convierte los objetos de libro en JSON utilizando la biblioteca Newtonsoft.Json . 
La API, por su parte, también devuelve los libros en formato JSON, que el cliente procesa y muestra en la consola.

Manejo de Respuestas : Dependiendo de la respuesta de la API, el cliente muestra la información correspondiente.
Si la operación es exitosa, se muestra un mensaje de éxito; Si ocurre un error, se muestra un mensaje detallado con el código de estado HTTP y la descripción del error.

Conclusión
En resumen, la solución ApiREST proporciona una API robusta para gestionar libros, permitiendo operaciones CRUD y autenticación mediante JWT. 
ClienteRest interactúa con esta API para realizar esas operaciones a través de una interfaz de consola.
Ambos proyectos están diseñados para trabajar juntos:
ApiREST maneja la lógica de negocio y la base de datos, mientras que ClienteRest proporciona una manera fácil y rápida de interactuar con esa lógica a través de solicitudes HTTP.
