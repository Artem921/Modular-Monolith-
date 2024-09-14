#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Api/Api.csproj", "src/Api/"]
COPY ["src/Framework/Utils/Utils.csproj", "src/Framework/Utils/"]
COPY ["src/Module.EmailNotification/Notification.Application/Notification.Application.csproj", "src/Module.EmailNotification/Notification.Application/"]
COPY ["src/Module.Orders/Orders.Contract/Orders.Contract.csproj", "src/Module.Orders/Orders.Contract/"]
COPY ["src/Module.Orders/Orders.Application/Orders.Application.csproj", "src/Module.Orders/Orders.Application/"]
COPY ["src/Module.Orders/Orders.Domain/Orders.Domain.csproj", "src/Module.Orders/Orders.Domain/"]
COPY ["src/Module.EmailNotification/Notification.Domain/Notification.Domain.csproj", "src/Module.EmailNotification/Notification.Domain/"]
COPY ["src/Module.EmailNotification/Notification.Contract/Notification.Contract.csproj", "src/Module.EmailNotification/Notification.Contract/"]
COPY ["src/Module.EmailNotification/Notification.Controllers/Notification.Controllers.csproj", "src/Module.EmailNotification/Notification.Controllers/"]
COPY ["src/Module.EmailNotification/Notification.Infrastructure/Notification.Infrastructure.csproj", "src/Module.EmailNotification/Notification.Infrastructure/"]
COPY ["src/Module.Identity/Identity.Controllers/Identity.Controllers.csproj", "src/Module.Identity/Identity.Controllers/"]
COPY ["src/Module.Identity/Identity.Domain/Identity.Domain.csproj", "src/Module.Identity/Identity.Domain/"]
COPY ["src/Module.Identity/Identity.Infrastructure/Identity.Infrastructure.csproj", "src/Module.Identity/Identity.Infrastructure/"]
COPY ["src/Module.Orders/Orders.Controllers/Orders.Controllers.csproj", "src/Module.Orders/Orders.Controllers/"]
COPY ["src/Module.Orders/Orders.Infrastructure/Orders.Infrastructure.csproj", "src/Module.Orders/Orders.Infrastructure/"]
COPY ["src/Module.Products/Product.Application/Product.Application.csproj", "src/Module.Products/Product.Application/"]
COPY ["src/Module.Products/Product.Domain/Product.Domain.csproj", "src/Module.Products/Product.Domain/"]
COPY ["src/Module.Products/Product.Contract/Product.Contract.csproj", "src/Module.Products/Product.Contract/"]
COPY ["src/Module.Products/Product.Controllers/Product.Controllers.csproj", "src/Module.Products/Product.Controllers/"]
COPY ["src/Module.Products/Product.Infrastructure/Product.Infrastructure.csproj", "src/Module.Products/Product.Infrastructure/"]  
RUN dotnet restore "./src/Api/./Api.csproj"
COPY . .
WORKDIR "/src/src/Api"
RUN dotnet build "./Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Api.dll"]