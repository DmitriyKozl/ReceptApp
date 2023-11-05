use receptdb;

SELECT * FROM RecipeIngredient
WHERE RecipeID IN (SELECT RecipeID FROM Recipes);