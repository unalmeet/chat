#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["unalmeet_chat_ms/unalmeet_chat_ms.csproj", "unalmeet_chat_ms/"]
RUN dotnet restore "unalmeet_chat_ms/unalmeet_chat_ms.csproj"
COPY . .
WORKDIR "/src/unalmeet_chat_ms"
RUN dotnet build "unalmeet_chat_ms.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "unalmeet_chat_ms.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "unalmeet_chat_ms.dll"]