#!/usr/bin/env pwsh
# Script para ejecutar la API RestauranteAPI desde C:\temp
# Uso: .\run-api.ps1

Write-Host "========================================" -ForegroundColor Cyan
Write-Host "  RestauranteAPI - Servidor de desarrollo" -ForegroundColor Green
Write-Host "========================================" -ForegroundColor Cyan
Write-Host ""

$apiPath = "C:\temp\RestauranteAPI"

if (-not (Test-Path $apiPath)) {
    Write-Host "ERROR: No se encontró el proyecto en $apiPath" -ForegroundColor Red
    exit 1
}

Write-Host "Iniciando API desde: $apiPath" -ForegroundColor Yellow
Write-Host ""
Write-Host "Una vez ejecutándose, accede a:" -ForegroundColor Cyan
Write-Host "  - API:     http://localhost:5165/api" -ForegroundColor Green
Write-Host "  - Swagger: http://localhost:5165/swagger" -ForegroundColor Green
Write-Host ""
Write-Host "Presiona Ctrl+C para detener el servidor" -ForegroundColor Yellow
Write-Host ""

Set-Location $apiPath
& dotnet run
