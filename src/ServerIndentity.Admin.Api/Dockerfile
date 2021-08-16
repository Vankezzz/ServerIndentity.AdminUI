FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/ServerIndentity.Admin.Api/ServerIndentity.Admin.Api.csproj", "src/ServerIndentity.Admin.Api/"]
COPY ["src/ServerIndentity.Admin.EntityFramework.Shared/ServerIndentity.Admin.EntityFramework.Shared.csproj", "src/ServerIndentity.Admin.EntityFramework.Shared/"]
COPY ["src/ServerIndentity.Admin.EntityFramework.SqlServer/ServerIndentity.Admin.EntityFramework.SqlServer.csproj", "src/ServerIndentity.Admin.EntityFramework.SqlServer/"]
COPY ["src/ServerIndentity.Admin.EntityFramework.PostgreSQL/ServerIndentity.Admin.EntityFramework.PostgreSQL.csproj", "src/ServerIndentity.Admin.EntityFramework.PostgreSQL/"]
COPY ["src/ServerIndentity.Shared/ServerIndentity.Shared.csproj", "src/ServerIndentity.Shared/"]
COPY ["src/ServerIndentity.Admin.EntityFramework.MySql/ServerIndentity.Admin.EntityFramework.MySql.csproj", "src/ServerIndentity.Admin.EntityFramework.MySql/"]
RUN dotnet restore "src/ServerIndentity.Admin.Api/ServerIndentity.Admin.Api.csproj"
COPY . .
WORKDIR "/src/src/ServerIndentity.Admin.Api"
RUN dotnet build "ServerIndentity.Admin.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ServerIndentity.Admin.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true
ENTRYPOINT ["dotnet", "ServerIndentity.Admin.Api.dll"]