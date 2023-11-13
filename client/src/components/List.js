/* eslint-disable no-unused-vars */
import React, { useState } from 'react'
import {
  Avatar,
  Box,
  Button,
  Collapse,
  Grid,
  IconButton,
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
  Typography,
  LinearProgress,
} from '@mui/material'
import EditIcon from '@mui/icons-material/Edit'
import DeleteIcon from '@mui/icons-material/Delete'
import KeyboardArrowDownIcon from '@mui/icons-material/KeyboardArrowDown'
import KeyboardArrowUpIcon from '@mui/icons-material/KeyboardArrowUp'
import useAxios, { configure } from 'axios-hooks'
import apiUrl from '../common/apiUrl'

export const List = (props) => {
  const { title, setValues, setOpenRecipePopup, setOpenTimingPopup, setOpenIngredientAndUtensilPopup } = props

  const axios = apiUrl()
  configure({ axios })

  const [{ data: dataIngredient, loading: loadingIngriedient, error: ingredientError }] = useAxios({
    url: `/Ingredient/ingredient/all`,
    method: 'GET',
  })
  const [{ data: dataUtensil, loading: loadingUtensil, error: utensilError }] = useAxios({
    url: `/Utensil/utensil/all`,
    method: 'GET',
  })
  const [{ data: dataRecipe, loading: loadingRecipe, error: recipeError }] = useAxios({
    url: `/Recipe/recipe/all`,
    method: 'GET',
  })
  const dummydataRecipe = [
    {
      id: 1,
      img: 'https://images.unsplash.com/photo-1517427294546-5aa121f68e8a?auto=format&fit=crop&q=80&w=1964&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D',
      name: 'Surprise Chocoladetaart',
      videoLink: 'https://www.youtube.com/watch?v=55Rn2ma2SvY',
      servings: 8,
      cookingTime: '00:45:00',
      ingredients: [
        {
          id: 1,
          name: 'chocolade',
          brand: 'boni',
          from: '00:01:20',
          till: '00:01:42',
          price: 1.2,
          img: 'https://images.unsplash.com/photo-1623660053975-cf75a8be0908?auto=format&fit=crop&q=80&w=1974&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D',
          brandImg:
            'https://www.colruytgroup.com/content/dam/colruytgroup/merken/consumentenmerken/boni/LP_reference-image_boni-new.png/_jcr_content/renditions/cq5dam.web.1280.1280.png',
        },
      ],
      utensils: [
        {
          id: 1,
          name: 'pan',
          brand: 'boni',
          from: '00:01:20',
          till: '00:01:42',
          img: 'https://images.unsplash.com/photo-1592156328697-079f6ee0cfa5?q=80&w=2080&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D',
          brandImg:
            'https://www.colruytgroup.com/content/dam/colruytgroup/merken/consumentenmerken/boni/LP_reference-image_boni-new.png/_jcr_content/renditions/cq5dam.web.1280.1280.png',
        },
      ],
    },
    {
      id: 2,
      img: 'https://images.unsplash.com/photo-1629115916087-7e8c114a24ed?auto=format&fit=crop&q=80&w=1964&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D',
      name: 'Lasagne Bolognese',
      videoLink: 'https://www.youtube.com/watch?v=55Rn2ma2SvY',
      servings: 4,
      cookingTime: '00:30:00',
      ingredients: [
        {
          id: 1,
          name: 'gehakt',
          brand: 'boni',
          price: 8.6,
          from: '00:01:20',
          till: '00:01:42',
          img: 'https://plus.unsplash.com/premium_photo-1670357599528-c604816e04f6?auto=format&fit=crop&q=80&w=1974&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D',
          brandImg:
            'https://www.colruytgroup.com/content/dam/colruytgroup/merken/consumentenmerken/boni/LP_reference-image_boni-new.png/_jcr_content/renditions/cq5dam.web.1280.1280.png',
        },
      ],
      utensils: [
        {
          id: 1,
          name: 'maatbeker',
          brand: 'boni',
          from: '00:01:20',
          till: '00:01:42',
          img: 'https://images.unsplash.com/photo-1586797166778-7cb76a618157?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D',
          brandImg:
            'https://www.colruytgroup.com/content/dam/colruytgroup/merken/consumentenmerken/boni/LP_reference-image_boni-new.png/_jcr_content/renditions/cq5dam.web.1280.1280.png',
        },
      ],
    },
    {
      id: 3,
      img: 'https://images.unsplash.com/photo-1610393742736-72b0185368dc?auto=format&fit=crop&q=80&w=1974&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D',
      name: 'Aardbei confituur',
      videoLink: 'https://www.youtube.com/watch?v=55Rn2ma2SvY',
      servings: 12,
      cookingTime: '01:00:00',
      ingredients: [
        {
          id: 1,
          name: 'aardbeiden',
          brand: 'boni',
          price: 3.4,
          from: '00:01:20',
          till: '00:01:42',
          img: 'https://images.unsplash.com/photo-1587393855524-087f83d95bc9?auto=format&fit=crop&q=80&w=1960&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D',
          brandImg:
            'https://www.colruytgroup.com/content/dam/colruytgroup/merken/consumentenmerken/boni/LP_reference-image_boni-new.png/_jcr_content/renditions/cq5dam.web.1280.1280.png',
        },
      ],
      utensils: [
        {
          id: 1,
          name: 'houten lepel',
          brand: 'boni',
          from: '00:01:20',
          till: '00:01:42',
          img: 'https://images.unsplash.com/photo-1579892876770-461a88bd87df?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D',
          brandImg:
            'https://www.colruytgroup.com/content/dam/colruytgroup/merken/consumentenmerken/boni/LP_reference-image_boni-new.png/_jcr_content/renditions/cq5dam.web.1280.1280.png',
        },
      ],
    },
  ]
  const dummydataIngredient = [
    {
      id: 1,
      name: 'chocolade',
      brand: 'boni',
      price: 1.2,
      img: 'https://images.unsplash.com/photo-1623660053975-cf75a8be0908?auto=format&fit=crop&q=80&w=1974&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D',
      brandImg:
        'https://www.colruytgroup.com/content/dam/colruytgroup/merken/consumentenmerken/boni/LP_reference-image_boni-new.png/_jcr_content/renditions/cq5dam.web.1280.1280.png',
    },
    {
      id: 2,
      name: 'gehakt',
      brand: 'boni',
      price: 8.6,
      img: 'https://plus.unsplash.com/premium_photo-1670357599528-c604816e04f6?auto=format&fit=crop&q=80&w=1974&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D',
      brandImg:
        'https://www.colruytgroup.com/content/dam/colruytgroup/merken/consumentenmerken/boni/LP_reference-image_boni-new.png/_jcr_content/renditions/cq5dam.web.1280.1280.png',
    },
    {
      id: 3,
      name: 'aardbeien',
      brand: 'boni',
      price: 3.4,
      img: 'https://images.unsplash.com/photo-1587393855524-087f83d95bc9?auto=format&fit=crop&q=80&w=1960&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D',
      brandImg:
        'https://www.colruytgroup.com/content/dam/colruytgroup/merken/consumentenmerken/boni/LP_reference-image_boni-new.png/_jcr_content/renditions/cq5dam.web.1280.1280.png',
    },
  ]
  const dummydataUtensil = [
    {
      id: 1,
      name: 'pan',
      brand: 'boni',
      img: 'https://images.unsplash.com/photo-1592156328697-079f6ee0cfa5?q=80&w=2080&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D',
      brandImg:
        'https://www.colruytgroup.com/content/dam/colruytgroup/merken/consumentenmerken/boni/LP_reference-image_boni-new.png/_jcr_content/renditions/cq5dam.web.1280.1280.png',
    },
    {
      id: 2,
      name: 'maatbeker',
      brand: 'boni',
      img: 'https://images.unsplash.com/photo-1586797166778-7cb76a618157?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D',
      brandImg:
        'https://www.colruytgroup.com/content/dam/colruytgroup/merken/consumentenmerken/boni/LP_reference-image_boni-new.png/_jcr_content/renditions/cq5dam.web.1280.1280.png',
    },
    {
      id: 3,
      name: 'houten lepel',
      brand: 'boni',
      from: '00:01:20',
      till: '00:01:42',
      img: 'https://images.unsplash.com/photo-1579892876770-461a88bd87df?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D',
      brandImg:
        'https://www.colruytgroup.com/content/dam/colruytgroup/merken/consumentenmerken/boni/LP_reference-image_boni-new.png/_jcr_content/renditions/cq5dam.web.1280.1280.png',
    },
  ]

  function Row(props) {
    const { row, setValues } = props
    const [open, setOpen] = useState(false)

    return (
      <React.Fragment>
        <TableRow sx={{ boxShadow: '0px 20px 25px -15px RGB(213 217 219)' }}>
          {title === 'recipe' ? (
            <>
              <TableCell sx={{ borderBottom: 0, borderRadius: '20px 0 0 20px' }}>
                <IconButton onClick={() => setOpen(!open)}>
                  {open ? <KeyboardArrowUpIcon /> : <KeyboardArrowDownIcon />}
                </IconButton>
              </TableCell>
              <TableCell sx={{ borderBottom: 0 }}>
                <Avatar src={row.img} />
              </TableCell>
            </>
          ) : null}

          <TableCell sx={{ borderBottom: 0, borderRadius: title === 'ingredient' ? '20px 0 0 20px' : 0 }}>
            {title === 'recipe' ? (
              row.name
            ) : (
              <Grid container sx={{ alignItems: 'center' }}>
                <Avatar src={row.img} sx={{ m: 1 }} />
                {row.name}
              </Grid>
            )}
          </TableCell>
          <TableCell sx={{ borderBottom: 0 }}>
            {title === 'recipe' ? (
              row.videoLink
            ) : (
              <Grid container sx={{ alignItems: 'center' }}>
                <Avatar src={row.brandImg} sx={{ m: 1 }} />
                {row.brand}
              </Grid>
            )}
          </TableCell>
          {title === 'ingredient' ? <TableCell sx={{ borderBottom: 0 }}>€ {row.price}</TableCell> : null}
          {title === 'recipe' ? (
            <>
              <TableCell sx={{ borderBottom: 0 }}>{row.servings}</TableCell>
              <TableCell sx={{ borderBottom: 0 }}>{row.cookingTime}</TableCell>
            </>
          ) : null}
          <TableCell align='right' sx={{ borderBottom: 0, borderRadius: '0 20px 20px 0' }}>
            <IconButton
              onClick={() => {
                setValues({ title: title, id: row.id })
                if (title === 'recipe') {
                  setOpenRecipePopup(true)
                }
                if (title === 'ingredient') {
                  setOpenIngredientAndUtensilPopup(true)
                }
                if (title === 'utensil') {
                  setOpenIngredientAndUtensilPopup(true)
                }
              }}
            >
              <EditIcon />
            </IconButton>
            <IconButton onClick={() => {}}>
              <DeleteIcon />
            </IconButton>
          </TableCell>
        </TableRow>
        {title === 'recipe' ? (
          <>
            <TableRow sx={{ boxShadow: '0px 20px 25px -15px RGB(213 217 219)' }}>
              <TableCell sx={{ pb: 0, pt: 0, borderBottom: 0, borderRadius: '20px' }} colSpan={8}>
                <Collapse in={open} timeout='auto' unmountOnExit>
                  <Box sx={{ margin: 1 }}>
                    <Grid container sx={{ width: '100%' }} justifyContent={'space-between'}>
                      <Typography variant='h6' gutterBottom component='div'>
                        Ingredients
                      </Typography>
                      <Button
                        onClick={() => {
                          setValues()
                          setOpenTimingPopup(true)
                        }}
                        sx={{ border: 1, borderRadius: 10, m: 1 }}
                      >
                        + add a ingredient
                      </Button>
                    </Grid>
                    <Table>
                      <TableHead>
                        <TableRow>
                          <TableCell>Name</TableCell>
                          <TableCell>Brand</TableCell>
                          <TableCell>Price</TableCell>
                          <TableCell>From</TableCell>
                          <TableCell>Till</TableCell>
                          <TableCell align='right'></TableCell>
                        </TableRow>
                      </TableHead>
                      <TableBody>
                        {row.ingredients.map((item) => (
                          <TableRow key={item.id}>
                            <TableCell>
                              <Grid container sx={{ alignItems: 'center' }}>
                                <Avatar src={item.img} sx={{ m: 1 }} />
                                {item.name}
                              </Grid>
                            </TableCell>
                            <TableCell>
                              <Grid container sx={{ alignItems: 'center' }}>
                                <Avatar src={item.brandImg} sx={{ m: 1 }} />
                                {item.brand}
                              </Grid>
                            </TableCell>
                            <TableCell>€ {item.price}</TableCell>
                            <TableCell>{item.from}</TableCell>
                            <TableCell>{item.till}</TableCell>
                            <TableCell align='right'>
                              <IconButton
                                onClick={() => {
                                  setValues({ title: 'ingredient', id: row.id })
                                  setOpenTimingPopup(true)
                                }}
                              >
                                <EditIcon />
                              </IconButton>
                              <IconButton onClick={() => {}}>
                                <DeleteIcon />
                              </IconButton>
                            </TableCell>
                          </TableRow>
                        ))}
                      </TableBody>
                    </Table>
                  </Box>
                </Collapse>
              </TableCell>
            </TableRow>
            <TableRow sx={{ boxShadow: '0px 20px 25px -15px RGB(213 217 219)' }}>
              <TableCell sx={{ pb: 0, pt: 0, borderBottom: 0, borderRadius: '20px' }} colSpan={8}>
                <Collapse in={open} timeout='auto' unmountOnExit>
                  <Box sx={{ margin: 1 }}>
                    <Grid container sx={{ width: '100%' }} justifyContent={'space-between'}>
                      <Typography variant='h6' gutterBottom component='div'>
                        Utensils
                      </Typography>
                      <Button
                        onClick={() => {
                          setValues({ title: 'utensil' })
                          setOpenTimingPopup(true)
                        }}
                        sx={{ border: 1, borderRadius: 10, m: 1 }}
                      >
                        + add a utensil
                      </Button>
                    </Grid>
                    <Table>
                      <TableHead>
                        <TableRow>
                          <TableCell>Name</TableCell>
                          <TableCell>Brand</TableCell>
                          <TableCell>From</TableCell>
                          <TableCell>Till</TableCell>
                          <TableCell align='right'></TableCell>
                        </TableRow>
                      </TableHead>
                      <TableBody>
                        {row.utensils.map((item) => (
                          <TableRow key={item.id}>
                            <TableCell>
                              <Grid container sx={{ alignItems: 'center' }}>
                                <Avatar src={item.img} sx={{ m: 1 }} />
                                {item.name}
                              </Grid>
                            </TableCell>
                            <TableCell>
                              <Grid container sx={{ alignItems: 'center' }}>
                                <Avatar src={item.brandImg} sx={{ m: 1 }} />
                                {item.brand}
                              </Grid>
                            </TableCell>
                            <TableCell>{item.from}</TableCell>
                            <TableCell>{item.till}</TableCell>
                            <TableCell align='right'>
                              <IconButton
                                onClick={() => {
                                  setValues({ title: 'ingredient',id: row.id })
                                  setOpenTimingPopup(true)
                                }}
                              >
                                <EditIcon />
                              </IconButton>
                              <IconButton onClick={() => {}}>
                                <DeleteIcon />
                              </IconButton>
                            </TableCell>
                          </TableRow>
                        ))}
                      </TableBody>
                    </Table>
                  </Box>
                </Collapse>
              </TableCell>
            </TableRow>
          </>
        ) : null}
      </React.Fragment>
    )
  }

  // if (loadingIngriedient || loadingUtensil || loadingRecipe) return <LinearProgress />
  // if (ingredientError || utensilError || recipeError) return <Typography>ERROR</Typography>

  return (
    <Grid>
      <TableContainer>
        <Table sx={{ borderCollapse: 'separate', borderSpacing: '0 10px', border: 'transparent' }}>
          <TableHead sx={{ backgroundColor: '#fff', boxShadow: '0px 20px 25px -15px RGB(213 217 219)' }}>
            <TableRow>
              {title === 'recipe' ? (
                <>
                  <TableCell sx={{ borderBottom: 0, borderRadius: '20px 0 0 20px' }}></TableCell>{' '}
                  <TableCell sx={{ borderBottom: 0 }}>img</TableCell>
                </>
              ) : null}
              <TableCell sx={{ borderBottom: 0, borderRadius: title === 'ingredient' ? '20px 0 0 20px' : 0 }}>
                name
              </TableCell>
              <TableCell sx={{ borderBottom: 0 }}>{title === 'recipe' ? 'videoLink' : 'brand'}</TableCell>
              {title === 'ingredient' ? <TableCell sx={{ borderBottom: 0 }}>price</TableCell> : null}
              {title === 'recipe' ? (
                <>
                  <TableCell sx={{ borderBottom: 0 }}>serving</TableCell>
                  <TableCell sx={{ borderBottom: 0 }}>cookingTime</TableCell>
                </>
              ) : null}
              <TableCell sx={{ borderBottom: 0, borderRadius: '0 20px 20px 0' }}></TableCell>
            </TableRow>
          </TableHead>
          <TableBody sx={{ backgroundColor: '#fff' }}>
            {title === 'recipe'
              ? dummydataRecipe?.map((row) => <Row key={row.id} row={row} setValues={setValues} />)
              : title === 'ingredient'
              ? dummydataIngredient?.map((row) => <Row key={row.id} row={row} setValues={setValues} />)
              : dummydataUtensil?.map((row) => <Row key={row.id} row={row} setValues={setValues} />)}
          </TableBody>
        </Table>
      </TableContainer>
    </Grid>
  )
}
