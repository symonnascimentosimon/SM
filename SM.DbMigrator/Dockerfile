FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["SM.DbMigrator/SM.DbMigrator.csproj", "SM.DbMigrator/"]
RUN dotnet restore "SM.DbMigrator/SM.DbMigrator.csproj"
COPY . .
WORKDIR "/src/SM.DbMigrator"
RUN dotnet build "SM.DbMigrator.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "SM.DbMigrator.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SM.DbMigrator.dll"]
