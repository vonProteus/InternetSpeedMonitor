FROM python:3-alpine

ENV CSVOUTPUTFILE=/tmp/speadfile.csv

WORKDIR /app

COPY requirements.txt ./
RUN pip install --no-cache-dir -r requirements.txt

COPY . .

CMD [ "python", "./ism.py" ]
