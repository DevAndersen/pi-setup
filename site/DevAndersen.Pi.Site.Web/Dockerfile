#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["site/DevAndersen.Pi.Site.Web/DevAndersen.Pi.Site.Web.csproj", "site/DevAndersen.Pi.Site.Web/"]
RUN dotnet restore "site/DevAndersen.Pi.Site.Web/DevAndersen.Pi.Site.Web.csproj"
COPY . .
WORKDIR "/src/site/DevAndersen.Pi.Site.Web"
RUN dotnet build "DevAndersen.Pi.Site.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DevAndersen.Pi.Site.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DevAndersen.Pi.Site.Web.dll"]