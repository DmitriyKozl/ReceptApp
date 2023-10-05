import React from 'react'
import { useNavigate } from 'react-router-dom'
import { Button, Grid, Typography } from '@mui/material'
import RestaurantMenuIcon from '@mui/icons-material/RestaurantMenu'
import TimerIcon from '@mui/icons-material/Timer'

export const Sidebar = (selected) => {
  const navigate = useNavigate()

  return (
    <Grid sx={{ backgroundColor: 'background.default', width: 100, textAlign: 'center' }}>
      <Button
        onClick={() => navigate('/recipe')}
        sx={{ mt: 5, width: '100%', backgroundColor: selected.title === 'recipe' ? '#035e8b' : 'background.default' }}
      >
        <Grid>
          <RestaurantMenuIcon />
          <Typography>recipe</Typography>
        </Grid>
      </Button>
      <Button
        onClick={() => navigate('/timing')}
        sx={{ mt: 2, width: '100%', backgroundColor: selected.title === 'timing' ? '#035e8b' : 'background.default' }}
      >
        <Grid>
          <TimerIcon />
          <Typography>Timing</Typography>
        </Grid>
      </Button>
    </Grid>
  )
}
