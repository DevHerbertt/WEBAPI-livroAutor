# WebAPI - Projeto ASP.NET Core

## 🚀 Como Iniciar o Projeto

### Pré-requisitos
- .NET 8.0 SDK
- SQL Server (instância: `DEV\SQLEXPRESS01`)
- Visual Studio 2022 ou VS Code

### Configuração Inicial

1. **Configurar Connection String**
   - Edite `appsettings.json` e verifique a connection string:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=DEV\\SQLEXPRESS01;Database=WebApiAulaVideo;Trusted_Connection=True;TrustServerCertificate=true"
   }
   ```

2. **Executar Migrations**
   ```bash
   dotnet ef database update
   ```

3. **Executar o Projeto**
   ```bash
   dotnet run
   ```

## ⚠️ Problema Comum: Arquivo Bloqueado

Se você encontrar o erro:
```
The file is locked by: "WebAPI (PID)"
```

### Solução Rápida

**Opção 1: Usar o Script PowerShell**
```powershell
.\stop-webapi.ps1
```

**Opção 2: Finalizar Manualmente**
```powershell
# Encontrar o PID do processo
Get-Process | Where-Object {$_.ProcessName -eq "WebAPI"}

# Finalizar o processo (substitua PID pelo número encontrado)
taskkill /F /PID <PID>
```

**Opção 3: Finalizar Todos os Processos WebAPI**
```powershell
Get-Process | Where-Object {$_.ProcessName -eq "WebAPI"} | Stop-Process -Force
```

### Como Evitar

1. **Sempre pare a aplicação antes de compilar:**
   - No terminal: `Ctrl+C`
   - No Visual Studio: Parar Debug (Shift+F5)
   - No VS Code: Parar o processo no terminal

2. **Use o script `stop-webapi.ps1`** antes de compilar se tiver dúvidas

## 📋 Endpoints Disponíveis

Após iniciar, acesse:
- **Swagger UI**: `http://localhost:5174/swagger` ou `https://localhost:7171/swagger`
- **API Base**: `http://localhost:5174/api` ou `https://localhost:7171/api`

## 🔧 Comandos Úteis

```bash
# Compilar o projeto
dotnet build

# Executar o projeto
dotnet run

# Executar migrations
dotnet ef database update

# Criar nova migration
dotnet ef migrations add NomeDaMigration

# Limpar e recompilar
dotnet clean
dotnet build
```

## 📚 Estrutura do Projeto

```
WebAPI/
├── Controllers/          # Controllers da API
├── Data/                # DbContext e configurações de banco
├── Models/              # Modelos de dados
├── services/            # Serviços de negócio
├── Migrations/          # Migrations do Entity Framework
└── Program.cs           # Configuração principal
```

## 🐛 Troubleshooting

### Erro de Conexão com Banco de Dados
- Verifique se o SQL Server está rodando
- Confirme o nome da instância em `appsettings.json`
- Verifique se o banco `WebApiAulaVideo` existe

### Erro de Compilação
- Execute `dotnet clean` e depois `dotnet build`
- Verifique se todas as dependências estão instaladas: `dotnet restore`

### Porta já em uso
- Altere a porta em `Properties/launchSettings.json`
- Ou finalize o processo que está usando a porta


