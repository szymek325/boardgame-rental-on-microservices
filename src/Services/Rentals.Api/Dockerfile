FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["Services/Rentals.Api/Rentals.Api.csproj", "Services/Rentals.Api/"]
COPY ["Services/Service.Common/Service.Common.csproj", "Services/Service.Common/"]
RUN dotnet restore "Services/Rentals.Api/Rentals.Api.csproj"
COPY . .
WORKDIR "/src/Services/Rentals.Api"
RUN dotnet build "Rentals.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Rentals.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Rentals.Api.dll"]