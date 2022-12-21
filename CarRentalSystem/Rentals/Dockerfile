# FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
# WORKDIR /app
# EXPOSE 8060
# #EXPOSE 443

# FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
# WORKDIR /src
# COPY ["Rentals/Rentals.csproj", "Rentals/"]
# RUN dotnet restore "Rentals/Rentals.csproj"
# COPY . .
# WORKDIR "/src/Rentals"
# RUN dotnet build "Rentals.csproj" -c Release -o /app/build

# FROM build AS publish
# RUN dotnet publish "Rentals.csproj" -c Release -o /app/publish

# FROM base AS final
# WORKDIR /app
# COPY --from=publish /app/publish .
# ENTRYPOINT ["dotnet", "Rentals.dll"]

FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine

WORKDIR /app

COPY publish/Rentals/ .

EXPOSE 8060
ENTRYPOINT ["dotnet", "Rentals.dll"]
