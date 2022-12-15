FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine

WORKDIR /app

COPY publish/Cars/ .

EXPOSE 8070
ENTRYPOINT ["dotnet", "Cars.dll"]