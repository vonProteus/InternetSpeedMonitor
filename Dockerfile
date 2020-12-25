FROM python:3-slim-buster

ENV TAGHOST=docker \
	INFLUXHOST=influx \
	INFLUXPORT=8086 \
	INFLUXUSER=root \
	INFLUXPASS=toor \
	INFLUXDATABASENAME=db
	

ARG BUILD_DATE
ARG VCS_REF
ARG VERSION
LABEL org.label-schema.build-date=$BUILD_DATE \
      org.label-schema.name="Internet Speed Monitor" \
      org.label-schema.vcs-ref=$VCS_REF \
      org.label-schema.vcs-url="https://github.com/vonProteus/InternetSpeedMonitor" \
      org.label-schema.version=$VERSION \
      org.label-schema.schema-version="1.0"

WORKDIR /app

COPY requirements.txt ./
RUN pip install --no-cache-dir -r requirements.txt && \
	apt-get update && \
	apt-get install -y gnupg1 apt-transport-https dirmngr && \
	apt-key adv --keyserver keyserver.ubuntu.com --recv-keys 379CE192D401AB61 && \
	echo "deb https://ookla.bintray.com/debian generic main" | tee /etc/apt/sources.list.d/speedtest.list && \
	apt-get update && \
	apt-get install -y speedtest && \
	speedtest --accept-license --accept-gdpr -f json-pretty

COPY . .

CMD [ "python", "./ism.py" ]
