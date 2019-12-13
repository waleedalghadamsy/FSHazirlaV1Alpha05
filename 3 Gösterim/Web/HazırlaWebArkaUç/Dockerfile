FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["3 Gösterim/Web/HazırlaWeb/HazırlaWebArkaUç.csproj", "3 Gösterim/Web/HazırlaWeb/"]
COPY ["1 Çekirdek/HazırlaÇekirdek/HazırlaÇekirdek.csproj", "1 Çekirdek/HazırlaÇekirdek/"]
RUN dotnet restore "3 Gösterim/Web/HazırlaWeb/HazırlaWebArkaUç.csproj"
COPY . .
WORKDIR "/src/3 Gösterim/Web/HazırlaWeb"
RUN dotnet build "HazırlaWebArkaUç.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HazırlaWebArkaUç.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HazırlaWebArkaUç.dll"]
