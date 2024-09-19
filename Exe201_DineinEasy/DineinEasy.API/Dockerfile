# Base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081
ENV ASPNETCORE_ENVIRONMENT=Development

# Build image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy the project files
COPY ["Exe201_DineinEasy/DineinEasy.API/DineinEasy.API.csproj", "DineinEasy.API/"]
COPY ["Exe201_DineinEasy/DineinEasy.Service/DineinEasy.Service.csproj", "DineinEasy.Service/"]
COPY ["Exe201_DineinEasy/DineinEasy.Data/DineinEasy.Data.csproj", "DineinEasy.Data/"]

# Restore dependencies
RUN dotnet restore "./DineinEasy.API/DineinEasy.API.csproj"

# Copy the rest of the code
COPY ./Exe201_DineinEasy/ .

# Build the project
WORKDIR "/src/DineinEasy.API"
RUN dotnet build "DineinEasy.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish the project
FROM build AS publish
RUN dotnet publish "DineinEasy.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Set the entry point
ENTRYPOINT ["dotnet", "DineinEasy.API.dll"]
