# Stage 1: Build the .NET application
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-dotnet
WORKDIR /src
COPY ["HR Service/HR Service.csproj", "HR Service/"]
RUN dotnet restore "HR Service/HR Service.csproj"
COPY . .
WORKDIR "/src/HR Service"
RUN dotnet build "HR Service.csproj" -c Release -o /app/build

# Stage 2: Publish the .NET application
FROM build-dotnet AS publish-dotnet
RUN dotnet publish "HR Service.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Stage 3: Build and run Redis
FROM redis:latest AS build-redis
WORKDIR /usr/src/app
COPY Config/redis.conf .
EXPOSE 6379
CMD ["redis-server", "redis.conf"]

# Stage 4: Build the final image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app
COPY --from=publish-dotnet /app/publish .
COPY --from=build-redis /usr/local/bin/redis-server /usr/local/bin/
COPY --from=build-redis /usr/src/app/redis.conf .
EXPOSE 80
EXPOSE 443
ENTRYPOINT ["dotnet", "HR Service.dll"]