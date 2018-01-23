FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
ENV ASPNETCORE_URLS http://*:8285
EXPOSE 8285

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY *.sln ./
COPY src/Eventos.IO.Services.Api/Eventos.IO.Services.Api.csproj src/Eventos.IO.Services.Api/
COPY src/Eventos.IO.Infra.CrossCutting.AspNetFilters/Eventos.IO.Infra.CrossCutting.AspNetFilters.csproj src/Eventos.IO.Infra.CrossCutting.AspNetFilters/
COPY src/Eventos.IO.Domain.Core/Eventos.IO.Domain.Core.csproj src/Eventos.IO.Domain.Core/
COPY src/Eventos.IO.Infra.CrossCutting.Identity/Eventos.IO.Infra.CrossCutting.Identity.csproj src/Eventos.IO.Infra.CrossCutting.Identity/
COPY src/Eventos.IO.Domain/Eventos.IO.Domain.csproj src/Eventos.IO.Domain/
COPY src/Eventos.IO.Infra.CrossCutting.IoC/Eventos.IO.Infra.CrossCutting.IoC.csproj src/Eventos.IO.Infra.CrossCutting.IoC/
COPY src/Eventos.IO.Infra.Data/Eventos.IO.Infra.Data.csproj src/Eventos.IO.Infra.Data/
RUN dotnet restore
COPY . .
WORKDIR /src/src/Eventos.IO.Services.Api
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Eventos.IO.Services.Api.dll"]
