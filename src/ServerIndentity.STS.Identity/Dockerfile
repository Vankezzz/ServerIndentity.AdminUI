FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/ServerIndentity.STS.Identity/ServerIndentity.STS.Identity.csproj", "src/ServerIndentity.STS.Identity/"]
COPY ["src/ServerIndentity.Admin.EntityFramework.Shared/ServerIndentity.Admin.EntityFramework.Shared.csproj", "src/ServerIndentity.Admin.EntityFramework.Shared/"]
COPY ["src/ServerIndentity.Shared/ServerIndentity.Shared.csproj", "src/ServerIndentity.Shared/"]
RUN dotnet restore "src/ServerIndentity.STS.Identity/ServerIndentity.STS.Identity.csproj"
COPY . .
WORKDIR "/src/src/ServerIndentity.STS.Identity"
RUN dotnet build "ServerIndentity.STS.Identity.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ServerIndentity.STS.Identity.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
ENTRYPOINT ["dotnet", "ServerIndentity.STS.Identity.dll"]