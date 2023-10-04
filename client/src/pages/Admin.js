import React from 'react'
import { useParams } from 'react-router-dom'
import { Box, Button, Divider, Grid, Typography } from '@mui/material'
import { Sidebar } from '../components/Sidebar'
import { ReceptenList } from '../components/ReceptenList'

const Admin = () => {
  const { title } = useParams()

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
            <Typography sx={{ m: 1 }}>Recepten</Typography>
            <Divider />
          </Box>
          <Button sx={{ color: 'background.default', border: 1, borderRadius: 10, m: 1 }}>+ voeg een recept toe</Button>
        </Grid>
        <ReceptenList title={title} />
      </Grid>
    </Grid>
  )
}

export default Admin
