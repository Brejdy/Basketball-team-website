# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY . .

WORKDIR /src/AspBlog

# Restore + Publish
RUN dotnet restore AspBlog.csproj
RUN dotnet publish AspBlog.csproj -c Release -o /app/publish

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish ./
EXPOSE 80
ENTRYPOINT ["dotnet", "AspBlog.dll"]
