FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Clients.Api/Clients.Api.csproj", "Clients.Api/"]
COPY ["Service.Common/Service.Common.csproj", "Service.Common/"]
RUN dotnet restore "Clients.Api/Clients.Api.csproj"
COPY . .
WORKDIR "/src/Clients.Api"
RUN dotnet build "Clients.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Clients.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Clients.Api.dll"]
