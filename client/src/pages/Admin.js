import React, { useState } from 'react'
import { useParams } from 'react-router-dom'
import { Box, Button, Dialog, DialogActions, Divider, Grid, IconButton, Typography } from '@mui/material'
import { Sidebar } from '../components/Sidebar'
import { List } from '../components/List'
import { RecipePopup } from '../components/RecipePopup'
import { TimingPopup } from '../components/TimingPopup'
import { IngredientAndUntensilPopup } from '../components/IngredientAndUtensilPopup'
import CloseIcon from '@mui/icons-material/Close'

const Admin = () => {
  const { title } = useParams()

  const [openRecipePopup, setOpenRecipePopup] = useState(false)
  const [openTimingPopup, setOpenTimingPopup] = useState(false)
  const [openIngredientPopup, setOpenIngredientAndUtensilPopup] = useState(false)
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
        <Dialog open={openRecipePopup} onClose={handleClose} PaperProps={{ sx: { borderRadius: '20px' } }}>
          <IconButton sx={{ position: 'absolute', alignSelf: 'end' }} onClick={handleClose}>
            <CloseIcon fontSize='large' />
          </IconButton>
          <RecipePopup values={values} />
          <DialogActions sx={{ justifyContent: 'center' }}>
            <Button
              onClick={handleClose}
              sx={{
                p: '10px 50px',
                borderRadius: '20px',
                color: '#fff',
                backgroundColor: 'primary.main',
                ':hover': { backgroundColor: 'primary.main' },
              }}
            >
              save
            </Button>
          </DialogActions>
        </Dialog>
        <Dialog open={openTimingPopup} onClose={handleClose} PaperProps={{ sx: { borderRadius: '20px' } }}>
          <IconButton sx={{ position: 'absolute', alignSelf: 'end' }} onClick={handleClose}>
            <CloseIcon fontSize='large' />
          </IconButton>
          <TimingPopup values={values} />
          <DialogActions sx={{ justifyContent: 'center' }}>
            <Button
              onClick={handleClose}
              sx={{
                p: '10px 50px',
                borderRadius: '20px',
                color: '#fff',
                backgroundColor: 'primary.main',
                ':hover': { backgroundColor: 'primary.main' },
              }}
            >
              save
            </Button>
          </DialogActions>
        </Dialog>
        <Dialog open={openIngredientPopup} onClose={handleClose} PaperProps={{ sx: { borderRadius: '20px' } }}>
          <IconButton sx={{ position: 'absolute', alignSelf: 'end' }} onClick={handleClose}>
            <CloseIcon fontSize='large' />
          </IconButton>
          <IngredientAndUntensilPopup values={values} />
          <DialogActions sx={{ justifyContent: 'center' }}>
            <Button
              onClick={handleClose}
              sx={{
                p: '10px 50px',
                borderRadius: '20px',
                color: '#fff',
                backgroundColor: 'primary.main',
                ':hover': { backgroundColor: 'primary.main' },
              }}
            >
              save
            </Button>
          </DialogActions>
        </Dialog>
      </Grid>
    </Grid>
  )
}

export default Admin
