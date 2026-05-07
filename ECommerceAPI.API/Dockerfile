# Schritt 1 - Build
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Projektdateien kopieren
COPY ["ECommerceAPI.API/ECommerceAPI.API.csproj", "ECommerceAPI.API/"]
COPY ["ECommerceAPI.Application/ECommerceAPI.Application.csproj", "ECommerceAPI.Application/"]
COPY ["ECommerceAPI.Domain/ECommerceAPI.Domain.csproj", "ECommerceAPI.Domain/"]
COPY ["ECommerceAPI.Infrastructure/ECommerceAPI.Infrastructure.csproj", "ECommerceAPI.Infrastructure/"]

# Pakete wiederherstellen
RUN dotnet restore "ECommerceAPI.API/ECommerceAPI.API.csproj"

# Code kopieren und bauen
COPY . .
RUN dotnet build "ECommerceAPI.API/ECommerceAPI.API.csproj" -c Release -o /app/build

# Schritt 2 - Publish
FROM build AS publish
RUN dotnet publish "ECommerceAPI.API/ECommerceAPI.API.csproj" -c Release -o /app/publish

# Schritt 3 - Runtime Image
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ECommerceAPI.API.dll"]