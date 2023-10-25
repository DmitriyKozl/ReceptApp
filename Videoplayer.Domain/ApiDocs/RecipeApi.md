# RecipeApp API

- [RecipeApp API](#recipeapp-api)
    - [Create Recipe](#create-recipe)
        - [Create Recipe Request](#create-recipe-request)
        - [Create Recipe Response](#create-recipe-response)
    - [Get Recipe](#get-recipe)
        - [Get Recipe Request](#get-recipe-request)
        - [Get Recipe Response](#get-recipe-response)
    - [Update Recipe](#update-recipe)
        - [Update Recipe Request](#update-recipe-request)
        - [Update Recipe Response](#update-recipe-response)
    - [Delete Recipe](#delete-recipe)
        - [Delete Recipe Request](#delete-recipe-request)
        - [Delete Recipe Response](#delete-recipe-response)

## Create Recipe

### Create Recipe Request

```js
POST /recipes
```

```json
{
"name": "Vegan Sunshine",
"url": "http://recipe-link.com",
"ingredients": [
{
            "id": 1,
            "name": "Oatmeal",
            "brand": "HealthyOats",
            "from": "00:10:00",
            "till": "00:20:00"
            },
            {
            "id": 2,
            "name": "Avocado",
            "brand": "AvocadoBrand",
            "from": "00:15:00",
            "till": "00:25:00"
}
]
}
```


### Create Recipe Response

```js
201 Created
```

```yml
Location: {{host}}/Recipes/{{id}}
```

```json
{
"id": "00000000-0000-0000-0000-000000000000",
"name": "Vegan Sunshine",
"url": "http://recipe-link.com",
"lastModifiedDateTime": "2022-04-06T12:00:00",
"ingredients": [
{
            "id": 1,
            "name": "Oatmeal",
            "brand": "HealthyOats",
            "from": "00:10:00",
            "till": "00:20:00"
            },
            {
            "id": 2,
            "name": "Avocado",
            "brand": "AvocadoBrand",
            "from": "00:15:00",
            "till": "00:25:00"
}
]
}
```

## Get Recipe

### Get Recipe Request

```js
GET /recipes/{{id}}
```

### Get Recipe Response

```js
200 Ok
```

```json
{
"id": "00000000-0000-0000-0000-000000000000",
"name": "Vegan Sunshine",
"url": "http://recipe-link.com",
"lastModifiedDateTime": "2022-04-06T12:00:00",
"ingredients": [
{
            "id": 1,
            "name": "Oatmeal",
            "brand": "HealthyOats",
            "from": "00:10:00",
            "till": "00:20:00"
            },
            {
            "id": 2,
            "name": "Avocado",
            "brand": "AvocadoBrand",
            "from": "00:15:00",
            "till": "00:25:00"
            }
]
}
```

## Update Recipe

### Update Recipe Request

```js
PUT /recipes/{{id}}
```

```json
{
"name": "Vegan Sunshine Deluxe",
"url": "http://new-recipe-link.com",
"ingredients": [
  {
            "id": 1,
            "name": "Oatmeal",
            "brand": "HealthyOats",
            "from": "00:10:00",
            "till": "00:20:00"
            },
            {
            "id": 3,
            "name": "Blueberries",
            "brand": "BerryGood",
            "from": "00:22:00",
            "till": "00:30:00"
}
            ]
}
```

### Update Recipe Response

```js
204 No Content
```

or

```js
201 Created
```

```yml
Location: {{host}}/Recipes/{{id}}
```

## Delete Recipe

### Delete Recipe Request

```js
DELETE /recipes/{{id}}
```

### Delete Recipe Response

```js
204 No Content