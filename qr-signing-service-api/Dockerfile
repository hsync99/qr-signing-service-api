#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["qr-signing-service-api/qr-signing-service-api.csproj", "qr-signing-service-api/"]
RUN dotnet restore "qr-signing-service-api/qr-signing-service-api.csproj"
COPY . .
WORKDIR "/src/qr-signing-service-api"
RUN dotnet build "qr-signing-service-api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "qr-signing-service-api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "qr-signing-service-api.dll"]