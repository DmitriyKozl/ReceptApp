// eslint-disable-next-line no-unused-vars
import React, { useState } from 'react'
import { useNavigate } from 'react-router-dom'
import { AppBar, Avatar, Box, Button, Chip, Divider, Grid, IconButton, Menu, Toolbar, Typography } from '@mui/material'
import PersonIcon from '@mui/icons-material/PersonOutlined'
import FavoriteIcon from '@mui/icons-material/FavoriteBorderOutlined'
import ShoppingCartIcon from '@mui/icons-material/ShoppingCartOutlined'
import logo from '../assets/logo.png'

export const Navbar = () => {
  const navigate = useNavigate()

  const [anchorl, setAnchorl] = useState(null)
  const [anchor2, setAnchor2] = useState(null)

  const handleClose = () => {
    setAnchorl(null)
    setAnchor2(null)
  }

  const dummydataShoppingCart = [
    {
      name: 'Chocolade',
      brand: 'boni',
      price: '€ 3,19',
      img: 'https://images.unsplash.com/photo-1623660053975-cf75a8be0908?auto=format&fit=crop&q=80&w=1974&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D',
      brandImg:
        'https://www.colruytgroup.com/content/dam/colruytgroup/merken/consumentenmerken/boni/LP_reference-image_boni-new.png/_jcr_content/renditions/cq5dam.web.1280.1280.png',
    },
    {
      name: 'aardbeien',
      brand: 'boni',
      price: '€ 2,79',
      img: 'https://images.unsplash.com/photo-1587393855524-087f83d95bc9?auto=format&fit=crop&q=80&w=1960&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D',
      brandImg:
        'https://www.colruytgroup.com/content/dam/colruytgroup/merken/consumentenmerken/boni/LP_reference-image_boni-new.png/_jcr_content/renditions/cq5dam.web.1280.1280.png',
    },
    {
      name: 'gehakt',
      brand: 'boni',
      price: '€ 6,49',
      img: 'https://plus.unsplash.com/premium_photo-1670357599528-c604816e04f6?auto=format&fit=crop&q=80&w=1974&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D',
      brandImg:
        'https://www.colruytgroup.com/content/dam/colruytgroup/merken/consumentenmerken/boni/LP_reference-image_boni-new.png/_jcr_content/renditions/cq5dam.web.1280.1280.png',
    },
  ]

  return (
    <AppBar sx={{ backgroundColor: '#fff'  }}>
      <Toolbar sx={{ justifyContent: 'space-between', width:1600, margin:"auto"}}>
        <Box>
          <Button
            onClick={() => {
              navigate('/home')
            }}
          >
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
          <IconButton
            onClick={(e) => {
              setAnchorl(e.currentTarget)
            }}
          >
            <FavoriteIcon />
          </IconButton>
          <Menu
            anchorEl={anchorl}
            anchorOrigin={{
              vertical: 'bottom',
              horizontal: 'right',
            }}
            keepMounted
            transformOrigin={{
              vertical: 'top',
              horizontal: 'right',
            }}
            open={Boolean(anchorl)}
            onClose={handleClose}
          >
            <Box sx={{ width: 300 }}>
              <Typography variant='h5' sx={{ textAlign: 'center' }}>
                Shopping List
              </Typography>
              <Divider />
              {dummydataShoppingCart.map((row) => (
                <Grid key={row.name}>
                  <Grid container sx={{ flexDirection: 'row', alignItems: 'center' }}>
                    <Avatar src={row.img} sx={{ m: 1, height: 20, width: 20 }} />
                    <Typography>{row.name}</Typography>
                  </Grid>
                  <Divider />
                </Grid>
              ))}
            </Box>
          </Menu>
          <IconButton
            onClick={(e) => {
              setAnchor2(e.currentTarget)
            }}
          >
            <ShoppingCartIcon />
          </IconButton>
          <Menu
            anchorEl={anchor2}
            anchorOrigin={{
              vertical: 'bottom',
              horizontal: 'right',
            }}
            keepMounted
            transformOrigin={{
              vertical: 'top',
              horizontal: 'right',
            }}
            open={Boolean(anchor2)}
            onClose={handleClose}
          >
            <Box sx={{ width: 300 }}>
              <Typography variant='h5' sx={{ textAlign: 'center' }}>
                Shopping Cart
              </Typography>
              <Divider />
              {dummydataShoppingCart.map((row) => (
                <Grid key={row.name}>
                  <Grid container sx={{ flexDirection: 'row', alignItems: 'center' }}>
                    <Avatar src={row.img} sx={{ flex: 1, m: 1, height: 20, width: 20 }} />
                    <Typography sx={{ flex: 10 }}>{row.name}</Typography>
                    <Typography sx={{ flex: 3, m: 1, textAlign: 'end' }}>{row.price}</Typography>
                  </Grid>
                  <Grid container sx={{ flexDirection: 'row', alignItems: 'center' }}>
                    <Avatar src={row.brandImg} sx={{ m: 1, height: 20, width: 20 }} />
                    <Typography>{row.brand}</Typography>
                  </Grid>
                  <Divider />
                </Grid>
              ))}
              <Grid container sx={{ flexDirection: 'row', alignItems: 'center' }}>
                <Typography variant='h6' sx={{ flex: 1, m: 1 }}>
                  Total:
                </Typography>
                <Typography sx={{ flex: 4, m: 1, textAlign: 'end' }}>€ 12,47</Typography>
                <Button variant='contained' sx={{ flex: 1, m: 1, borderRadius: 20 }}>
                  ORDER
                </Button>
              </Grid>
            </Box>
          </Menu>
        </Box>
      </Toolbar>
    </AppBar>
  )
}

export default Navbar