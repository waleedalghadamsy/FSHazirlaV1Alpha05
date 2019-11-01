FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["3 Gösterim/Web/BisiparişWeb/BisiparişWeb.csproj", "3 Gösterim/Web/BisiparişWeb/"]
COPY ["1 Çekirdek/BisiparişÇekirdek/BisiparişÇekirdek.csproj", "1 Çekirdek/BisiparişÇekirdek/"]
RUN dotnet restore "3 Gösterim/Web/BisiparişWeb/BisiparişWeb.csproj"
COPY . .
WORKDIR "/src/3 Gösterim/Web/BisiparişWeb"
RUN dotnet build "BisiparişWeb.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BisiparişWeb.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BisiparişWeb.dll"]