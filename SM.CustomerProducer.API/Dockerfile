FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["SM.OrderProducer/SM.OrderProducer.csproj", "SM.OrderProducer/"]
RUN dotnet restore "SM.OrderProducer/SM.OrderProducer.csproj"
COPY . .
WORKDIR "/src/SM.OrderProducer"
RUN dotnet build "SM.OrderProducer.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "SM.OrderProducer.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SM.OrderProducer.dll"]
