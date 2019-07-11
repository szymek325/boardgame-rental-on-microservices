FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["Services/Clients.Api/Clients.Api.csproj", "Services/Clients.Api/"]
COPY ["Services/Service.Common/Service.Common.csproj", "Services/Service.Common/"]
RUN dotnet restore "Services/Clients.Api/Clients.Api.csproj"
COPY . .
WORKDIR "/src/Services/Clients.Api"
RUN dotnet build "Clients.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Clients.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Clients.Api.dll"]