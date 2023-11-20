import React, { useState } from 'react'
import {
  Avatar,
  Box,
  Button,
  Collapse,
  Grid,
  IconButton,
  Table,
  TableCell,
  TableContainer,
  TableHead,
  TableRow,
  Typography,
  LinearProgress,
  TableBody,
} from '@mui/material'
import EditIcon from '@mui/icons-material/Edit'
import DeleteIcon from '@mui/icons-material/Delete'
import KeyboardArrowDownIcon from '@mui/icons-material/KeyboardArrowDown'
import KeyboardArrowUpIcon from '@mui/icons-material/KeyboardArrowUp'
import useAxios, { configure } from 'axios-hooks'
import apiUrl from '../common/apiUrl'
import TableHeader from './TableHeader'

// The List component responsible for rendering a dynamic table based on the provided 'title'
export const List = (props) => {
  // Destructure props to get required values
  const { title, setValues, setOpenRecipePopup, setOpenTimingPopup, setOpenIngredientAndUtensilPopup } = props

  // Axios configuration using axios-hooks
  const axios = apiUrl()
  configure({ axios })

  // Fetch data using axios-hooks for Ingredients, Utensils, and Recipes
  const [{ data: dataIngredient, loading: loadingIngredient, error: ingredientError }] = useAxios({
    url: `/Ingredient/|| ''`,
    method: 'GET',
  })
  const [{ data: dataUtensil, loading: loadingUtensil, error: utensilError }] = useAxios({
    url: `/Utensil`,
    method: 'GET',
  })
  const [{ data: dataRecipe, loading: loadingRecipe, error: recipeError }] = useAxios({
    url: '/Recipe',
    method: 'GET',
  })

  // The TableContent component responsible for rendering the actual table body based on the 'title'
  const TableContent = (props) => {
    const { title, setValues } = props

    // State to manage the open/close state of collapse in the table
    const [open, setOpen] = useState(false)

    // Switch case to handle different 'title' scenarios
    switch (title) {
      case 'recipe':
        return (
          <TableBody sx={{ backgroundColor: '#fff' }}>
            {dataRecipe?.map((row) => (
              <React.Fragment key={`${title}-${row.id}`}>
                <TableRow sx={{ boxShadow: '0px 20px 25px -15px RGB(213 217 219)' }}>
                  <TableCell sx={{ borderBottom: 0, borderRadius: '20px 0 0 20px' }}>
                    <IconButton onClick={() => setOpen(!open)}>
                      {open ? <KeyboardArrowUpIcon /> : <KeyboardArrowDownIcon />}
                    </IconButton>
                  </TableCell>
                  <TableCell sx={{ borderBottom: 0 }}>
                    <Avatar src={row.img} />
                  </TableCell>
                  <TableCell sx={{ borderBottom: 0 }}>{row.name}</TableCell>
                  <TableCell sx={{ borderBottom: 0 }}>{row.videoLink}</TableCell>
                  <TableCell sx={{ borderBottom: 0 }}>{row.servings}</TableCell>
                  <TableCell sx={{ borderBottom: 0 }}>{row.cookingTime}</TableCell>
                  <TableCell align='right' sx={{ borderBottom: 0, borderRadius: '0 20px 20px 0' }}>
                    <IconButton
                      onClick={() => {
                        setValues({ title: title, id: row.id })
                        setOpenRecipePopup(true)
                      }}
                    >
                      <EditIcon />
                    </IconButton>
                    <IconButton onClick={() => {}}>
                      <DeleteIcon />
                    </IconButton>
                  </TableCell>
                </TableRow>
                <TableRow sx={{ boxShadow: '0px 20px 25px -15px RGB(213 217 219)' }}>
                  {title === 'recipe' ? (
                    <TableCell sx={{ pb: 0, pt: 0, borderBottom: 0, borderRadius: '20px' }} colSpan={8}>
                      <Collapse in={open} timeout='auto' unmountOnExit>
                        <Box sx={{ margin: 1 }}>
                          <Grid container sx={{ width: '100%' }} justifyContent={'space-between'}>
                            <Typography variant='h6' gutterBottom component='div'>
                              Ingredients
                            </Typography>
                            <Button
                              onClick={() => {
                                setValues({ title: 'ingredient', recipeId: row.id })
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
                              {row?.ingredients?.map((item) => (
                                <TableRow key={`ingredient-${item.id}`}>
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
                                        setValues({
                                          title: 'ingredient',
                                          recipeId: row.id,
                                          id: item.id,
                                          brand: item.brand,
                                          from: item.from,
                                          till: item.till,
                                        })
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
                  ) : null}
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
                              setValues({ title: 'utensil', recipeId: row.id })
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
                              <TableCell>From</TableCell>
                              <TableCell>Till</TableCell>
                              <TableCell align='right'></TableCell>
                            </TableRow>
                          </TableHead>
                          <TableBody>
                            {row?.utensils?.map((item) => (
                              <TableRow key={`utensil-${item.id}`}>
                                <TableCell>
                                  <Grid container sx={{ alignItems: 'center' }}>
                                    <Avatar src={item.img} sx={{ m: 1 }} />
                                    {item.name}
                                  </Grid>
                                </TableCell>
                                <TableCell>{item.from}</TableCell>
                                <TableCell>{item.till}</TableCell>
                                <TableCell align='right'>
                                  <IconButton
                                    onClick={() => {
                                      setValues({
                                        title: 'utensil',
                                        recipeId: row.id,
                                        id: item.id,
                                        from: item.from,
                                        till: item.till,
                                      })
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
              </React.Fragment>
            ))}
          </TableBody>
        )
      case 'ingredient':
        return (
          <TableBody sx={{ backgroundColor: '#fff' }}>
            {dataIngredient?.map((row) => (
              <TableRow key={`${title}-${row.id}`} sx={{ boxShadow: '0px 20px 25px -15px RGB(213 217 219)' }}>
                <TableCell sx={{ borderBottom: 0, borderRadius: '20px 0 0 20px' }}>
                  <Grid container sx={{ alignItems: 'center' }}>
                    <Avatar src={row.img} sx={{ m: 1 }} />
                    {row.name}
                  </Grid>
                </TableCell>
                <TableCell sx={{ borderBottom: 0 }}>
                  <Grid container sx={{ alignItems: 'center' }}>
                    <Avatar src={row.brandImg} sx={{ m: 1 }} />
                    {row.brand}
                  </Grid>
                </TableCell>
                <TableCell sx={{ borderBottom: 0 }}>€ {row.price}</TableCell>
                <TableCell align='right' sx={{ borderBottom: 0, borderRadius: '0 20px 20px 0' }}>
                  <IconButton
                    onClick={() => {
                      setValues({ title: title, id: row.id })
                      setOpenIngredientAndUtensilPopup(true)
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
        )
      case 'utensil':
        return (
          <TableBody sx={{ backgroundColor: '#fff' }}>
            {dataUtensil?.map((row) => (
              <TableRow key={`${title}-${row.id}`} sx={{ boxShadow: '0px 20px 25px -15px RGB(213 217 219)' }}>
                <TableCell sx={{ borderBottom: 0, borderRadius: '20px 0 0 20px' }}>
                  <Grid container sx={{ alignItems: 'center' }}>
                    <Avatar src={row.img} sx={{ m: 1 }} />
                    {row.name}
                  </Grid>
                </TableCell>
                <TableCell align='right' sx={{ borderBottom: 0, borderRadius: '0 20px 20px 0' }}>
                  <IconButton
                    onClick={() => {
                      setValues({ title: title, id: row.id })
                      setOpenIngredientAndUtensilPopup(true)
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
        )
      default:
        return <TableBody sx={{ backgroundColor: '#fff' }}></TableBody>
    }
  }

  // Loading and error handling
  if (loadingIngredient || loadingUtensil || loadingRecipe) return <LinearProgress />
  if (ingredientError || utensilError || recipeError) return <Typography>ERROR</Typography>

  // JSX for rendering the List component
  return (
    <Grid>
      <TableContainer>
        <Table sx={{ borderCollapse: 'separate', borderSpacing: '0 10px', border: 'transparent' }}>
          {/* Table header based on the 'title' */}
          <TableHeader title={title} />
          {/* Table content based on the 'title' */}
          <TableContent title={title} setValues={setValues} />
        </Table>
      </TableContainer>
    </Grid>
  )
}
