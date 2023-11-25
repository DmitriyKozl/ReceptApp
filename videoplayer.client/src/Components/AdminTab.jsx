// eslint-disable-next-line no-unused-vars
import React from "react";
import { useNavigate } from "react-router-dom";
import { Button, Grid, Typography } from "@mui/material";
import HomeIcon from "@mui/icons-material/Home";
import RestaurantMenuIcon from "@mui/icons-material/RestaurantMenu";
import IngredientIcon from "@mui/icons-material/ShoppingBasket";
import UtensilIcon from "@mui/icons-material/Restaurant";
const AdminTab = (selected) => {
  const navigate = useNavigate();
//TODO Make sidebar button on smartphone
  const buttonStyle = {
    width: "100%",
    color: "#fff",
    padding: "2rem 0",
    ":hover": {
      backgroundColor: "background.default",

    },
  };

  const tabs = [
    { title: "home", icon: <HomeIcon />, navigateTo: "/home" },
    { title: "Recipe", icon: <RestaurantMenuIcon />, navigateTo: "/recipe" },
    {
      title: "Ingredient",
      icon: <IngredientIcon />,
      navigateTo: "/ingredient",
    },
    { title: "Utensil", icon: <UtensilIcon />, navigateTo: "/utensil" },
  ];

  return (
    <Grid
    container
      direction="column"
      justifyContent="space-evenly"
      alignItems="center"
      left={0}
      position={"fixed"}
      zIndex={1}
      height={"100%"}
      sx={{
        backgroundColor: "background.default",
        width: 100,
        textAlign: "center",

      }}
    >
      {tabs.map((tab) => (
        <Button
          key={tab.navigateTo}
          onClick={() => navigate(tab.navigateTo)}
          sx={{
            ...buttonStyle,
            backgroundColor:
              selected.title === tab.title
                ? "primary.dark"
                : "background.default",
            ":hover": {
              backgroundColor:
                selected.title === tab.title
                  ? "primary.dark"
                  : "background.default",
            },
          }}
        >
          <Grid>
            {tab.icon}
            <Typography>{tab.title}</Typography>
          </Grid>
        </Button>
      ))}
    </Grid>
  );
};

export default AdminTab;
