FROM python:3-alpine

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
RUN pip install --no-cache-dir -r requirements.txt

COPY . .

CMD [ "python", "./ism.py" ]
