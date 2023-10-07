import React, { useState } from 'react'
import { useParams } from 'react-router-dom'
import { Box, Button, Dialog, DialogActions, Divider, Grid, Typography } from '@mui/material'
import { Sidebar } from '../components/Sidebar'
import { RecipeList } from '../components/RecipeList'
import { RecipePopup } from '../components/RecipePopup'
import { IngredientPopup } from '../components/IngredientPopup'

const Admin = () => {
  const { title } = useParams()

  const [openPopup, setOpenPopup] = useState(false)
  const [values, setValues] = useState({})

  const handleClose = () => {
    setOpenPopup(false)
  }

  return (
    <Grid container height='100vh'>
      <Sidebar title={title} />
      <Grid m={5} sx={{ width: '70%' }}>
        <Typography variant='h3' m={1}>
          Video Shopping
        </Typography>
        <Divider />
        <Grid container sx={{ width: '100%' }} justifyContent={'space-between'}>
          <Box>
            <Typography sx={{ m: 1 }}>{title}</Typography>
            <Divider />
          </Box>
          <Button
            onClick={() => {
              setValues({})
              setOpenPopup(true)
            }}
            sx={{ border: 1, borderRadius: 10, m: 1 }}
          >
            {title === 'recipe' ? '+ add a recipe' : '+ add a ingredient'}
          </Button>
        </Grid>
        <RecipeList title={title} setValues={setValues} setOpenPopup={setOpenPopup} />
        <Dialog open={openPopup} onClose={handleClose}>
          {title === 'recipe' ? <RecipePopup values={values} /> : <IngredientPopup values={values} />}
          <DialogActions>
            <Button onClick={handleClose}>close</Button>
            <Button onClick={handleClose}>save</Button>
          </DialogActions>
        </Dialog>
      </Grid>
    </Grid>
  )
}

export default Admin
