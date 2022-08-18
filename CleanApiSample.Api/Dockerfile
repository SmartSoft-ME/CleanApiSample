#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build
WORKDIR /src
COPY ["CleanApiSample.Api/CleanApiSample.Api.csproj", "CleanApiSample.Api/"]
COPY ["CleanApiSample.Application/CleanApiSample.Application.csproj", "CleanApiSample.Application/"]
COPY ["CleanApiSample.Domain/CleanApiSample.Domain.csproj", "CleanApiSample.Domain/"]
COPY ["CleanApiSample.Shared/CleanApiSample.Shared.csproj", "CleanApiSample.Shared/"]
COPY ["CleanApiSample.Infrastructure/CleanApiSample.Infrastructure.csproj", "CleanApiSample.Infrastructure/"]
RUN dotnet restore "CleanApiSample.Api/CleanApiSample.Api.csproj"
COPY . .
WORKDIR "/src/CleanApiSample.Api"
RUN dotnet build "CleanApiSample.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CleanApiSample.Api.csproj" -c Release -r linux-x64 --self-contained true /p:PublishTrimmed=true /p:PublishReadyToRun=true /p:PublishSingleFile=true  -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
HEALTHCHECK CMD curl --fail http://localhost || exit 1  
ENTRYPOINT ["dotnet", "CleanApiSample.Api.dll"]