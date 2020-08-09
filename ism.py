import os
import re
import subprocess
from influxdb import InfluxDBClient

response = subprocess.Popen('/usr/local/bin/speedtest-cli --simple', shell=True, stdout=subprocess.PIPE).stdout.read().decode('utf-8')

print(response)


ping = re.findall('Ping:\s(.*?)\s', response, re.MULTILINE)
download = re.findall('Download:\s(.*?)\s', response, re.MULTILINE)
upload = re.findall('Upload:\s(.*?)\s', response, re.MULTILINE)

ping = ping[0].replace(',', '.')
download = download[0].replace(',', '.')
upload = upload[0].replace(',', '.')


taghost = os.environ["TAGHOST"]

influxhost = os.environ["INFLUXHOST"]
influxport = os.environ["INFLUXPORT"]
influxuser = os.environ["INFLUXUSER"]
influxpass = os.environ["INFLUXPASS"]
influxdatabasename = os.environ["INFLUXDATABASENAME"]

speed_data = [
        {
            "measurement" : "internet_speed",
            "tags" : {
                "host": taghost
                },
            "fields" : {
                "download": float(download),
                "upload": float(upload),
                "ping": float(ping)
                }
            }
        ]

client = InfluxDBClient(influxhost, influxport, influxuser, influxpass, influxdatabasename)

client.write_points(speed_data)
