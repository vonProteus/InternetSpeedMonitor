FROM python:3-alpine

ENV TAGHOST=docker \
	INFLUXHOST=influx \
	INFLUXPORT=8086 \
	INFLUXUSER=root \
	INFLUXPASS=toor \
	INFLUXDATABASENAME=db

WORKDIR /app

COPY requirements.txt ./
RUN pip install --no-cache-dir -r requirements.txt

COPY . .

CMD [ "python", "./ism.py" ]
