FROM mcr.microsoft.com/dotnet/sdk:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["./PBL6BackEnd.csproj", "src/"]
RUN dotnet restore "src/PBL6BackEnd.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "PBL6BackEnd.csproj" -c Release -o /app/build
FROM build AS publish
RUN dotnet publish "PBL6BackEnd.csproj" -c Release -o /app/publish
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ["dotnet", "PBL6BackEnd.dll"]