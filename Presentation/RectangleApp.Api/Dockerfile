#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Presentation/RectangleApp.Api/RectangleApp.Api.csproj", "Presentation/RectangleApp.Api/"]
COPY ["Infrastructure/Project.Service/Project.Service.csproj", "Infrastructure/Project.Service/"]
COPY ["Infrastructure/Project.Infrastructure/Project.Infrastructure.csproj", "Infrastructure/Project.Infrastructure/"]
COPY ["Core/Project.Core/Project.Core.csproj", "Core/Project.Core/"]
RUN dotnet restore "Presentation/RectangleApp.Api/RectangleApp.Api.csproj"
COPY . .
WORKDIR "/src/Presentation/RectangleApp.Api"
RUN dotnet build "RectangleApp.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RectangleApp.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RectangleApp.Api.dll"]