FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["Gateway/Gateway.Api.Ocelot/Gateway.Api.Ocelot.csproj", "Gateway/Gateway.Api.Ocelot/"]
RUN dotnet restore "Gateway/Gateway.Api.Ocelot/Gateway.Api.Ocelot.csproj"
COPY . .
WORKDIR "/src/Gateway/Gateway.Api.Ocelot"
RUN dotnet build "Gateway.Api.Ocelot.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Gateway.Api.Ocelot.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Gateway.Api.Ocelot.dll"]