# Configuración de Base de Datos

## Crear Migración Inicial

Para crear la migración inicial, ejecuta:

```bash
dotnet ef migrations add InitialCreate
```

## Aplicar Migración a la Base de Datos

Para crear la base de datos y aplicar las migraciones:

```bash
dotnet ef database update
```

O usa la tarea de VS Code:
- Abre la paleta de comandos con Ctrl+Shift+P
- Escribe "Run Task"
- Selecciona "db-update"

## Revertir Migraciones

Para revertir la última migración:

```bash
dotnet ef database update <NombreMigracionAnterior>
```

## Eliminar una Migración

```bash
dotnet ef migrations remove
```

## Listar Migraciones

```bash
dotnet ef migrations list
```

## Ejecutar la Aplicación

### Modo Development

```bash
dotnet run
```

O presiona F5 en VS Code para iniciar en debug.

### Modo Watch (recompila automáticamente)

```bash
dotnet watch run
```

## Variables de Entorno

La cadena de conexión se configura en `appsettings.json`. En producción, usa variables de entorno:

```powershell
# PowerShell
$env:ConnectionStrings__DefaultConnection = "Server=tu-servidor;Database=RestauranteDB;User Id=sa;Password=tu-password;"
```

## Verificar la Base de Datos

Una vez aplicadas las migraciones, puedes verificar la base de datos con SQL Server Management Studio o similar.
