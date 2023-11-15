import React, { useState } from 'react'
import { useParams } from 'react-router-dom'
import { Box, Button, Divider, Grid, Typography } from '@mui/material'
import { Sidebar } from '../components/Sidebar'
import { List } from '../components/List'
import { RecipePopup } from '../components/RecipePopup'
import { TimingPopup } from '../components/TimingPopup'
import { IngredientAndUntensilPopup } from '../components/IngredientAndUtensilPopup'

const Admin = () => {
  const { title } = useParams()

  const [openRecipePopup, setOpenRecipePopup] = useState(false)
  const [openTimingPopup, setOpenTimingPopup] = useState(false)
  const [openIngredientAndUtensilPopup, setOpenIngredientAndUtensilPopup] = useState(false)
  const [values, setValues] = useState({})

  const handleClose = () => {
    setOpenRecipePopup(false)
    setOpenTimingPopup(false)
    setOpenIngredientAndUtensilPopup(false)
  }

  return (
    <Grid container height='100%' minHeight='100vh' sx={{ backgroundColor: '#edf3f7' }}>
      <Sidebar title={title} />
      <Grid m={5} sx={{ width: '70%' }}>
        <Typography variant='h3' m={1}>
          Video Shopping
        </Typography>
        <Divider />
        <Grid container sx={{ width: '100%' }} justifyContent={'space-between'}>
          <Box>
            <Typography variant='h5' sx={{ m: '8px 8px 0 8px', color: 'primary.dark' }}>
              {title}
            </Typography>
            <Divider sx={{ backgroundColor: 'primary.dark' }} />
          </Box>
          <Button
            onClick={() => {
              setValues({ title: title })
              if (title === 'recipe') setOpenRecipePopup(true)
              else setOpenIngredientAndUtensilPopup(true)
            }}
            sx={{ border: 1, borderRadius: 10, m: 1 }}
          >
            {title === 'recipe' ? '+ add a recipe' : title === 'ingredient' ? '+ add a ingredient' : '+ add a utensil'}
          </Button>
        </Grid>
        <List
          title={title}
          setValues={setValues}
          setOpenRecipePopup={setOpenRecipePopup}
          setOpenTimingPopup={setOpenTimingPopup}
          setOpenIngredientAndUtensilPopup={setOpenIngredientAndUtensilPopup}
        />
        <RecipePopup values={values} openRecipePopup={openRecipePopup} handleClose={handleClose} />
        <TimingPopup values={values} openTimingPopup={openTimingPopup} handleClose={handleClose} />
        <IngredientAndUntensilPopup
          values={values}
          openIngredientAndUtensilPopup={openIngredientAndUtensilPopup}
          handleClose={handleClose}
        />
      </Grid>
    </Grid>
  )
}

export default Admin
