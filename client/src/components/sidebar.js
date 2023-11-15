import React from 'react'
import { useNavigate } from 'react-router-dom'
import { Button, Grid, Typography } from '@mui/material'
import HomeIcon from '@mui/icons-material/Home'
import RestaurantMenuIcon from '@mui/icons-material/RestaurantMenu'
import IngredientIcon from '@mui/icons-material/ShoppingBasket'
import UtensilIcon from '@mui/icons-material/Restaurant'

export const Sidebar = (selected) => {
  const navigate = useNavigate()

  const buttonStyle = {
    mt: 2,
    width: '100%',
    color: '#fff',
    ':hover': {
      backgroundColor: 'background.default',
    },
  }

  return (
    <Grid sx={{ backgroundColor: 'background.default', width: 100, textAlign: 'center' }}>
      <Button
        onClick={() => navigate('/home')}
        sx={{
          ...buttonStyle,
          mt: 5,
          backgroundColor: !selected.title ? 'primary.dark' : 'background.default',
          ':hover': {
            backgroundColor: !selected.title ? 'primary.dark' : 'background.default',
          },
        }}
      >
        <Grid>
          <HomeIcon />
          <Typography>home</Typography>
        </Grid>
      </Button>
      <Button
        onClick={() => navigate('/recipe')}
        sx={{
          ...buttonStyle,
          backgroundColor: selected.title === 'recipe' ? 'primary.dark' : 'background.default',
          ':hover': {
            backgroundColor: selected.title === 'recipe' ? 'primary.dark' : 'background.default',
          },
        }}
      >
        <Grid>
          <RestaurantMenuIcon />
          <Typography>Recipe</Typography>
        </Grid>
      </Button>
      <Button
        onClick={() => navigate('/ingredient')}
        sx={{
          ...buttonStyle,
          backgroundColor: selected.title === 'ingredient' ? 'primary.dark' : 'background.default',
          ':hover': {
            backgroundColor: selected.title === 'ingredient' ? 'primary.dark' : 'background.default',
          },
        }}
      >
        <Grid>
          <IngredientIcon />
          <Typography>Ingredient</Typography>
        </Grid>
      </Button>
      <Button
        onClick={() => navigate('/utensil')}
        sx={{
          ...buttonStyle,
          backgroundColor: selected.title === 'utensil' ? 'primary.dark' : 'background.default',
          ':hover': {
            backgroundColor: selected.title === 'utensil' ? 'primary.dark' : 'background.default',
          },
        }}
      >
        <Grid>
          <UtensilIcon />
          <Typography>Utensil</Typography>
        </Grid>
      </Button>
    </Grid>
  )
}
