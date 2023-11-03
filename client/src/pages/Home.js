import React from 'react'
import {
  Card,
  CardActionArea,
  CardContent,
  CardMedia,
  Checkbox,
  Grid,
  ImageList,
  List,
  ListItem,
  Typography,
} from '@mui/material'
import Banner from '../assets/banner.jpeg'

const Home = () => {
  const dummydataRecipe = [
    {
      id: 1,
      img: 'https://images.unsplash.com/photo-1517427294546-5aa121f68e8a?auto=format&fit=crop&q=80&w=1964&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D',
      name: 'Surprise Chocoladetaart',
    },
    {
      id: 2,
      img: 'https://images.unsplash.com/photo-1629115916087-7e8c114a24ed?auto=format&fit=crop&q=80&w=1964&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D',
      name: 'Lasagne Bolognese',
    },
    {
      id: 3,
      img: 'https://images.unsplash.com/photo-1610393742736-72b0185368dc?auto=format&fit=crop&q=80&w=1974&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D',
      name: 'Aardbei confituur',
    },
    {
      id: 1,
      img: 'https://images.unsplash.com/photo-1517427294546-5aa121f68e8a?auto=format&fit=crop&q=80&w=1964&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D',
      name: 'Surprise Chocoladetaart',
    },
    {
      id: 2,
      img: 'https://images.unsplash.com/photo-1629115916087-7e8c114a24ed?auto=format&fit=crop&q=80&w=1964&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D',
      name: 'Lasagne Bolognese',
    },
    {
      id: 3,
      img: 'https://images.unsplash.com/photo-1610393742736-72b0185368dc?auto=format&fit=crop&q=80&w=1974&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D',
      name: 'Aardbei confituur',
    },
    {
      id: 1,
      img: 'https://images.unsplash.com/photo-1517427294546-5aa121f68e8a?auto=format&fit=crop&q=80&w=1964&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D',
      name: 'Surprise Chocoladetaart',
    },
    {
      id: 2,
      img: 'https://images.unsplash.com/photo-1629115916087-7e8c114a24ed?auto=format&fit=crop&q=80&w=1964&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D',
      name: 'Lasagne Bolognese',
    },
    {
      id: 3,
      img: 'https://images.unsplash.com/photo-1610393742736-72b0185368dc?auto=format&fit=crop&q=80&w=1974&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D',
      name: 'Aardbei confituur',
    },
  ]

  return (
    <Grid sx={{ overflowX: 'hidden', mt: '65px' }}>
      <img src={Banner} alt={'background'} />
      <Typography variant='h2' sx={{ color: '#fff', m: '-170px 0 0 78px', width: 600, pb: 3 }}>
        Shop anything, from any video
      </Typography>
      <Grid container sx={{ p: 4 }}>
        <Grid sx={{ flex: 1 }}>
          <Typography variant='h5'>Filters</Typography>
          <List>
            <ListItem>
              <Checkbox />
              <Typography>Lorem Ipsum</Typography>
            </ListItem>
            <ListItem>
              <Checkbox />
              <Typography>Lorem Ipsum</Typography>
            </ListItem>
            <ListItem>
              <Checkbox />
              <Typography>Lorem Ipsum</Typography>
            </ListItem>
          </List>
        </Grid>
        <Grid sx={{ flex: 4, mb: 2 }}>
          <ImageList sx={{ width: '100%' }} cols={4}>
            {dummydataRecipe.map((e) => (
              <Card sx={{ maxWidth: 345 }}>
                <CardActionArea>
                  <CardMedia component='img' height='140' image={e.img} alt={e.name} />
                  <CardContent>
                    <Typography variant='h5'>{e.name}</Typography>
                  </CardContent>
                </CardActionArea>
              </Card>
            ))}
          </ImageList>
        </Grid>
      </Grid>
    </Grid>
  )
}

export default Home
