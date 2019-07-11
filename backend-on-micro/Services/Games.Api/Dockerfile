FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["Services/Games.Api/Games.Api.csproj", "Services/Games.Api/"]
COPY ["Services/Service.Common/Service.Common.csproj", "Services/Service.Common/"]
RUN dotnet restore "Services/Games.Api/Games.Api.csproj"
COPY . .
WORKDIR "/src/Services/Games.Api"
RUN dotnet build "Games.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Games.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Games.Api.dll"]