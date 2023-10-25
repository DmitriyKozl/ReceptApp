# RecipeApp API - Timestamps

- [RecipeApp API - Timestamps](#recipeapp-api---timestamps)
    - [Create Timestamp](#create-timestamp)
        - [Create Timestamp Request](#create-timestamp-request)
        - [Create Timestamp Response](#create-timestamp-response)
    - [Get Timestamps](#get-timestamps)
        - [Get Timestamps Request](#get-timestamps-request)
        - [Get Timestamps Response](#get-timestamps-response)
    - [Update Timestamp](#update-timestamp)
        - [Update Timestamp Request](#update-timestamp-request)
        - [Update Timestamp Response](#update-timestamp-response)
    - [Delete Timestamp](#delete-timestamp)
        - [Delete Timestamp Request](#delete-timestamp-request)
        - [Delete Timestamp Response](#delete-timestamp-response)

## Create Timestamp

### Create Timestamp Request

```js
POST /timestamps
```

```json
{
"ingredientId": 1,
"from": "00:10:00",
"till": "00:20:00"
}
```

### Create Timestamp Response

```js
201 Created
```

```yml
Location: {{host}}/Timestamps/{{id}}
```

```json
{
"id": 1,
"ingredientId": 1,
"from": "00:10:00",
"till": "00:20:00"
}
```

## Get Timestamps

### Get Timestamps Request

```js
GET /timestamps
```

### Get Timestamps Response

```js
200 Ok
```

```json
[
{
"id": 1,
"ingredientId": 1,
"from": "00:10:00",
"till": "00:20:00"
},
{
"id": 2,
"ingredientId": 2,
"from": "00:15:00",
"till": "00:25:00"
}
]
```

## Update Timestamp

### Update Timestamp Request

```js
PUT /timestamps/{{id}}
```

```json
{
"from": "00:12:00",
"till": "00:22:00"
}
```

### Update Timestamp Response

```js
200 Ok
```

```json
{
"id": 1,
"ingredientId": 1,
"from": "00:12:00",
"till": "00:22:00"
}
```

## Delete Timestamp

### Delete Timestamp Request

```js
DELETE /timestamps/{{id}}
```

### Delete Timestamp Response

```js
204 No Content
```
