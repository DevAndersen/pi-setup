# Base
FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS base
WORKDIR "/work"

# Frontend
FROM base AS frontend
COPY "./site/DevAndersen.Pi.Site.Web/libman.json" "."
RUN apk add --no-cache sassc \
 && dotnet tool install microsoft.web.librarymanager.cli --tool-path "/bin" \
 && libman restore \
 && mkdir "./wwwroot/css"
COPY "./site/DevAndersen.Pi.Site.Web/wwwroot/scss/**" "./wwwroot/scss/"
RUN sassc --style compressed "./wwwroot/scss/site.scss" "./wwwroot/css/site.min.css"

# Backend
FROM base AS build
COPY "./site/DevAndersen.Pi.Site.Core/DevAndersen.Pi.Site.Core.csproj" "./DevAndersen.Pi.Site.Core/"
COPY "./site/DevAndersen.Pi.Site.Web/DevAndersen.Pi.Site.Web.csproj" "./DevAndersen.Pi.Site.Web/"
RUN dotnet restore "./DevAndersen.Pi.Site.Core/DevAndersen.Pi.Site.Core.csproj" \
 && dotnet restore "./DevAndersen.Pi.Site.Web/DevAndersen.Pi.Site.Web.csproj"
COPY "./site" "./"
RUN dotnet publish "./DevAndersen.Pi.Site.Web/" -c Release -o "./publish"

# Publish
FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine
WORKDIR "/app"
COPY --from=build "/work/publish" "."
COPY --from=frontend "/work/wwwroot" "./wwwroot"
ENTRYPOINT ["dotnet", "DevAndersen.Pi.Site.Web.dll"]
