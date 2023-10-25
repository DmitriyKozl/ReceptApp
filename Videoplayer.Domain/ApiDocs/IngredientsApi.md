# RecipeApp API - Ingredients

- [RecipeApp API - Ingredients](#recipeapp-api---ingredients)
    - [Create Ingredient](#create-ingredient)
        - [Create Ingredient Request](#create-ingredient-request)
        - [Create Ingredient Response](#create-ingredient-response)
    - [Get Ingredients](#get-ingredients)
        - [Get Ingredients Request](#get-ingredients-request)
        - [Get Ingredients Response](#get-ingredients-response)
    - [Update Ingredient](#update-ingredient)
        - [Update Ingredient Request](#update-ingredient-request)
        - [Update Ingredient Response](#update-ingredient-response)
    - [Delete Ingredient](#delete-ingredient)
        - [Delete Ingredient Request](#delete-ingredient-request)
        - [Delete Ingredient Response](#delete-ingredient-response)

## Create Ingredient

### Create Ingredient Request

```js
POST /ingredients
```

```json
{
"name": "Oatmeal",
"brand": "HealthyOats"
}
```

### Create Ingredient Response

```js
201 Created
```

```yml
Location: {{host}}/Ingredients/{{id}}
```

```json
{
"id": 1,
"name": "Oatmeal",
"brand": "HealthyOats"
}
```

## Get Ingredients

### Get Ingredients Request

```js
GET /ingredients
```

### Get Ingredients Response

```js
200 Ok
```

```json
[
{
"id": 1,
"name": "Oatmeal",
"brand": "HealthyOats"
},
{
"id": 2,
"name": "Avocado",
"brand": "AvocadoBrand"
}
]
```

## Update Ingredient

### Update Ingredient Request

```js
PUT /ingredients/{{id}}
```

```json
{
"name": "Organic Oatmeal",
"brand": "HealthyOats"
}
```

### Update Ingredient Response

```js
200 Ok
```

```json
{
"id": 1,
"name": "Organic Oatmeal",
"brand": "HealthyOats"
}
```
[RecipeApi.md](RecipeApi.md)
## Delete Ingredient

### Delete Ingredient Request

```js
DELETE /ingredients/{{id}}
```

### Delete Ingredient Response

```js
204 No Content
```
