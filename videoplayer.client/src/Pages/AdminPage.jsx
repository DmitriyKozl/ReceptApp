/* eslint-disable no-unused-vars */
import React, { useState } from "react";
import { useParams } from "react-router-dom";
import { Box, Button, Divider, Grid, Typography, Chip } from "@mui/material";
import { createTheme, styled } from "@mui/material/styles";

import Sidebar from "../Components/AdminTab";
import List from "../Components/AdminListComponents/List";
import { RecipePopup } from "../Components/RecipePopup";
import TimingPopup from "../Components/TimingPopup";
import IngredientAndUntensilPopup from "../Components/IngredientAndUtensilPopup";
import "./../Style/AdminPage.css";
import { width } from "@mui/system";

// Functional component for the 'Admin' page
const Admin = () => {
  // Extract the 'title' parameter from the URL using 'useParams' hook from 'react-router-dom'
  const { title } = useParams();
  const titleCapitalized = title.charAt(0).toUpperCase() + title.slice(1);
  // State variables to manage the visibility of different popups and store form values
  const [openRecipePopup, setOpenRecipePopup] = useState(false);
  const [openTimingPopup, setOpenTimingPopup] = useState(false);
  const [openIngredientAndUtensilPopup, setOpenIngredientAndUtensilPopup] =
    useState(false);
  const [values, setValues] = useState({});

  // Function to close all popups
  const handleClose = () => {
    setOpenRecipePopup(false);
    setOpenTimingPopup(false);
    setOpenIngredientAndUtensilPopup(false);
  };

  const theme = createTheme();

  theme.typography.h3 = {
    fontSize: "2rem",
    fontWeight: 400,
    marginBottom: "1rem",
    marginTop: "1rem",
    color: "#516975",
    fontStyle: "normal",
    lineHeight: "34px",
  };

  theme.typography.h5 = {
    fontSize: "1.3rem",
    fontWeight: 600,
    marginBottom: "0.5rem",
    marginTop: "0.5rem",
    color: "#0587C7",
    fontStyle: "normal",
    lineHeight: "34px",
  };

  theme.components = {
    MuiChip: {
      styleOverrides: {
        root: {
          borderRadius: "100px",
          border: "1px solid #0587C7",
          fontSize: "0.1rem",
          color: "#0587C7",
          padding: "0 1rem",
        },
    
      },
    },
  };

  // JSX for the 'Admin' component
  return (
    <>

      <Grid className="Admin_Container">
              <Sidebar className="Admin_Container-sidebar" title={titleCapitalized} />

        <Grid className="Admin_container-maincontrols" sx={{width:"75%"}}>
          {/* Main content area */}
          <Typography theme={theme} variant="h3">
            Video Shopping
          </Typography>
          <Divider />

          <Grid container marginTop={'2rem'} justifyContent={"space-between"} alignItems={"center"}>
            <Box>
              {/* Section title */}
              <Typography variant="h5" theme={theme}>
                {titleCapitalized}
              </Typography>
              <Divider sx={{ backgroundColor: "primary.dark" }} />
            </Box>
            {/* Button to add a new item based on the 'title' */}
            <Chip
              variant="outlined"
              theme={theme}
              onClick={() => {
                setValues({ title: titleCapitalized });
                if (title === "recipe") setOpenRecipePopup(true);
                else setOpenIngredientAndUtensilPopup(true);
              }}
              label={
                title === "recipe"
                  ? "+ add a recipe"
                  : title === "ingredient"
                  ? "+ add an ingredient"
                  : "+ add a utensil"
              }
            ></Chip>
          </Grid>

          {/* List component to display items based on the 'title' */}
          <List
            title={titleCapitalized}
            setValues={setValues}
            setOpenRecipePopup={setOpenRecipePopup}
            setOpenTimingPopup={setOpenTimingPopup}
            setOpenIngredientAndUtensilPopup={setOpenIngredientAndUtensilPopup}
          />

          {/* Popups for adding/editing recipes, timings, and ingredients/utensils */}
          <RecipePopup
            values={values}
            openRecipePopup={openRecipePopup}
            handleClose={handleClose}
          />
          <TimingPopup
            values={values}
            openTimingPopup={openTimingPopup}
            handleClose={handleClose}
          />
          <IngredientAndUntensilPopup
            values={values}
            openIngredientAndUtensilPopup={openIngredientAndUtensilPopup}
            handleClose={handleClose}
          />
        </Grid>
      </Grid>
    </>
  );
};

export default Admin;
