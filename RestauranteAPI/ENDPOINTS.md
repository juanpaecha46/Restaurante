# Documentación de Endpoints API

## Base URL
```
https://localhost:7212/api
```

## Autenticación

### Login
```
POST /auth/login
Content-Type: application/json

{
  "email": "usuario@ejemplo.com",
  "password": "contraseña"
}

Response 200:
{
  "token": "jwt-token-aqui"
}
```

### Logout
```
POST /auth/logout
Content-Type: application/json

{
  "usuarioId": 1
}
```

### Recuperar Contraseña
```
POST /auth/recuperar-password
Content-Type: application/json

{
  "email": "usuario@ejemplo.com"
}
```

### Cambiar Contraseña
```
PATCH /auth/cambiar-password
Content-Type: application/json

{
  "usuarioId": 1,
  "passwordActual": "contraseña-actual",
  "nuevaPassword": "nueva-contraseña"
}
```

### Obtener Perfil
```
GET /auth/perfil?usuarioId=1
```

---

## Usuarios

### Obtener todos los usuarios
```
GET /usuarios
```

### Obtener usuario por ID
```
GET /usuarios/{id}
```

### Crear nuevo usuario
```
POST /usuarios
Content-Type: application/json

{
  "nombre": "Juan Pérez",
  "email": "juan@ejemplo.com",
  "telefono": "1234567890",
  "passwordHash": "hashedPassword",
  "rol": "Usuario"
}
```

### Actualizar usuario completamente
```
PUT /usuarios/{id}
Content-Type: application/json

{
  "id": 1,
  "nombre": "Juan Actualizado",
  "email": "juan@ejemplo.com",
  "telefono": "9876543210",
  "passwordHash": "hashedPassword",
  "rol": "Usuario"
}
```

### Actualizar usuario parcialmente
```
PATCH /usuarios/{id}
Content-Type: application/json-patch+json

[
  {
    "op": "replace",
    "path": "/nombre",
    "value": "Nuevo Nombre"
  }
]
```

### Eliminar usuario
```
DELETE /usuarios/{id}
```

---

## Productos

### Obtener todos los productos
```
GET /productos
```

### Obtener producto por ID
```
GET /productos/{id}
```

### Crear producto
```
POST /productos
Content-Type: application/json

{
  "nombre": "Hamburguesa",
  "descripcion": "Hamburguesa clasica",
  "precio": 15.99,
  "categoria": "Comidas",
  "disponible": true
}
```

### Actualizar producto
```
PUT /productos/{id}
```

### Actualizar parcialmente
```
PATCH /productos/{id}
```

### Eliminar producto
```
DELETE /productos/{id}
```

---

## Órdenes

### Obtener todas las órdenes
```
GET /ordenes
```

### Obtener orden por ID
```
GET /ordenes/{id}
```

### Crear orden
```
POST /ordenes
Content-Type: application/json

{
  "usuarioId": 1,
  "total": 50.00,
  "medioPagoId": 1,
  "tipo": "Local",
  "detalles": [
    {
      "productoId": 1,
      "cantidad": 2,
      "precioUnitario": 15.99,
      "adiciones": [
        {
          "adicionId": 1,
          "precio": 2.00
        }
      ]
    }
  ]
}
```

### Actualizar estado de orden
```
PATCH /ordenes/{id}/estado
Content-Type: application/json

{
  "estado": "Completada"
}
```

### Estados disponibles
```
GET /estados-pedido
```

### Eliminar orden
```
DELETE /ordenes/{id}
```

---

## Inventario

### Obtener todo el inventario
```
GET /inventario
```

### Obtener ingrediente por ID
```
GET /inventario/{id}
```

### Registrar nuevo ingrediente
```
POST /inventario
Content-Type: application/json

{
  "nombre": "Pollo",
  "descripcion": "Pollo fresco",
  "cantidad": 50,
  "unidad": "kg",
  "precioUnitario": 5.00,
  "cantidadMinima": 10
}
```

### Actualizar ingrediente
```
PUT /inventario/{id}
```

### Actualizar stock parcialmente
```
PATCH /inventario/{id}
Content-Type: application/json

[
  {
    "op": "replace",
    "path": "/cantidad",
    "value": 45
  }
]
```

### Eliminar ingrediente
```
DELETE /inventario/{id}
```

---

## Adiciones

### Obtener todas las adiciones
```
GET /adiciones
```

### Registrar adición
```
POST /adiciones
Content-Type: application/json

{
  "nombre": "Queso extra",
  "precio": 2.50,
  "activo": true
}
```

### Actualizar adición
```
PUT /adiciones/{id}
```

### Actualizar parcialmente
```
PATCH /adiciones/{id}
```

### Eliminar adición
```
DELETE /adiciones/{id}
```

---

## Facturas

### Obtener todas las facturas
```
GET /facturas
```

### Obtener factura por ID
```
GET /facturas/{id}
```

### Generar nueva factura
```
POST /facturas
Content-Type: application/json

{
  "usuarioId": 1,
  "ordenId": 1,
  "subTotal": 50.00,
  "impuesto": 8.50,
  "total": 58.50,
  "estado": "Pendiente"
}
```

### Actualizar factura
```
PUT /facturas/{id}
```

### Actualizar parcialmente
```
PATCH /facturas/{id}
```

### Eliminar factura
```
DELETE /facturas/{id}
```

---

## Medios de Pago

### Obtener medios de pago
```
GET /medios-pago
```

### Registrar medio de pago
```
POST /medios-pago
Content-Type: application/json

{
  "nombre": "Tarjeta Crédito",
  "descripcion": "Visa, Mastercard, American Express"
}
```

### Actualizar medio de pago
```
PUT /medios-pago/{id}
```

### Actualizar parcialmente
```
PATCH /medios-pago/{id}
```

### Eliminar medio de pago
```
DELETE /medios-pago/{id}
```

---

## Reservas

### Obtener todas las reservas
```
GET /reservas
```

### Obtener reserva por ID
```
GET /reservas/{id}
```

### Registrar reserva
```
POST /reservas
Content-Type: application/json

{
  "usuarioId": 1,
  "mesa": 5,
  "numeroPersonas": 4,
  "fechaReserva": "2024-06-15",
  "horaReserva": "19:00",
  "estado": "Confirmada"
}
```

### Actualizar reserva
```
PUT /reservas/{id}
```

### Modificar fecha, mesa o estado
```
PATCH /reservas/{id}
```

### Cancelar reserva
```
DELETE /reservas/{id}
```

---

## Direcciones

### Obtener direcciones
```
GET /direcciones
```

### Registrar dirección
```
POST /direcciones
Content-Type: application/json

{
  "usuarioId": 1,
  "calle": "Calle Principal",
  "numero": "123",
  "apartamento": "A",
  "ciudad": "Bogotá",
  "departamento": "Cundinamarca",
  "codigoPostal": "110111",
  "esPrincipal": true
}
```

### Actualizar dirección
```
PUT /direcciones/{id}
```

### Modificar datos
```
PATCH /direcciones/{id}
```

### Eliminar dirección
```
DELETE /direcciones/{id}
```

---

## Domicilios (Pedidos a Domicilio)

### Obtener pedidos a domicilio
```
GET /domicilios
```

### Obtener domicilio específico
```
GET /domicilios/{id}
```

### Registrar nuevo domicilio
```
POST /domicilios
Content-Type: application/json

{
  "ordenId": 1,
  "direccionId": 1,
  "repartidorId": null,
  "estado": "Pendiente"
}
```

### Actualizar domicilio
```
PUT /domicilios/{id}
```

### Actualizar estado o repartidor
```
PATCH /domicilios/{id}
Content-Type: application/json

[
  {
    "op": "replace",
    "path": "/estado",
    "value": "En Camino"
  }
]
```

### Cancelar domicilio
```
DELETE /domicilios/{id}
```

---

## Recomendaciones (IA)

### Obtener sugerencias para un cliente
```
GET /recomendaciones/{clienteId}
```

### Generar nuevas recomendaciones
```
POST /recomendaciones/generar
```

---

## Códigos de Respuesta HTTP

| Código | Significado |
|--------|------------|
| 200 | OK - Solicitud exitosa |
| 201 | Created - Recurso creado |
| 204 | No Content - Actualización exitosa |
| 400 | Bad Request - Solicitud inválida |
| 401 | Unauthorized - No autenticado |
| 403 | Forbidden - Prohibido |
| 404 | Not Found - Recurso no encontrado |
| 500 | Internal Server Error - Error del servidor |

---

## Documentación Interactiva

Una vez iniciada la aplicación, accede a Swagger UI en:
```
https://localhost:7212/swagger
```
