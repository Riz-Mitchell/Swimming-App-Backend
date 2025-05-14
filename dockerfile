# Build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy csproj and restore
COPY Swimming_App_Backend.csproj ./
RUN dotnet restore

# Copy full source and publish
COPY . .
WORKDIR /src/Swimming_App_Backend
RUN dotnet publish -c Release -o /out

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=build /out .

EXPOSE 5075

CMD ["dotnet", "Swimming_App_Backend.dll"]
