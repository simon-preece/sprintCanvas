# sprintCanvas

Kanban Board app

## Azure App Service deployment

This repository contains a Blazor Server app in the `sprintCanvas` folder. The initial GitHub Actions workflow deploys the app to Azure App Service when code is pushed to `main`.

### GitHub Actions workflow

- File: `.github/workflows/azure-app-service.yml`
- Runs on `main` branch
- Restores and publishes the `sprintCanvas/sprintCanvas.csproj`
- Deploys using `azure/webapps-deploy@v4`

### Required GitHub secrets

Add these repository secrets:

- `AZURE_WEBAPP_NAME` — the App Service name
- `AZURE_WEBAPP_PUBLISH_PROFILE` — the Azure publish profile XML content

### Azure resource creation (App Service free tier)

If you wish to use this template for your own project you can use the Azure CLI or Azure portal to create resources. Example CLI commands:

```bash
az login
az group create --name sprintCanvas-rg --location westuk
az appservice plan create --name sprintCanvas-plan --resource-group sprintCanvas-rg --sku F1 --is-linux
az webapp create --resource-group sprintCanvas-rg --plan sprintCanvas-plan --name <your-unique-app-name> --runtime "DOTNET|10" --deployment-local-git
```

Then download the publish profile and add it to GitHub secrets.

### Local development

From the `sprintCanvas` folder:

**Install and build dependencies:**

```bash
dotnet restore sprintCanvas.csproj
dotnet build sprintCanvas.csproj
```

**Run locally:**

```bash
dotnet run --project sprintCanvas.csproj
```

Then visit `https://localhost:7243` (or the URL shown in console).

**For hot reload during development:**

```bash
dotnet watch run --project sprintCanvas.csproj
```

### Production build and publish

Before committing, validate the production build:

```bash
dotnet restore sprintCanvas.csproj
dotnet build sprintCanvas.csproj -c Release
dotnet publish sprintCanvas.csproj -c Release -o publish
```

The GitHub Actions workflow automatically runs these steps on push to `main` and deploys the `publish` output to Azure.
