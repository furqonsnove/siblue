FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["siblue/siblue.csproj", "siblue/"]
RUN dotnet restore "siblue/siblue.csproj"
COPY . .
WORKDIR "/src/siblue"
RUN dotnet build "siblue.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "siblue.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "siblue.dll"]
