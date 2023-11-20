import React from 'react'
import { useNavigate } from 'react-router-dom'
import { Button, Grid, Typography } from '@mui/material'
import HomeIcon from '@mui/icons-material/Home';
import RestaurantMenuIcon from '@mui/icons-material/RestaurantMenu'
import IngredientIcon from '@mui/icons-material/ShoppingBasket'

export const Sidebar = (selected) => {
  const navigate = useNavigate()

  return (
    <Grid sx={{ backgroundColor: 'background.default', width: 100, textAlign: 'center' }}>
      <Button
        onClick={() => navigate('/home')}
        sx={{
          mt: 5,
          width: '100%',
          backgroundColor: !selected.title ? 'primary.dark' : 'background.default',
          color: '#fff',
          ':hover': {
            backgroundColor: !selected.title ? 'primary.dark' : 'background.default',
          },
        }}
      >
        <Grid>
          <HomeIcon />
          <Typography>HOME</Typography>
        </Grid>
      </Button>
      <Button
        onClick={() => navigate('/recipe')}
        sx={{
          mt: 2,
          width: '100%',
          backgroundColor: selected.title === 'recipe' ? 'primary.dark' : 'background.default',
          color: '#fff',
          ':hover': {
            backgroundColor: selected.title === 'recipe' ? 'primary.dark' : 'background.default',
          },
        }}
      >
        <Grid>
          <RestaurantMenuIcon />
          <Typography>recipe</Typography>
        </Grid>
      </Button>
      <Button
        onClick={() => navigate('/ingredient')}
        sx={{
          mt: 2,
          width: '100%',
          backgroundColor: selected.title === 'ingredient' ? 'primary.dark' : 'background.default',
          color: '#fff',
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
    </Grid>
  )
}
