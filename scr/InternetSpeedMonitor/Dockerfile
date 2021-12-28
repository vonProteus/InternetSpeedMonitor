FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base

RUN apt-get update && apt-get install -y curl && \
	curl -s https://install.speedtest.net/app/cli/install.deb.sh | bash && \
	apt-get update && apt-get install -y speedtest 
    
ARG BUILD_DATE
ARG VCS_REF
ARG VERSION
LABEL org.label-schema.build-date=$BUILD_DATE \
      org.label-schema.name="Internet Speed Monitor" \
      org.label-schema.vcs-ref=$VCS_REF \
      org.label-schema.vcs-url="https://github.com/vonProteus/InternetSpeedMonitor" \
      org.label-schema.version=$VERSION \
      org.label-schema.schema-version="1.0"

ENV DB_HOST=db:5432 \
	DB_USER=ism \
	DB_PASSWORD=ism \
	DB_NAME=ism
      
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["InternetSpeedMonitor/InternetSpeedMonitor.csproj", "InternetSpeedMonitor/"]
RUN dotnet restore "InternetSpeedMonitor/InternetSpeedMonitor.csproj"
COPY . .
WORKDIR "/src/InternetSpeedMonitor"
RUN apt-get update && apt-get install -y tree && tree -alh
RUN dotnet build "InternetSpeedMonitor.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "InternetSpeedMonitor.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InternetSpeedMonitor.dll"]
