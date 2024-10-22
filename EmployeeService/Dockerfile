# Use the .NET SDK image for both building and running the application
FROM mcr.microsoft.com/dotnet/sdk:8.0

# Set the working directory
WORKDIR /source

# Copy the source code into the container
COPY . .

# Restore dependencies
RUN dotnet restore "./EmployeeService.csproj" --disable-parallel

# Publish the application
RUN dotnet publish "./EmployeeService.csproj" -c release -o /app --no-restore

# Set the working directory for the runtime
WORKDIR /app

# Expose the application port
EXPOSE 5000

# Define a health check
HEALTHCHECK --interval=30s --timeout=10s --start-period=5s CMD curl --fail http://localhost:5000 || exit 1

# Define the entry point
ENTRYPOINT ["dotnet", "EmployeeService.dll"]
