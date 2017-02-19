FROM microsoft/dotnet:1.0-sdk-projectjson
MAINTAINER carlospons

COPY    . /app
WORKDIR /app

RUN ["dotnet","restore"]

RUN ["dotnet", "build"]

EXPOSE 5000

ENTRYPOINT ["dotnet", "run"]
