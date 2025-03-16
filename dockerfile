# Use the official .NET SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

# Set the working directory inside the container
WORKDIR /app

# Copy the .csproj file(s) and restore any dependencies (via nuget)
COPY *.csproj ./
RUN dotnet restore

# Copy the rest of the application code
COPY . ./

# Publish the app to the /out directory (for a smaller, final image)
RUN dotnet publish -c Release -o /out

# Use the official .NET runtime image for the final stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final

# Set the working directory inside the container
WORKDIR /app

# Copy the published app from the build stage
COPY --from=build /out .

# Expose the ports for your application (HTTP and HTTPS)
EXPOSE 5000
EXPOSE 5001

# Set the environment variable for running in Development mode
ENV ASPNETCORE_ENVIRONMENT=Development

# Set the command to run your application with hot reload (via dotnet watch)
CMD ["dotnet", "watch", "run"]
