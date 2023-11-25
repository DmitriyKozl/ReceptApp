import React, { useEffect, useState } from "react";
import axios from "axios";

import "../../Style/List.css";

import {
  Dialog,
  DialogTitle,
  DialogContent,
  Avatar,
  Grid,
  Typography,
  TableBody,
  TableContainer,
  Table,
} from "@mui/material";
import { ThemeProvider, createTheme } from "@mui/material/styles";
import IngredientRow from "./IngredientRow";
import TableHeader from "./TableHeader";
const fetchUnsplashImage = async (query) => {
  const accessKey = 'SU50t0MEv1tBO1IKLPaMgUd_Zfd0PIqrZpGc1mwhAPU';
  const url = `https://api.unsplash.com/search/photos?query=${query}&client_id=${accessKey}`;
  try {
    const response = await axios.get(url);
    return response.data.results[0].urls.regular; // Get the first image's URL
  } catch (error) {
    console.error("Error fetching image from Unsplash", error);
    return null; // Handle error appropriately
  }
};
const theme = createTheme({
  components: {
    // Style overrides for Dialog component
    MuiDialog: {
      styleOverrides: {
        paper: {
          width: "100%",
          height: "100%",
          borderRadius: "50px",
          backgroundColor: "#edf3f7",
        },
      },
    },
    // Style overrides for DialogContent
    MuiDialogContent: {
      styleOverrides: {
        root: {},
      },
    },
    // Style overrides for Grid
    MuiGrid: {
      styleOverrides: {
        root: {
          backgroundColor: "transparent",
          margin: "0",
        },
      },
    },
    // Style overrides for Avatar
    MuiAvatar: {
      styleOverrides: {
        root: {

          width: "100px",
          height: "100px",        },
      },
    },
    // Style overrides for Typography
    MuiTypography: {
      styleOverrides: {
        h6: {
          // Add your styles for variant="h6" here (e.g., font size, weight)
        },
        subtitle1: {
          color: "#516975",
          fontFamily: "inherit",
          fontSize: "1rem",
          fontStyle: "normal",
        },
      },
    },
    // Style overrides for List and ListItem
    MuiTable: {
      styleOverrides: {
        root: {
          // Example styles
          borderCollapse: "separate",
          borderSpacing: "0 10px",
        },
      },
    },
    MuiTableBody: {
      styleOverrides: {
        root: {
          backgroundColor: "white",
        },
      },
    },
    // You can continue adding overrides for other components if needed
  },
});

const RecipeDetailsPopup = ({
  open,
  handleClose,
  recipe,
  setValues,
  setOpenIngredientAndUtensilPopup,
}) => {
  const [unsplashImage, setUnsplashImage] = useState(null);

  useEffect(() => {
    if (recipe) {
      const loadImage = async () => {
        const imageUrl = await fetchUnsplashImage(recipe.name);
        setUnsplashImage(imageUrl);
      };

      loadImage();
    }
  }, [recipe]);

  if (!recipe) return null;
  return (
    <ThemeProvider theme={theme}>
      <Dialog open={open} onClose={handleClose}>
        <DialogContent>
          <Grid container spacing={6}>
            <Grid item>
            <Avatar src={unsplashImage || recipe.img} style={{ width: "100px", height: "100px" }} />
            </Grid>
            <Grid item xs={6} sx={{display:"flex", justifyContent:"center", alignItems:"center"}}>
              <Typography variant="h6">{recipe.name}</Typography>
              {/* Display other recipe details like servings, cooking time, etc. */}
            </Grid>
            <Grid item xs={10}>
              <Typography variant="subtitle1">Ingredients:</Typography>
              <TableContainer>
                <Table>
                  <TableHeader
                    sx={{
                      boxShadow: "0px 20px 25px -15px RGB(213 217 219)",
                      border: "black 1px solid",
                    }}
                    title={'Ingredient'}
                  />
                  <TableBody>
                    {recipe.ingredients.map((ingredient) => (
                      <IngredientRow
                        key={ingredient.id}
                        ingredient={ingredient}
                        setValues={setValues}
                        setOpenPopup={setOpenIngredientAndUtensilPopup}
                      />
                    ))}
                  </TableBody>
                </Table>
              </TableContainer>
            </Grid>
            {/* Display other information like utensils if necessary */}
          </Grid>
        </DialogContent>
      </Dialog>
    </ThemeProvider>
  );
};

export default RecipeDetailsPopup;
