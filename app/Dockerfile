# Use the .NET 6 SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Copy the solution file and project files
COPY app/*.sln ./
COPY app/CurrentTimeService/*.csproj ./CurrentTimeService/

# Restore the project dependencies
RUN dotnet restore "./CurrentTimeService/CurrentTimeService.csproj"

# Copy the rest of the application files
COPY app/. ./

# Build the application
WORKDIR /src
RUN dotnet build "CurrentTimeService/CurrentTimeService.csproj" -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "CurrentTimeService/CurrentTimeService.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Use the ASP.NET image to run the app
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# Copy the published app to the container
COPY --from=publish /app/publish .

# Set the entrypoint for the container
ENTRYPOINT ["dotnet", "CurrentTimeService.dll"]
