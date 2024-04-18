#!/bin/bash

dockerize -wait tcp://mysql:3306,tcp://kafka:9092 -timeout 30s

migrate -path /app/internal/database/migrations -database "mysql://root:root@tcp(mysql:3306)/wallet?charset=utf8&parseTime=True&loc=Local" up
