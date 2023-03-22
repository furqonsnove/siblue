#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["HR Service/HR Service.csproj", "HR Service/"]
RUN dotnet restore "HR Service/HR Service.csproj"
COPY . .
WORKDIR "/src/HR Service"
RUN dotnet build "HR Service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HR Service.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HR Service.dll"]