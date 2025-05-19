# === 1. Build stage ===
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Zkopíruj celý obsah projektu do kontejneru
COPY . ./

# Obnovení závislostí
RUN dotnet restore AspBlog.csproj

# Publish do složky out
RUN dotnet publish AspBlog.csproj -c Release -o out

# === 2. Runtime stage ===
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app

# Zkopíruj publishnutý obsah z předchozího kroku
COPY --from=build /app/out ./

# Exponuj port 80 (standardní HTTP)
EXPOSE 80

# Spusť aplikaci
ENTRYPOINT ["dotnet", "AspBlog.dll"]
