
import React, { useState, useEffect } from "react";
import {
  Grid,
  TableContainer,
  Table,
  LinearProgress,
  Typography,
} from "@mui/material";
import { createTheme } from "@mui/material/styles";
import TableHeader from "./TableHeader";

import RecipeRow from "./RecipeRow";
import IngredientRow from "./IngredientRow";
import UtensilRow from "./UtensilRow";
import { TableBody } from "@mui/material";
import "../../Style/List.css";
import { fetchData } from "/src/common/fetchData.js";
import { border } from "@mui/system";
import RecipeDetailsPopup from "./RecipeDetailsPopup";

const List = ({
  title,
  setValues,
  setOpenRecipePopup,
  setOpenTimingPopup,
  setOpenIngredientAndUtensilPopup,
}) => {
  const [data, setData] = useState({
    ingredients: [],
    utensils: [],
    recipes: [],
  });
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState(null);
  const [detailsPopupOpen, setDetailsPopupOpen] = useState(false);
  const [selectedRecipe, setSelectedRecipe] = useState(null);
  const openDetailsPopup = (recipe) => {
    setSelectedRecipe(recipe);
    setDetailsPopupOpen(true);
  };

  const handleCloseDetailsPopup = () => {
    setDetailsPopupOpen(false);
  };

  useEffect(() => {
    const loadData = async () => {
      setLoading(true);
      try {
        const ingredientData = await fetchData("/Ingredient");
        const utensilData = await fetchData("/Utensil");
        const recipeData = await fetchData("/Recipe");
        setData({
          ingredients: ingredientData,
          utensils: utensilData,
          recipes: recipeData,
        });
      } catch (error) {
        setError(error);
      } finally {
        setLoading(false);
      }
    };

    loadData();
  }, []);

  if (loading) return <LinearProgress />;
  if (error) return <Typography>Error: {error.message}</Typography>;
  const theme = createTheme({
    components: {
      // Styling for TableContainer
      MuiGrid: {
        styleOverrides: {
          root: {
            minWidth: "100%",
          },
        },
        MuiTableContainer: {
          styleOverrides: {
            root: {
              // Add your styles here
              border: "none",
            },
          },
        },
        // Styling for Table
        MuiTable: {
          styleOverrides: {
            root: {
              // Example styles
              borderCollapse: "separate",
              borderSpacing: "0 10px",
              border: "none",
            },
          },
        },
      },
    },
  });
  const getTableBody = () => {
    switch (title) {
      case "Recipe":
        return (
          <TableBody sx={{ border: "none" }} className="product__list recipe">
            {data.recipes.map((recipe) => (
              <RecipeRow
                className="product__list-row"
                key={recipe.id}
                recipe={recipe}
                setValues={setValues}
                setOpenPopup={setOpenRecipePopup}
                openDetailsPopup={openDetailsPopup} // Pass the function here
              />
            ))}
                    <RecipeDetailsPopup
              open={detailsPopupOpen}
              handleClose={handleCloseDetailsPopup}
              recipe={selectedRecipe}
            />
          </TableBody>
        );
      case "Ingredient":
        return (
          <TableBody className="product__list ingredient">
            {data.ingredients.map((ingredient) => (
              <IngredientRow
                key={ingredient.id}
                ingredient={ingredient}
                setValues={setValues}
                setOpenPopup={setOpenIngredientAndUtensilPopup}
              />
            ))}
          </TableBody>
        );
      case "Utensil":
        return (
          <TableBody className="product__list utensil">
            {data.utensils.map((utensil) => (
              <UtensilRow
                key={utensil.id}
                utensil={utensil}
                setValues={setValues}
                setOpenPopup={setOpenIngredientAndUtensilPopup}
              />
            ))}
        
          </TableBody>
        );
      default:
        return <TableBody></TableBody>;
    }
  };

  return (
    <Grid>
      <TableContainer>
        <Table
          sx={{
            borderCollapse: "separate",
            borderSpacing: "0 10px",
            border: "none",
          }}
        >
          <TableHeader
            sx={{
              boxShadow: "0px 20px 25px -15px RGB(213 217 219)",
              border: "black 1px solid",
            }}
            title={title}
          />
          {getTableBody()}
        </Table>

      </TableContainer>
    </Grid>
  );
};

export default List;
