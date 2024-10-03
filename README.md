# DOCUMENTACIÓN API PRUEBA TÉCNICA NETFOREMOST

## INTRODUCCIÓN
El fin de este documento es explicar los segmentos de la API y su funcionamiento. Se destaca que se decidió hacer la prueba como una API para poder darle un valor agregado y generar un trabajo lo más completo posible, donde se usó una arquitectura hexagonal. Se tomó en desarrollo un aproximado de 4 horas y 30 minutos.

## ESTRUCTURA DEL PROYECTO

En este caso, se puede observar que el proyecto consta de un proyecto creado a partir de la plantilla de ASP.NET Core Web API desarrollada en .NET 8. Se crearon 2 bibliotecas de clase, donde la **.Core** es donde se crean los objetos, en este caso, DTO (Data Transfer Objects) y las interfaces para el desarrollo de los métodos. La segunda, **.Infrastructure**, maneja el desarrollo del algoritmo, donde el `DataContext` es donde se genera la conexión a la base de datos. La carpeta **Helpers** maneja clases estáticas para la reutilización de código en diferentes lugares del proyecto; la carpeta **Service** maneja de la misma manera código reutilizable en el proyecto; en la carpeta **Repository** es donde se desarrollan las interfaces y, por último, el **BLL** es donde se desarrolla la lógica que, en este caso, no es necesario.

## DESARROLLO INTERFACES

Solo se mostrará en este caso como ejemplo la interfaz que asigna los saldos, como se pide en los requisitos, para mostrar el desarrollo del proyecto.

En este caso, se genera la conexión; además de esto, se guardan las respuestas en un DataSet que posteriormente se muestra en la respuesta de tipo `ResponseDTO`.

## HELPER

Se crean los siguientes helpers para reutilizar código:

- **DataTableToList**: Convierte una tabla en una lista para poder mostrarla en la respuesta del endpoint.
- **Maps**: Funciones de mapeo para convertir entre diferentes objetos.
- **ExceptionHelper**: Se usa para capturar los errores.

## SERVICE

De los servicios, se destaca el **LogService**, que captura los errores y genera un archivo .txt que se guardará en la ruta designada en el `appsettings.json`.

## BASE DE DATOS

La base de datos se crea en el mismo proyecto para que se pueda publicar y usar de manera local, además de tener un control de versión de la misma.
