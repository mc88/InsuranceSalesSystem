FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk  AS build
WORKDIR /src
COPY InsuranceSalesSystem/*.sln ./
COPY PolicyService.Web/PolicyService.Web.csproj PolicyService.Web/
COPY PolicyService.Api/PolicyService.Api.csproj PolicyService.Api/
COPY PolicyService.Bo/PolicyService.Bo.csproj PolicyService.Bo/
RUN dotnet restore PolicyService.Web/PolicyService.Web.csproj
RUN dotnet restore PolicyService.Api/PolicyService.Api.csproj
RUN dotnet restore PolicyService.Bo/PolicyService.Bo.csproj
COPY . .
WORKDIR /src/PolicyService.Web
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "PolicyService.Web.dll"]
