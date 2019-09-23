FROM microsoft/dotnet:2.2-aspnetcore-runtime as base
WORKDIR /app
expose 80

ENV kevyn=abacaxi

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["CapitalChurch.Campus.Domain/CapitalChurch.Campus.Domain.csproj", "CapitalChurch.Campus.Domain/"]
COPY ["CapitalChurch.Campus.WebApi/CapitalChurch.Campus.WebApi.csproj", "CapitalChurch.Campus.WebApi/"]
RUN dotnet restore "./CapitalChurch.Campus.WebApi/CapitalChurch.Campus.WebApi.csproj"
COPY . .
WORKDIR /src
RUN dotnet build "./CapitalChurch.Campus.WebApi/CapitalChurch.Campus.WebApi.csproj" -c Debug -o /app

FROM build AS publish
RUN dotnet publish "./CapitalChurch.Campus.WebApi/CapitalChurch.Campus.WebApi.csproj" -c Debug -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "./CapitalChurch.Campus.WebApi.dll"]
