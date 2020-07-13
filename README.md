Complete example of [GraphQL Federation](https://www.apollographql.com/docs/apollo-server/federation/introduction/) with implementing services written using [graphql-dotnet](https://github.com/graphql-dotnet/) and the [ASP.Net middleware package](https://github.com/graphql-dotnet/server)

implementing services:
  Users
  Products
  Baskets

Users and Products services don't know anything about the other services.  Baskets only knows about User IDs and Product IDs (it uses them as foreign keys to link those entities to the baskets)

clone this repo
docker-compose up

open graphql playground in a browser: http://localhost:8080

run this query:

```javascript
{
  user(id:"1"){
    name
    address{
        postCode
    }
    basket {
      products{
        sku
        name
        description
        price
      }      
    }
  }
}
```

You should get back:

```javascript
{
  "data": {
    "user": {
      "name": "Ada Lovelace",
      "address": {
        "postCode": "BL1 6DD"
      },
      "basket": {
        "products": [
          {
            "sku": "Keyboard-White",
            "name": "White Keyboard",
            "description": "A keyboard.  For typing on and that.  It's white",
            "price": 10.99
          },
          {
            "sku": "Mouse-White",
            "name": "White Mouse",
            "description": "A mouse.  For moving a cursor. And clicking.  It's white",
            "price": 5.99
          }
        ]
      }
    }
  }
```

marvel at the data coming from each service and being seamlessly joined together.
