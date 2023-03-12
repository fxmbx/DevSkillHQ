FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5059

ENV ASPNETCORE_URLS=http://+:5059

# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

## Build Stage

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app 
COPY ./DevSkillHQ-BE.csproj ./DevSkillHQ-BE.csproj
RUN dotnet restore "./DevSkillHQ-BE.csproj"

COPY . .
RUN dotnet build "DevSkillHQ-BE.csproj" -c Release -o /app/build

## Publish Stage
FROM build AS publish
RUN dotnet publish "./DevSkillHQ-BE.csproj" -c Release -o /app/publish /p:UseAppHost=true

## Final Stage

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DevSkillHQ-BE.dll"]
