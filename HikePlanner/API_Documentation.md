# API Documentation

- User
/api/Users
* map -> Address
* GET route:
/api/Users/5f6e429d-2a77-48b6-a1b7-67822955476a

userId = 5f6e429d-2a77-48b6-a1b7-67822955476a
userId = 32cbd3cd-5bdb-431e-bbf2-bc2608998817

- Checklist
* GET route:
/api/Checklist 
/api/Checklist/1

- ChecklistItem
* GET route:
/api/Checklist/1/item/1


- Equipment 
* GET route:
/api/Equipments
/api/Equipments/1


- Activity
* GET route:
/api/Activity
/api/Activity/1
/api/Activity/User/5f6e429d-2a77-48b6-a1b7-67822955476a

``` json
  {
    "id": 0,
    "name": "Hiking",
    "notes": "It will be fun",
    "trailId": "TBD",
    "trailHead": "Paradise",
    "creator": "5f6e429d-2a77-48b6-a1b7-67822955476a",
    "trips": null
  }
  Return: Id = 6
```

- Trip
* map -> Checklist
* GET route:
/api/Trips
/api/Trips/1
/api/Trips/Activity/1
``` json
{
    "id": 0,
    "startDate": "2021-06-09T14:58:24.629",
    "endDate": "2021-06-09T14:58:24.629",
    "startTime": "2021-06-09T14:58:24.629",
    "distance": 2,
    "creator": "5f6e429d-2a77-48b6-a1b7-67822955476a",
    "activityId": 1,
    "checkListId": 1,
}
Return Id = 6
```

- Participant
* dependency : Trip
* GET route:
/api/Trips/1/Participants

``` json
{
  "id": 0,
  "tripId": 6,
  "userId": "5f6e429d-2a77-48b6-a1b7-67822955476a"
}
return id = 1
{
  "id": 0,
  "tripId": 6,
  "userId": "32cbd3cd-5bdb-431e-bbf2-bc2608998817"
}
circle back
```

- Post
* dependency : Trip
* GET route:
/api/Trips/6/Posts

``` json
    {
    "id": 0,
    "tripId": 6,
    "userId": "5f6e429d-2a77-48b6-a1b7-67822955476a",
    "notes": "Welcome everyone!",
    "imageURL": "https://www.google.com/url?sa=i&url=https%3A%2F%2Fmtrainierguestservices.com%2Faccommodations%2Fspecial-offers%2F&psig=AOvVaw1ioNny1kQWdgwC5LkuJTVY&ust=1623338528971000&source=images&cd=vfe&ved=0CAIQjRxqFwoTCNjtjbbtivECFQAAAAAdAAAAABAD",
    "dateCreated": "2021-06-09T16:10:51.11"
    }
    return id = 1

    {
    "id": 0,
    "tripId": 6,
    "userId": "5f6e429d-2a77-48b6-a1b7-67822955476a",
    "notes": "can't wait!",
    "imageURL": "string",
    "dateCreated": "2021-06-09T16:12:43.301Z"
    }
    return id = 3
```