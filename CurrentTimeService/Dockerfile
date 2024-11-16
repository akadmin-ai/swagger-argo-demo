# Use the .NET SDK image for building the application
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Set the working directory
WORKDIR /src

# Copy solution and project files
COPY CurrentTimeService.sln ./
COPY CurrentTimeService/*.csproj ./CurrentTimeService/

# Restore dependencies
RUN dotnet restore ./CurrentTimeService/CurrentTimeService.csproj

# Copy the rest of the application files
COPY ./CurrentTimeService/ ./CurrentTimeService/

# Build the application
WORKDIR /src/CurrentTimeService
RUN dotnet publish -c Release -o /app

# Use the runtime image for running the application
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime

# Set the working directory
WORKDIR /app

# Copy the built files from the build stage
COPY --from=build /app ./

# Expose port 80
EXPOSE 80

# Set the entry point
ENTRYPOINT ["dotnet", "CurrentTimeService.dll"]
