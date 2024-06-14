# Sistema para Registrar Clasificados

Este proyecto es un sistema para la gestión de clasificados que permite crear, editar y eliminar anuncios, así como gestionar propiedades y operaciones. A continuación se describen las características y la estructura del frontend y backend del sistema.

## Frontend

El frontend cuenta con tres pantallas principales:

1. **Home**:
   - Permite crear, editar y eliminar clasificados.
   - Se pueden agregar imágenes y completar campos, algunos de los cuales son obligatorios.
   - La ubicación se puede especificar escribiendo o arrastrando un punto rojo al lugar deseado.

2. **Propiedades**:
   - CRUD (Crear, Leer, Actualizar, Eliminar) para los tipos de propiedades.

3. **Operaciones**:
   - CRUD para los tipos de operaciones.

Se creó un archivo `.env` para registrar los datos importantes del sistema.

### Estructura de Carpetas

- **assets**: Contiene los archivos CSS.
- **components**: Componentes reutilizables en las vistas.
- **router**: Definiciones de rutas del sistema.
- **stores**: Preparado para usar con Pinia, aunque no implementado.
- **types**: Interfaces definidas para usar en el sistema.
- **views**: Contiene las tres vistas mencionadas anteriormente.

## Backend

El backend está organizado en carpetas y preparado para usar JWT tokens para la autenticación.

### Estructura de Carpetas

- **Context**: Contiene los modelos utilizados para almacenar datos en SQL.
- **Controllers**: Maneja el acceso a la API con sus respectivas interfaces.
- **Extensions**: Define tres extensiones específicas.
- **Middleware**: Configuración de AutoMapper.
- **Models**: Modelos para la base de datos y DTOs (Data Transfer Objects).
- **Services**: Contiene la lógica de negocio.

Se dejaron las migraciones preparadas para detectar cambios realizados en el esquema de la base de datos.

## Instalación y Configuración

1. Clonar el repositorio.
2. Configurar las variables de entorno en el archivo `.env`.
3. Ejecutar las migraciones para configurar la base de datos.
4. Iniciar el frontend y el backend del sistema.

## Tecnologías Utilizadas

- **Frontend**: Vue.js, Pinia (no implementado), CSS.
- **Backend**: .NET, JWT, AutoMapper, SQL.

Este sistema proporciona una base sólida para la gestión de clasificados con una estructura organizada y preparada para futuras ampliaciones.
