import React from 'react'
import { useNavigate } from 'react-router-dom'
import { Button, Grid, Typography } from '@mui/material'
import RestaurantMenuIcon from '@mui/icons-material/RestaurantMenu'
import TimerIcon from '@mui/icons-material/Timer'

export const Sidebar = () => {
  const navigate = useNavigate()

  return (
    <Grid sx={{ backgroundColor: 'background.default', width: 100, textAlign: 'center' }}>
      <Button onClick={() => navigate('/recepten')} sx={{ mt: 2 }}>
        <Grid>
          <RestaurantMenuIcon />
          <Typography>Recepten</Typography>
        </Grid>
      </Button>
      <Button onClick={() => navigate('/timing')} sx={{ mt: 2 }}>
        <Grid>
          <TimerIcon />
          <Typography>Timing</Typography>
        </Grid>
      </Button>
    </Grid>
  )
}
