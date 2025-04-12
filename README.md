# Proyecto Catedra PrograIII - Backend

## Descripción

Este proyecto es un backend desarrollado en C# con ASP.NET Core para gestionar funcionalidades relacionadas con usuarios, productos y otros recursos. Utiliza un enfoque basado en capas, incluyendo modelos, controladores, DTOs y un patrón de repositorio para separar la lógica de acceso a datos.

## Tabla de Contenidos

- [Estructura del Proyecto](#estructura-del-proyecto)
- [Tecnologías Utilizadas](#tecnologías-utilizadas)
- [Instalación](#instalación)
- [Uso](#uso)
- [Endpoints](#endpoints)
- [DTOs (Data Transfer Objects)](#dtos-data-transfer-objects)
- [Repositorio](#repositorio)
- [Controladores](#controladores)
- [Modelos](#modelos)

## Estructura del Proyecto
PoryectoCatedraPrograIII/ ├── Controllers/ ├── Models/ ├── DTOs/ ├── Repositories/ ├── Services/ ├── PoryectoCatedraPrograIII.sln └── appsettings.json

## Tecnologías Utilizadas
- ASP.NET Core
- C#
- Entity Framework Core
- SQL Server
- AutoMapper (si aplica)
- Swagger (para documentación de API)

## Instalación
1. Clona el repositorio:

   ```bash
   git clone https://github.com/JosueCast/Repositorio_Backend.git
2. Abre el proyecto en Visual Studio usando el archivo .sln.
3. Configura la conexión a base de datos en appsettings.json:
   "ConnectionStrings": {
  "DefaultConnection": "Server=TU_SERVIDOR;Database=TU_DB;Trusted_Connection=True;"
}
4. Ejecuta migraciones si estás usando Entity Framework: Update-Database
5. Ejecuta la aplicación con Visual Studio (F5) o mediante CLI.

## Uso
Una vez ejecutado, puedes acceder a Swagger en: http://localhost:<puerto>/swagger
Desde ahí puedes probar todos los endpoints expuestos por la API.

## Endpoints
A continuación, se detallan algunos de los endpoints principales:

UsuarioController:

GET /api/usuarios: Obtiene todos los usuarios.

GET /api/usuarios/{id}: Obtiene un usuario por su ID.

POST /api/usuarios: Crea un nuevo usuario.

PUT /api/usuarios/{id}: Actualiza un usuario existente.

DELETE /api/usuarios/{id}: Elimina un usuario.

ProductoController:

GET /api/productos: Obtiene todos los productos.

GET /api/productos/{id}: Obtiene un producto por su ID.

POST /api/productos: Crea un nuevo producto.

PUT /api/productos/{id}: Actualiza un producto existente.

DELETE /api/productos/{id}: Elimina un producto.

## DTOs (Data Transfer Objects)
Los DTOs se utilizan para transferir datos entre el cliente y el servidor. En este proyecto, se encuentran en la carpeta DTOs/ y se utilizan para:

UsuarioDTO: Contiene las propiedades necesarias para crear o actualizar un usuario, como Nombre, Correo, etc.

ProductoDTO: Incluye las propiedades para manejar productos, como Nombre, Precio, Descripcion, etc.

##Repositorio
El patrón de repositorio se implementa en la carpeta Repositories/ para manejar la lógica de acceso a datos. Por ejemplo:

UsuarioRepository: Contiene métodos para interactuar con la base de datos relacionados con la entidad Usuario, como ObtenerTodos, ObtenerPorId, Crear, Actualizar, y Eliminar.

## Controladores (Controllers)
Los controladores manejan las solicitudes HTTP y se encuentran en la carpeta Controllers/. Cada controlador está asociado a una entidad específica y utiliza los servicios y repositorios para procesar las solicitudes. Por ejemplo:

UsuarioController: Gestiona las operaciones relacionadas con los usuarios y utiliza UsuarioRepository para interactuar con la base de datos.

## Modelos (Models)
Los modelos representan las entidades de la base de datos y se encuentran en la carpeta Models/. Cada modelo corresponde a una tabla en la base de datos. Por ejemplo:

Usuario: Representa la entidad de usuario con propiedades como Id, Nombre, Correo, etc.
