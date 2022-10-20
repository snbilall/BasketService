# BasketService
## Installation

First clone repository
```
git clone https://github.com/snbilall/BasketService.git
```

To install all of the template files use visual studio, docker desktop app. Inside the vs just run docker-compose. Or with installed docker-compose just run command below:

```
docker-compose up -d
```

The command above will download images. It could get a logn time and you will have to have about 2 GB disk space.

----

# Key Value Go Service

**Description**:  A Basic key value project. Gets key value values from client, saves data on memory. It saves memory data to a file in periodic interval. Gin library used to build web service.

## Dependencies

Docker-desktop

## Configuration

No configuration needed

## How to test the software

Integration tests will be written in the future. You could test it in two ways:

Inside postman collections directory you can import the file postman and start testing!

When you start Docker Compose in visual studio, it will open a swagger ui browser page, you can try it out with api version 1.

## Getting help

Contact with me.

## Future Work

1. Writing tests
2. Containerizing testing framework
3. Redis cache usage
4. Make logging infasctucture better
