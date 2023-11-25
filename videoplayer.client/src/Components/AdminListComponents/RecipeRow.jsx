/* eslint-disable no-unused-vars */
// RecipeRow.js
import React, { useState,useEffect  } from "react";
import {
  TableRow,
  TableCell,
  Table,
  TableHead,
  TableBody,
  IconButton,
  Avatar,
  Collapse,
  Box,
  Grid,
  Typography,
  Button,
} from "@mui/material";
import EditIcon from "@mui/icons-material/Edit";
import DeleteIcon from "@mui/icons-material/Delete";
import OpenInNewOutlinedIcon from "@mui/icons-material/OpenInNewOutlined";
import KeyboardArrowDownIcon from "@mui/icons-material/KeyboardArrowDown";
import KeyboardArrowUpIcon from "@mui/icons-material/KeyboardArrowUp";
import { createTheme, ThemeProvider } from "@mui/material/styles";
import { border, borderRadius } from "@mui/system";
import axios from "axios";

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
const RecipeRow = ({ recipe, setValues, setOpenPopup, openDetailsPopup }) => {
  // const [open, setOpen] = useState(false);
  const [unsplashImage, setUnsplashImage] = useState(null);

  useEffect(() => {
    const loadImage = async () => {
      const imageUrl = await fetchUnsplashImage(recipe.name);
      setUnsplashImage(imageUrl);
    };

    loadImage();
  }, [recipe.name]);
  const handleOpenEditPopup = () => {
    setValues({ title: "Recipe", id: recipe.id });
    setOpenPopup(false);
  };

  // const toggleCollapse = () => {
  //   setOpen(!open);
  // };
  const handleOpenDetailsPopup = () => {
    openDetailsPopup(recipe); // Pass the recipe data to the popup
  };
  const theme = createTheme({
    components: {
      MuiTableCell: {
        styleOverrides: {
          root: {
            // Targeting cells specifically in the TableHead
            // Add your styles here
            color: "#516975",
            fontFamily: "inherit",
            fontSize: "0.8rem",
            fontStyle: "normal",
            fontWeight: "800",
            lineHeight: "normal",
            padding: "0.4rem",
            border: "none",
          },
          firstCell: {
            borderRadius: "100px 0 0 100px",
          },
        },
      },
    },
  });

  return (
    <>
      <ThemeProvider theme={theme}>
        <TableRow>
          {/* Table Cells for Recipe Row */}
          <TableCell sx={{ borderRadius: "100px 0 0 100px " }}>
            <IconButton onClick={handleOpenDetailsPopup}>
              {open ? <OpenInNewOutlinedIcon /> : <OpenInNewOutlinedIcon />}
            </IconButton>
          </TableCell>
          <TableCell>
          <Avatar src={unsplashImage || recipe.img} />
          </TableCell>
          <TableCell>{recipe.name}</TableCell>
          <TableCell>{recipe.videoLink}</TableCell>
          <TableCell>{recipe.servings}</TableCell>
          <TableCell>{recipe.cookingTime}</TableCell>
          <TableCell align="center" sx={{ borderRadius: "0 100px   100px 0" }}>
            <IconButton onClick={handleOpenEditPopup}>
              <EditIcon />
            </IconButton>
            <IconButton>
              <DeleteIcon />
            </IconButton>
          </TableCell>
        </TableRow>
      </ThemeProvider>
  
    </>
  );
};

export default RecipeRow;
