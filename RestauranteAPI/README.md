# RestauranteAPI - Web API .NET Core 10

Sistema completo de gestión de restaurante con API RESTful desarrollado en .NET Core 10.

## Características

- **Gestión de Usuarios**: CRUD completo de usuarios con autenticación
- **Inventario**: Control de ingredientes y stock
- **Productos**: Catálogo de productos del menú
- **Adiciones**: Opciones adicionales para productos
- **Facturas**: Generación y control de facturas
- **Medios de Pago**: Configuración de métodos de pago
- **Reservas**: Sistema de reservas de mesas
- **Órdenes**: Gestión completa de pedidos
- **Direcciones**: Gestión de direcciones de entrega
- **Domicilios**: Control de pedidos a domicilio
- **Recomendaciones IA**: Sistema de sugerencias basadas en compras
- **Autenticación**: Login, logout y recuperación de contraseña

## Requisitos Previos

- .NET Core 10 SDK
- SQL Server (LocalDB o SQL Server Express)
- Visual Studio Code o Visual Studio

## Estructura del Proyecto

```
RestauranteAPI/
├── Controllers/       # Controladores de la API
├── Models/           # Modelos de dominio
├── Services/         # Lógica de negocio
├── Data/             # DbContext y configuración de BD
├── DTOs/             # Objetos de transferencia de datos
├── Properties/       # Configuración del proyecto
└── appsettings.json  # Configuración de aplicación
```

## Instalación

1. **Clonar el repositorio**
```bash
git clone <url-repo>
cd RestauranteAPI
```

2. **Restaurar paquetes NuGet**
```bash
dotnet restore
```

3. **Configurar la cadena de conexión**
Editar `appsettings.json`:
```json
"ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=RestauranteDB;Trusted_Connection=true;"
}
```

4. **Crear la base de datos**
```bash
dotnet ef database update
```

5. **Ejecutar la aplicación**
```bash
dotnet run
```

La API estará disponible en `https://localhost:7212` y la documentación Swagger en `/swagger`

## Endpoints Principales

### Usuarios
- `GET /api/usuarios` - Obtener todos los usuarios
- `GET /api/usuarios/{id}` - Obtener usuario por ID
- `POST /api/usuarios` - Crear nuevo usuario
- `PUT /api/usuarios/{id}` - Actualizar usuario completo
- `PATCH /api/usuarios/{id}` - Actualizar usuario parcial
- `DELETE /api/usuarios/{id}` - Eliminar usuario

### Productos
- `GET /api/productos` - Obtener todos los productos
- `GET /api/productos/{id}` - Obtener producto por ID
- `POST /api/productos` - Crear nuevo producto
- `PUT /api/productos/{id}` - Actualizar producto completo
- `PATCH /api/productos/{id}` - Actualizar producto parcial
- `DELETE /api/productos/{id}` - Eliminar producto

### Órdenes
- `GET /api/ordenes` - Obtener todas las órdenes
- `GET /api/ordenes/{id}` - Obtener orden por ID
- `POST /api/ordenes` - Crear nueva orden
- `PUT /api/ordenes/{id}` - Actualizar orden completa
- `PATCH /api/ordenes/{id}` - Actualizar orden parcial
- `PATCH /api/ordenes/{id}/estado` - Actualizar estado de orden
- `DELETE /api/ordenes/{id}` - Eliminar orden

### Autenticación
- `POST /api/auth/login` - Iniciar sesión
- `POST /api/auth/logout` - Cerrar sesión
- `POST /api/auth/recuperar-password` - Recuperar contraseña
- `PATCH /api/auth/cambiar-password` - Cambiar contraseña
- `GET /api/auth/perfil` - Obtener perfil del usuario

### Recomendaciones IA
- `GET /api/recomendaciones/{clienteId}` - Obtener recomendaciones
- `POST /api/recomendaciones/generar` - Generar nuevas recomendaciones

Y más endpoints para:
- `/api/inventario` - Gestión de inventario
- `/api/adiciones` - Gestión de adiciones
- `/api/facturas` - Gestión de facturas
- `/api/medios-pago` - Gestión de medios de pago
- `/api/reservas` - Gestión de reservas
- `/api/direcciones` - Gestión de direcciones
- `/api/domicilios` - Gestión de domicilios

## Configuración de JWT

Para producción, configurar JWT en `appsettings.json`:
```json
"Jwt": {
    "SecretKey": "your-super-secret-key-change-this-in-production",
    "Issuer": "RestauranteAPI",
    "Audience": "RestauranteAPIUsers",
    "ExpirationMinutes": 60
}
```

## Documentación API

Una vez ejecutada la aplicación, acceder a Swagger en:
```
https://localhost:7212/swagger
```

## Seguridad

- Implementar autenticación JWT en todos los endpoints protegidos
- Usar HTTPS en producción
- Implementar rate limiting
- Validar todas las entradas
- Usar CORS apropiadamente

## Próximas Mejoras

- [ ] Implementación completa de JWT
- [ ] Envío de emails
- [ ] Paaginación en endpoints
- [ ] Filtros avanzados
- [ ] Caching
- [ ] Logging centralizado
- [ ] Unit tests
- [ ] Integration tests

## Licencia

Este proyecto está bajo la licencia MIT.

## Autor

Proyecto creado para gestión de restaurante.
