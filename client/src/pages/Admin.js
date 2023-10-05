import React, { useState } from 'react'
import { useParams } from 'react-router-dom'
import { Box, Button, Dialog, DialogActions, Divider, Grid, Typography } from '@mui/material'
import { Sidebar } from '../components/Sidebar'
import { RecipeList } from '../components/RecipeList'
import { Popup } from '../components/Popup'

const Admin = () => {
  const { title } = useParams()

  const [open, setOpen] = useState(false)

  const handleClose = () => {
    setOpen(false)
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
              setOpen(true)
            }}
            sx={{ color: 'background.default', border: 1, borderRadius: 10, m: 1 }}
          >
            {title === 'recipe' ? '+ add a recipe' : '+ add a ingredient'}
          </Button>
        </Grid>
        <RecipeList title={title} />
        <Dialog open={open} onClose={handleClose}>
          <Popup title={title} />
          <DialogActions>
            <Button onClick={handleClose} sx={{ color: 'background.default' }}>
              close
            </Button>
            <Button onClick={handleClose} sx={{ color: 'background.default' }} autoFocus>
              save
            </Button>
          </DialogActions>
        </Dialog>
      </Grid>
    </Grid>
  )
}

export default Admin
