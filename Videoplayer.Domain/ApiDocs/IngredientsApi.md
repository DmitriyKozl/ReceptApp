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
"img": "https://images.unsplash.com/photo-1571748982800-fa51082c2224?auto=format&fit=crop&q=80&w=2071&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
"brandImg": "https://images.unsplash.com/photo-1571748982800-fa51082c2224?auto=format&fit=crop&q=80&w=2071&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
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
"img": "https://images.unsplash.com/photo-1571748982800-fa51082c2224?auto=format&fit=crop&q=80&w=2071&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D","brandImg": "https://images.unsplash.com/photo-1571748982800-fa51082c2224?auto=format&fit=crop&q=80&w=2071&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
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
"img": "https://images.unsplash.com/photo-1571748982800-fa51082c2224?auto=format&fit=crop&q=80&w=2071&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D","brandImg": "https://images.unsplash.com/photo-1571748982800-fa51082c2224?auto=format&fit=crop&q=80&w=2071&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
"name": "Oatmeal",
"brand": "HealthyOats"
},
{
"id": 2,
"img": "https://images.unsplash.com/photo-1523049673857-eb18f1d7b578?auto=format&fit=crop&q=80&w=1975&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D","brandImg": "https://images.unsplash.com/photo-1523049673857-eb18f1d7b578?auto=format&fit=crop&q=80&w=1975&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
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
"img": "https://images.unsplash.com/photo-1571748982800-fa51082c2224?auto=format&fit=crop&q=80&w=2071&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
"brandImg": "https://images.unsplash.com/photo-1571748982800-fa51082c2224?auto=format&fit=crop&q=80&w=2071&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
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
"img": "https://images.unsplash.com/photo-1571748982800-fa51082c2224?auto=format&fit=crop&q=80&w=2071&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
"brandImg": "https://images.unsplash.com/photo-1571748982800-fa51082c2224?auto=format&fit=crop&q=80&w=2071&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
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
