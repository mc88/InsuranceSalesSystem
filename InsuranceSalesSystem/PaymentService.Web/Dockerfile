FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk  AS build
WORKDIR /src
COPY InsuranceSalesSystem/*.sln ./
COPY InsuranceSalesSystem/PaymentService.Web/PaymentService.Web.csproj PaymentService.Web/
COPY InsuranceSalesSystem/PaymentService.Api/PaymentService.Api.csproj PaymentService.Api/
COPY InsuranceSalesSystem/PaymentService.Bo/PaymentService.Bo.csproj PaymentService.Bo/

COPY InsuranceSalesSystem/. .
WORKDIR /src/PaymentService.Web
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "PaymentService.Web.dll"]
