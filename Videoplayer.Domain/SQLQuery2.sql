﻿SELECT COLUMN_NAME, COLUMNPROPERTY(OBJECT_ID(TABLE_NAME), COLUMN_NAME, 'IsIdentity') AS IsIdentity
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'Recipes' AND COLUMN_NAME = 'RecipeID';