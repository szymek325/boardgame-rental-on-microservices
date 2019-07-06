FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["Clients.Api/Clients.Api.csproj", "Clients.Api/"]
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