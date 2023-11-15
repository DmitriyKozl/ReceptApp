import React, { useState } from 'react'
import { useParams } from 'react-router-dom'
import { Box, Button, Divider, Grid, Typography } from '@mui/material'
import { Sidebar } from '../components/Sidebar'
import { List } from '../components/List'
import { RecipePopup } from '../components/RecipePopup'
import { TimingPopup } from '../components/TimingPopup'
import { IngredientAndUntensilPopup } from '../components/IngredientAndUtensilPopup'

// Functional component for the 'Admin' page
const Admin = () => {
  // Extract the 'title' parameter from the URL using 'useParams' hook from 'react-router-dom'
  const { title } = useParams()

  // State variables to manage the visibility of different popups and store form values
  const [openRecipePopup, setOpenRecipePopup] = useState(false)
  const [openTimingPopup, setOpenTimingPopup] = useState(false)
  const [openIngredientAndUtensilPopup, setOpenIngredientAndUtensilPopup] = useState(false)
  const [values, setValues] = useState({})

  // Function to close all popups
  const handleClose = () => {
    setOpenRecipePopup(false)
    setOpenTimingPopup(false)
    setOpenIngredientAndUtensilPopup(false)
  }

  // JSX for the 'Admin' component
  return (
    <Grid container height='100%' minHeight='100vh' sx={{ backgroundColor: '#edf3f7' }}>
      {/* Sidebar component with the 'title' as a prop */}
      <Sidebar title={title} />
      <Grid m={5} sx={{ width: '70%' }}>
        {/* Main content area */}
        <Typography variant='h3' m={1}>
          Video Shopping
        </Typography>
        <Divider />

        {/* Container for the section title and add button */}
        <Grid container sx={{ width: '100%' }} justifyContent={'space-between'}>
          <Box>
            {/* Section title */}
            <Typography variant='h5' sx={{ m: '8px 8px 0 8px', color: 'primary.dark' }}>
              {title}
            </Typography>
            <Divider sx={{ backgroundColor: 'primary.dark' }} />
          </Box>
          {/* Button to add a new item based on the 'title' */}
          <Button
            onClick={() => {
              setValues({ title: title })
              // Determine which popup to open based on the 'title'
              if (title === 'recipe') setOpenRecipePopup(true)
              else setOpenIngredientAndUtensilPopup(true)
            }}
            sx={{ border: 1, borderRadius: 10, m: 1 }}
          >
            {/* Button label based on the 'title' */}
            {title === 'recipe' ? '+ add a recipe' : title === 'ingredient' ? '+ add an ingredient' : '+ add a utensil'}
          </Button>
        </Grid>

        {/* List component to display items based on the 'title' */}
        <List
          title={title}
          setValues={setValues}
          setOpenRecipePopup={setOpenRecipePopup}
          setOpenTimingPopup={setOpenTimingPopup}
          setOpenIngredientAndUtensilPopup={setOpenIngredientAndUtensilPopup}
        />

        {/* Popups for adding/editing recipes, timings, and ingredients/utensils */}
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
