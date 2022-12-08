# Prueba Tecnica TP
Prueba técnica 

Tienda Virual

Técnologías utilizada
Angular Version 12
Asp.Net 6
SQL Server

# Pasos para ejecutar la prueba
1. Crear la base de datos ejecutando el archivo "1-CrearBaseDeDatos.sql"
2. Crear las tablas y los datos ejecutando el archivo "2-CrearTablasYDatos"
3. Abrir la solución utilizando Visual Studio tienda-virtual-api.sln ubicada en la ruta \tienda-virtual-api
4. verificar que el archivo launchSettings.json tenga el puerto 7028
{
  "$schema": "https://json.schemastore.org/launchsettings.json",
  "iisSettings": {
    "windowsAuthentication": false,
    "anonymousAuthentication": true,
    "iisExpress": {
      "applicationUrl": "http://localhost:27763",
      "sslPort": 44388
    }
  },
  "profiles": {
    "TiendaVitual.API": {
      "commandName": "Project",
      "dotnetRunMessages": true,
      "launchBrowser": true,
      "launchUrl": "swagger",
      "applicationUrl": "https://localhost:7028;http://localhost:5261",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    },
    "IIS Express": {
      "commandName": "IISExpress",
      "launchBrowser": true,
      "launchUrl": "swagger",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    }
  }
}

5. Cambiar la cadena de conexión a la base de datos en la clase "TiendaVitualBD" en el proyecto TiendaVirtual.Datos si es requerido.
6. Abrir tienda-virtual usando visual studio code
7. abrir la consola en la ruta tienda-virtual y ejecutar el comandos 
    npm install
    ng serve (o npm start)





