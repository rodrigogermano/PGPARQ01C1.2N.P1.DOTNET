#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/SkateStore.Products.Application.gRPC/SkateStore.Products.Application.gRPC.csproj", "src/SkateStore.Products.Application.gRPC/"]
RUN dotnet restore "src/SkateStore.Products.Application.gRPC/SkateStore.Products.Application.gRPC.csproj"
COPY . .
WORKDIR "/src/src/SkateStore.Products.Application.gRPC"
RUN dotnet build "SkateStore.Products.Application.gRPC.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SkateStore.Products.Application.gRPC.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SkateStore.Products.Application.gRPC.dll"]