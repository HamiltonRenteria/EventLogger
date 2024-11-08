# Event Logger - API y Aplicación Web

**Event Logger** es una aplicación completa que permite a los usuarios registrar y consultar eventos en una base de datos, con autenticación de usuarios mediante JWT. El proyecto está compuesto por una **API** desarrollada en .NET 6 para gestionar el backend y una **aplicación web** en Angular que sirve como frontend para interactuar con la API.

## Tabla de Contenidos

- [Tecnologías Utilizadas](#tecnologías-utilizadas)
- [Estructura del Proyecto](#estructura-del-proyecto)
- [Configuración del Backend (API en .NET 6)](#configuración-del-backend-api-en-net-6)
  - [Migraciones y Base de Datos](#migraciones-y-base-de-datos)
  - [Ejecutar la API](#ejecutar-la-api)
- [Configuración del Frontend (Aplicación en Angular)](#configuración-del-frontend-aplicación-en-angular)
  - [Ejecutar la Aplicación Angular](#ejecutar-la-aplicación-angular)
- [Flujo de Autenticación](#flujo-de-autenticación)
- [Ejecución Completa del Proyecto](#ejecución-completa-del-proyecto)
- [Notas Adicionales](#notas-adicionales)

---

### Tecnologías Utilizadas

- **Backend**: .NET 6, Entity Framework Core, SQL Server/MySQL para la base de datos, JSON Web Tokens (JWT) para autenticación.
- **Frontend**: Angular, Angular HttpClient.
- **Database**: SQL Server o MySQL (configurable en `appsettings.json`).
- **Cliente HTTP**: Angular HttpClient.
- **Docker**: (opcional) para contenerización y despliegue.

### Estructura del Proyecto

El proyecto está organizado en dos carpetas principales:

1. **API (Backend)**: Contiene la implementación de la API en .NET 6.
2. **Aplicación Web (Frontend)**: Contiene el proyecto Angular para la interfaz de usuario.

---

## Configuración del Backend (API en .NET 6)

1. **Clonar el repositorio**

   ```bash
   git clone https://github.com/tuusuario/event-logger.git
   cd event-logger/api

2. **Configurar la Base de Datos**

   "ConnectionStrings": {
     "DefaultConnection": "Server=TU_SERVIDOR;Database=Registration;User Id=TU_USUARIO;Password=TU_CONTRASEÑA;"
     }

3. **Migraciones y Base de Datos**
     dotnet ef migrations add InitialCreate
     dotnet ef database update

4. **Ejecutar la API**
     dotnet run
     Nota: La API debería estar disponible en https://localhost:7026/.


## Configuración del Frontend (Aplicación en Angular)

1. **Instalar Dependencias**

   ```bash
   cd ../frontend
     npm install


2. **Configurar la URL de la API**

   Abre el archivo src/app/services/event.service.ts y ajusta la URL base de la API si es necesario.

3. **Ejecutar la Aplicación Angular**
     ng serve
     Nota: La aplicación estará disponible en http://localhost:4200.

