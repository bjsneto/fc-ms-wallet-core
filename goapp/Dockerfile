FROM golang:1.20
 
ENV DOCKERIZE_VERSION v0.6.1
RUN apt-get update && apt-get install -y wget \
    && wget https://github.com/jwilder/dockerize/releases/download/$DOCKERIZE_VERSION/dockerize-linux-amd64-$DOCKERIZE_VERSION.tar.gz \
    && tar -C /usr/local/bin -xzvf dockerize-linux-amd64-$DOCKERIZE_VERSION.tar.gz \
    && rm dockerize-linux-amd64-$DOCKERIZE_VERSION.tar.gz
 
RUN apt-get update && apt-get install -y --no-install-recommends \
    curl \
    ca-certificates \
    gnupg \
    && curl -L https://packagecloud.io/golang-migrate/migrate/gpgkey | apt-key add - \
    && echo "deb https://packagecloud.io/golang-migrate/migrate/ubuntu/ bionic main" > /etc/apt/sources.list.d/migrate.list \
    && apt-get update \
    && apt-get install -y migrate \
    && rm -rf /var/lib/apt/lists/*
 
WORKDIR /app/
 
COPY init.sh /usr/local/bin/
RUN chmod +x /usr/local/bin/init.sh
 
RUN apt-get update && apt-get install -y librdkafka-dev
 
COPY . .
 
RUN go build -o /usr/local/bin/main ./cmd/walletcore/main.go
 
CMD ["bash", "-c", "/usr/local/bin/init.sh && /usr/local/bin/main && tail -f /dev/null"]