FROM microsoft/dotnet:1.0-sdk-projectjson
MAINTAINER carlospons

COPY    . /app
WORKDIR /app

RUN ["dotnet","restore"]

EXPOSE 5000

ENTRYPOINT ["dotnet","run"]
