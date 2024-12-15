FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["SM.OrderConsumer/SM.OrderConsumer.csproj", "SM.OrderConsumer/"]
RUN dotnet restore "SM.OrderConsumer/SM.OrderConsumer.csproj"
COPY . .
WORKDIR "/src/SM.OrderConsumer"
RUN dotnet build "SM.OrderConsumer.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "SM.OrderConsumer.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SM.OrderConsumer.dll"]
