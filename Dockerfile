# Sýfýr bir linux makinem var, bu projeyi nasýl kurarým?
# Önce kötü bir Dockerfile yazalým, sonra iyileþtirelim.
# .NET SDK
# Multi-Stage

FROM mcr.microsoft.com/dotnet/sdk:8.0

# APP KLASÖRÜNÜ ÇALIÞMA DÝZÝNÝM YAP
WORKDIR /app

# TÜM PROJEYÝ APP'E KOPYALA
COPY . .

# PROJENÝN BAÐIMLILIKLARINI YÜKLE
RUN dotnet restore "WebAPI/WebAPI.csproj"

# PROJEYÝ DERLE
RUN dotnet build "WebAPI/WebAPI.csproj" -c Release -o /app/build

# PROJEYÝ PUBLÝSH ET
RUN dotnet publish "WebAPI/WebAPI.csproj" -c Release -o /app/publish

WORKDIR /app/publish

# RUN => Image oluþturulma esnasýnda çalýþtýrýlacak komut
# ENTRYPOINT => Image çalýþtýrýldýðýnda çalýþtýrýlacak komut
ENTRYPOINT [ "dotnet", "WebAPI.dll" ]