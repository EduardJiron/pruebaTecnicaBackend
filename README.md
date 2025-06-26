
# BancoAPI

BancoAPI es una API REST desarrollada con **ASP.NET Core 8** que permite gestionar operaciones bancarias básicas como:

- Creación de cuentas bancarias
- Depósitos y retiros
- Aplicación de intereses
- Consulta de saldo e historial de transacciones

## Tecnologías utilizadas

- ASP.NET Core 8
- Entity Framework Core (SQLite)
- xUnit (pruebas unitarias)
- Moq (mocking para pruebas)
- Swagger (documentación de la API)

## Requisitos previos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- Git (opcional, para clonar el repositorio)

## Ejecución del proyecto

1. Clona este repositorio:
   ```bash
   git clone https://github.com/eduardjiron/pruebaTecnicaBackend.git
   cd BancoAPI
Restaura los paquetes:

dotnet restore

Ejecuta la API:


dotnet run --project BancoAPI

Accede a la documentación Swagger desde tu navegador:


https://localhost:{puerto}/swagger
Ejecutar pruebas unitarias
Ve al proyecto de pruebas:


cd BancoAPI.Tests
Ejecuta los tests:

dotnet test
Qué pruebas incluye:
Creación de cuenta bancaria

Depósito y retiro

Aplicación de intereses

Consulta de saldo e historial de transacciones

Notas adicionales

El archivo .db de SQLite se genera automáticamente al ejecutar la API.

El proyecto está configurado con Inyección de Dependencias usando AddScoped en Program.cs.


