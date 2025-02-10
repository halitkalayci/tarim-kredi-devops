FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

COPY ["WebAPI/WebAPI.csproj", "WebAPI/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["Infrastructure/Infrastructure.csproj", "Infrastructure/"]
COPY ["Persistence/Persistence.csproj", "Persistence/"]
COPY ["Application/Application.csproj", "Application/"]

RUN dotnet restore "WebAPI/WebAPI.csproj"

# Dockerdaki cache mantýðýndan ötürü var olan dosyalar kopyalanmaya
# çalýþýlmayacak. Bu yüzden önce restore iþlemi yapýlýyor.
COPY . .

WORKDIR /src/WebAPI
RUN dotnet build "WebAPI.csproj" -c Release -o /app/build
RUN dotnet publish "WebAPI.csproj" -c Release -o /app/publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

COPY --from=build /app/publish .

ENTRYPOINT [ "dotnet", "WebAPI.dll" ]