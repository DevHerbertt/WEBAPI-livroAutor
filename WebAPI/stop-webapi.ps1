# Script para finalizar processos WebAPI que estão bloqueando a compilação
# Uso: .\stop-webapi.ps1

Write-Host "Procurando processos WebAPI..." -ForegroundColor Yellow

$processes = Get-Process | Where-Object {$_.ProcessName -eq "WebAPI"}

if ($processes) {
    Write-Host "Encontrados $($processes.Count) processo(s) WebAPI:" -ForegroundColor Yellow
    foreach ($proc in $processes) {
        Write-Host "  - PID: $($proc.Id) | Path: $($proc.Path)" -ForegroundColor Cyan
    }
    
    $processes | Stop-Process -Force
    Write-Host "`nProcessos WebAPI finalizados com sucesso!" -ForegroundColor Green
} else {
    Write-Host "Nenhum processo WebAPI encontrado." -ForegroundColor Green
}

Write-Host "`nAgora você pode compilar/executar o projeto normalmente." -ForegroundColor Green


