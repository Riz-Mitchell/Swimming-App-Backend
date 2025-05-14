# Use the official .NET SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copy the .csproj file(s) and restore any dependencies (via nuget)
COPY *.csproj ./
RUN dotnet restore

# Copy the rest of the application code
COPY . ./
RUN dotnet publish -c Release -o /out

# Use the official .NET runtime image for the final stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=build /out .

# Expose the ports for your application (HTTP and HTTPS)
EXPOSE 5000

# Set the command to run your application with hot reload (via dotnet watch)
CMD ["dotnet", "Swimming_App_Backend.dll"]
