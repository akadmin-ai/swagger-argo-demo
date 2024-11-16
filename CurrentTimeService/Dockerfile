# Use the .NET SDK image for building the application
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Set the working directory for the build process
WORKDIR /src

# Copy the solution file
COPY ./CurrentTimeService/CurrentTimeService.csproj ./CurrentTimeService/

# Restore dependencies
RUN dotnet restore ./CurrentTimeService/CurrentTimeService.csproj

# Copy the entire CurrentTimeService directory
COPY ./CurrentTimeService/ ./CurrentTimeService/

# Build the application
WORKDIR /src/CurrentTimeService
RUN dotnet publish -c Release -o /app

# Use the ASP.NET runtime image for the final stage
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime

# Set the working directory
WORKDIR /app

# Copy the published output from the build stage
COPY --from=build /app ./

# Expose port 80
EXPOSE 80

# Set the entry point for the container
ENTRYPOINT ["dotnet", "CurrentTimeService.dll"]
