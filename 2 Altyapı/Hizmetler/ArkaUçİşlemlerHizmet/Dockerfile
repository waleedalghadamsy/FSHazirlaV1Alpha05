FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["2 Altyapı/Hizmetler/ArkaUçİşlemlerHizmet/ArkaUçİşlemlerHizmet.csproj", "2 Altyapı/Hizmetler/ArkaUçİşlemlerHizmet/"]
COPY ["2 Altyapı/Veri/BisiparişVeriAltYapı/BisiparişVeriAltYapı.csproj", "2 Altyapı/Veri/BisiparişVeriAltYapı/"]
COPY ["1 Çekirdek/BisiparişÇekirdek/BisiparişÇekirdek.csproj", "1 Çekirdek/BisiparişÇekirdek/"]
RUN dotnet restore "2 Altyapı/Hizmetler/ArkaUçİşlemlerHizmet/ArkaUçİşlemlerHizmet.csproj"
COPY . .
WORKDIR "/src/2 Altyapı/Hizmetler/ArkaUçİşlemlerHizmet"
RUN dotnet build "ArkaUçİşlemlerHizmet.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ArkaUçİşlemlerHizmet.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ArkaUçİşlemlerHizmet.dll"]