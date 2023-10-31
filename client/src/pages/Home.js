import React from 'react'
import { Topbar } from '../components/Topbar'
import { Grid, Typography } from '@mui/material'
import Banner from '../assets/banner.jpeg'

const Home = () => {
  return (
    <Grid>
      <Topbar />
      <img src={Banner} alt={'background'} />
      <Typography variant='h2' sx={{ color: '#fff', m: '-170px 0 0 78px', width: 600 }}>
        Shop anything, from any video
      </Typography>
    </Grid>
  )
}

export default Home
