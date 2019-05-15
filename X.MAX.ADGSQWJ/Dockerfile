FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY X.MAX.ADGSQWJ/X.MAX.ADGSQWJ.csproj X.MAX.ADGSQWJ/
RUN dotnet restore X.MAX.ADGSQWJ/X.MAX.ADGSQWJ.csproj
COPY . .
WORKDIR /src/X.MAX.ADGSQWJ
RUN dotnet build X.MAX.ADGSQWJ.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish X.MAX.ADGSQWJ.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "X.MAX.ADGSQWJ.dll"]
