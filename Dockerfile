FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

COPY MadrageBackEndChallenge/*.csproj ./MadrageBackEndChallenge/
COPY MadrageBackEndChallenge.Business/*.csproj ./MadrageBackEndChallenge.Business/
COPY MadrageBackEndChallenge.Domain/*.csproj ./MadrageBackEndChallenge.Domain/
COPY MadrageBackEndChallenge.Persistence/*.csproj ./MadrageBackEndChallenge.Persistence/

WORKDIR ./MadrageBackEndChallenge
RUN dotnet restore

WORKDIR /app

COPY ./MadrageBackEndChallenge/ ./MadrageBackEndChallenge/
COPY ./MadrageBackEndChallenge.Business/ ./MadrageBackEndChallenge.Business/
COPY ./MadrageBackEndChallenge.Domain/ ./MadrageBackEndChallenge.Domain/
COPY ./MadrageBackEndChallenge.Persistence/ ./MadrageBackEndChallenge.Persistence/
WORKDIR ./MadrageBackEndChallenge
RUN dotnet publish -c Release -o ../out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "MadrageBackEndChallenge.Web.dll"]