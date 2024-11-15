# Use official .NET SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Set the working directory
WORKDIR /app

# Copy the solution and restore dependencies
COPY *.sln ./
COPY CurrentTimeService/*.csproj ./CurrentTimeService/
RUN dotnet restore

# Copy the rest of the application files
COPY . ./

# Build and publish the solution
RUN dotnet publish CurrentTimeService/CurrentTimeService.csproj -c Release -o /app/publish

# Use official .NET runtime image for the final image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime

# Set the working directory
WORKDIR /app

# Copy the published app from the build stage
COPY --from=build /app/publish .

# Set the entry point
ENTRYPOINT ["dotnet", "CurrentTimeService.dll"]

