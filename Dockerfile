# Base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

#ENV
ARG DB_USER
ARG DB_PASSWORD
ARG DB_SERVER
ARG DB_NAME
ARG JWT_KEY
ARG AUDIENCE
ARG ISSUER
ARG SUPABASE_URL
ARG SUPABASE_KEY

ENV DB_USER=$DB_USER
ENV DB_PASSWORD=$DB_PASSWORD
ENV DB_SERVER=$DB_SERVER
ENV DB_NAME=$DB_NAME
ENV JWT_KEY=$JWT_KEY
ENV AUDIENCE=$AUDIENCE
ENV ISSUER=$ISSUER
ENV SUPABASE_URL=$SUPABASE_URL
ENV SUPABASE_KEY=$SUPABASE_KEY

ENV ASPNETCORE_ENVIRONMENT=Development

# Build image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy the project files from the Exe201_DineinEasy folder
COPY ["Exe201_DineinEasy/DineinEasy.API/DineinEasy.API.csproj", "DineinEasy.API/"]
COPY ["Exe201_DineinEasy/DineinEasy.Service/DineinEasy.Service.csproj", "DineinEasy.Service/"]
COPY ["Exe201_DineinEasy/DineinEasy.Data/DineinEasy.Data.csproj", "DineinEasy.Data/"]

# Restore dependencies
RUN dotnet restore "./DineinEasy.API/DineinEasy.API.csproj"

# Copy the entire solution folder
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
