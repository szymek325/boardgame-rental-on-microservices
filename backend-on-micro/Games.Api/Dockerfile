FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Games.Api/Games.Api.csproj", "Games.Api/"]
COPY ["Service.Common/Service.Common.csproj", "Service.Common/"]
RUN dotnet restore "Games.Api/Games.Api.csproj"
COPY . .
WORKDIR "/src/Games.Api"
RUN dotnet build "Games.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Games.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Games.Api.dll"]
