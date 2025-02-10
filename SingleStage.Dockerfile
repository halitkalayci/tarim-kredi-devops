# S�f�r bir linux makinem var, bu projeyi nas�l kurar�m?
# �nce k�t� bir Dockerfile yazal�m, sonra iyile�tirelim.
# .NET SDK
# Multi-Stage
# Single-Stage

#Stage-1 -> Publish klas�r�n�  -> Stage 2 ->
FROM mcr.microsoft.com/dotnet/sdk:8.0

# APP KLAS�R�N� �ALI�MA D�Z�N�M YAP
WORKDIR /app

# T�M PROJEY� APP'E KOPYALA
COPY . .

# PROJEN�N BA�IMLILIKLARINI Y�KLE
RUN dotnet restore "WebAPI/WebAPI.csproj"

# PROJEY� DERLE
RUN dotnet build "WebAPI/WebAPI.csproj" -c Release -o /app/build

# PROJEY� PUBL�SH ET
RUN dotnet publish "WebAPI/WebAPI.csproj" -c Release -o /app/publish

WORKDIR /app/publish

# ENTRYPOINT => Image �al��t�r�ld���nda �al��t�r�lacak komut
ENTRYPOINT [ "dotnet", "WebAPI.dll" ]


