import React from 'react'
import { useNavigate } from 'react-router-dom'
import { AppBar, Box, Button, Chip, IconButton, Toolbar } from '@mui/material'
import PersonIcon from '@mui/icons-material/PersonOutlined'
import FavoriteIcon from '@mui/icons-material/FavoriteBorderOutlined'
import ShoppingCartIcon from '@mui/icons-material/ShoppingCartOutlined'
import logo from '../assets/logo.png'

export const Topbar = () => {
  const navigate = useNavigate()

  return (
    <AppBar position='static' sx={{ backgroundColor: '#fff' }}>
      <Toolbar sx={{ justifyContent: 'space-between' }}>
        <Box>
          <Button>
            <img src={logo} alt={'logo'} />
          </Button>
          <Chip label='Video Shopping' sx={{ color: 'primary.main', backgroundColor: 'primary.light', m: 2 }} />
        </Box>
        <Box>
          <IconButton
            onClick={() => {
              navigate('/login')
            }}
          >
            <PersonIcon />
          </IconButton>
          <IconButton>
            <FavoriteIcon />
          </IconButton>
          <IconButton>
            <ShoppingCartIcon />
          </IconButton>
        </Box>
      </Toolbar>
    </AppBar>
  )
}
