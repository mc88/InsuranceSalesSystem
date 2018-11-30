FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk  AS build
WORKDIR /src
COPY *.sln ./
COPY PaymentService.Web/PaymentService.Web.csproj PaymentService.Web/
COPY PaymentService.Api/PaymentService.Api.csproj PaymentService.Api/
COPY PaymentService.Bo/PaymentService.Bo.csproj PaymentService.Bo/
RUN dotnet restore
COPY . .
WORKDIR /src/PaymentService.Web
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "PaymentService.Web.dll"]
