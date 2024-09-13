# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source
COPY . .
RUN dotnet restore "./EmployeeService.csproj" --disable-parallel
RUN dotnet publish "./EmployeeService.csproj" -c release -o /app --no-restore

# Serve stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app ./

EXPOSE 5000

HEALTHCHECK --interval=30s --timeout=10s --start-period=5s CMD curl --fail http://localhost:5000 || exit 1

ENTRYPOINT ["dotnet", "EmployeeService.dll"]