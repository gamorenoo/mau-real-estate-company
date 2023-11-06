
# mau-real-estate-company
Compañía de bienes raices - Million And Up

## 1. Planteamiento del problema (Requerimientos)

Una gran empresa de Bienes Raíces requiere crear una API para obtener información sobre propiedades en Estados Unidos
esta es en una base de datos como se muestra en la imagen:

su tarea es crear un conjunto de servicios:

a) Crear edificio de propiedad
b) Agregar imagen de la propiedad
c) Cambiar precio
d) Actualizar propiedad
e) Listar propiedad con filtros

Nota: El tipo de datos completo depende de sus criterios y agregue el campo según su consideración


## 2. Solución

Se toma la decisión de trabajar la solución siguiendo los principios de Clean Architecture en .NET 6. 
El principal objetivo de esta arquitectura es la capacidad de separar el código en sus diferentes responsabilidades, hacer el código mucho más entendible en el presente y futuro, testeable y fácil de integrar.


## 2.1 Tecnologías
* NET 6 / C#
* ASP.NET Core 6
* Sql Server
* Entity Framework Core 6
* JWT
* MediatR
* AutoMapper
* NUnit, FluentAssertions, Moq & Respawn
* AutoFixture
* SQLite
* Visual studio Comunity 2022

### 3. Pasos para ejecución de la Api :
Para ejecutar el proyecto de forma local, se debe, realizar los siguientes pasos: 
1. Clonar o descargar el repositorio de la solución
2. Crear la base de datos indicada en el archivo de configuracion appsettings.json del api y ajustar la conexion a la instancia de Sql Server de su maqunia:
```
	"ConnectionStrings": {
		"RealStateConnection": "Server=localhost;Database=RealState;User Id=sa;Password=0123456789"
   }
   
```
3. restaurar todos los paquetes Nuget (si es que no se hizo automaticamente)
4. Ajecutar aplicación

Al ejecutar la aplicación por primera vez, se ejecutan las migraciones en la BD, por lo que se se crearn las tablas en la Base de datos que se haya especificado en la cadena de conexión descrita en el paso 2
Se crear datos para la tabla Owner y Addres, por lo anterior al crear las Propiedades se debe ingresar en el campo IdOwner, algunos de estos Ids de Owners registrados, de lo contrario dará Error.



