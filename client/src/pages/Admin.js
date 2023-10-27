import React, { useState } from 'react'
import { useParams } from 'react-router-dom'
import { Box, Button, Dialog, DialogActions, Divider, Grid, Typography } from '@mui/material'
import { Sidebar } from '../components/Sidebar'
import { List } from '../components/List'
import { RecipeAndIngredientPopup } from '../components/RecipeAndIngredientPopup'
import { TimingPopup } from '../components/TimingPopup'

const Admin = () => {
  const { title } = useParams()

  const [openPopup, setOpenPopup] = useState(false)
  const [openTimingPopup, setOpenTimingPopup] = useState(false)
  const [values, setValues] = useState({})

  const handleClose = () => {
    setOpenPopup(false)
    setOpenTimingPopup(false)
  }

  return (
    <Grid
      container
      height='100vh'
      sx={{ backgroundColor: '#edf3f7' }}
    >
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
              setValues({})
              setOpenPopup(true)
            }}
            sx={{ border: 1, borderRadius: 10, m: 1 }}
          >
            {title === 'recipe' ? '+ add a recipe' : '+ add a ingredient'}
          </Button>
        </Grid>
        <List title={title} setValues={setValues} setOpenPopup={setOpenPopup} setOpenTimingPopup={setOpenTimingPopup} />
        <Dialog open={openPopup} onClose={handleClose}>
          <RecipeAndIngredientPopup title={title} values={values} />
          <DialogActions>
            <Button onClick={handleClose}>close</Button>
            <Button onClick={handleClose}>save</Button>
          </DialogActions>
        </Dialog>
        <Dialog open={openTimingPopup} onClose={setOpenTimingPopup}>
          <TimingPopup values={values} />
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
