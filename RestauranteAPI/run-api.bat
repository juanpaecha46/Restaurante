@echo off
REM Script para ejecutar la API RestauranteAPI
REM Este script ejecuta la API desde C:\temp\RestauranteAPI

color 0A
echo.
echo ========================================
echo   RestauranteAPI - Servidor de desarrollo
echo ========================================
echo.

cd /d "C:\temp\RestauranteAPI"

if not exist "RestauranteAPI.csproj" (
    echo ERROR: No se encontro el proyecto en C:\temp\RestauranteAPI
    pause
    exit /b 1
)

echo Iniciando API...
echo.
echo Una vez ejecutandose, accede a:
echo   - API:     http://localhost:5165/api
echo   - Swagger: http://localhost:5165/swagger
echo.
echo Presiona Ctrl+C para detener el servidor
echo.

dotnet run

pause
