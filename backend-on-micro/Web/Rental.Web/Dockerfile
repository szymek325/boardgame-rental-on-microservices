FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["Web/Rental.Web/Rental.Web.csproj", "Web/Rental.Web/"]
RUN dotnet restore "Web/Rental.Web/Rental.Web.csproj"
COPY . .
WORKDIR "/src/Web/Rental.Web"
RUN dotnet build "Rental.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Rental.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Rental.Web.dll"]