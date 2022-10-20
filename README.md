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

The command above will download images. It could get a logn time and you will have to have about 5 GB disk space.

----

# Basket Service

**Description**:  A Basic project that get, add or remove products to user's basket. Products and their stocks are stored in elasticsearh. Elastic search database updates are expected from another microservice

## Dependencies

Docker-desktop

## Configuration

No configuration needed

## How to test the software

Integration tests will be written in the future. You could test it in two ways:

Inside BasketService/PostmanCollections directory you can import the file postman and start testing!

Set docker-compose project start Docker Compose in visual studio, it will open a swagger ui browser page, you can try it out with api version 1.

The user id is expected to be guid.
Available product id Guids are:

```
be667845-3f43-42bc-9b10-6e37a9650fc3
d20b5364-4270-4a6f-9cfe-546313140d51
```

## Getting help

Contact with me.

## Future Work

1. Writing tests
2. Containerizing testing framework
3. Redis cache usage
4. Make logging infasctucture better
