import os
import re
import subprocess
from influxdb import InfluxDBClient
import json

response = subprocess.Popen('/usr/local/bin/speedtest-cli --json --secure', shell=True, stdout=subprocess.PIPE).stdout.read().decode('utf-8')
data = json.loads(response)

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
                "download" : data['download'],
                "upload" : data['upload'],
                "ping" : data['ping']
                }
            }
        ]
        
print(speed_data)

client = InfluxDBClient(influxhost, influxport, influxuser, influxpass, influxdatabasename)

client.write_points(speed_data)
