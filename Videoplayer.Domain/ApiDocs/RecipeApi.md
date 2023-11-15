# RecipeApp API


- [RecipeApp API](#recipeapp-api)
    - [Create Recipe](#create-recipe)
        - [Create Recipe Request](#create-recipe-request)
        - [Create Recipe Response](#create-recipe-response)
    - [Get Recipe](#get-recipe)
        - [Get Recipe Request](#get-recipe-request)
        - [Get Recipe Response](#get-recipe-response)
        - [Get RecipeIngredient Request](#get-recipeingredient-request)
        - [Get RecipeIngredient Response](#get-recipeingredient-response)
        - [Get RecipeUtensil Request](#get-recipeutensil-request)
        - [Get RecipeUtensil Response](#get-recipeutensil-response)
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
"img": "https://images.unsplash.com/photo-1571748982800-fa51082c2224?auto=format&fit=crop&q=80&w=2071&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
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
"img": "https://images.unsplash.com/photo-1571748982800-fa51082c2224?auto=format&fit=crop&q=80&w=2071&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
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
"img": "https://images.unsplash.com/photo-1571748982800-fa51082c2224?auto=format&fit=crop&q=80&w=2071&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
"url": "http://recipe-link.com",
"lastModifiedDateTime": "2022-04-06T12:00:00",
"ingredients": [
{
            "id": 1,
            "name": "Oatmeal",
            "img": "https://images.unsplash.com/photo-1571748982800-fa51082c2224?auto=format&fit=crop&q=80&w=2071&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
            "brand": "HealthyOats",
            "brandImg": "https://images.unsplash.com/photo-1571748982800-fa51082c2224?auto=format&fit=crop&q=80&w=2071&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
            "from": "00:10:00",
            "till": "00:20:00"
            },
            {
            "id": 2,
            "name": "Avocado",
            "img": "https://images.unsplash.com/photo-1523049673857-eb18f1d7b578?auto=format&fit=crop&q=80&w=1975&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
            "brand": "AvocadoBrand",
            "brandImg": "https://images.unsplash.com/photo-1523049673857-eb18f1d7b578?auto=format&fit=crop&q=80&w=1975&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
            "from": "00:15:00",
            "till": "00:25:00"
            }
]
}
```

### Get RecipeIngredient Request

```js
GET /recipes/{{id}}/ingredient/{{id}}
```

### Get RecipeIngredient Response

```js
200 Ok
```

```json
{
"id": 1,
"name": "Oatmeal",
"img": "https://images.unsplash.com/photo-1571748982800-fa51082c2224?auto=format&fit=crop&q=80&w=2071&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
"brand": "HealthyOats",
"brandImg": "https://images.unsplash.com/photo-1571748982800-fa51082c2224?auto=format&fit=crop&q=80&w=2071&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
"from": "00:10:00",
"till": "00:20:00"
}
```

### Get RecipeUtensil Request

```js
GET /recipes/{{id}}/utensil/{{id}}
```

### Get RecipeUtensil Response

```js
200 Ok
```

```json
{
"id": 1,
"name": "Measuring cup",
"img": "https://images.unsplash.com/photo-1586797166778-7cb76a618157?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
"from": "00:10:00",
"till": "00:20:00"
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
"img": "https://images.unsplash.com/photo-1571748982800-fa51082c2224?auto=format&fit=crop&q=80&w=2071&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
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