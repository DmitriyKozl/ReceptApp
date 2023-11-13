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
    url: `/Ingredient/all`,
    method: 'GET',
  })
  const [{ data: dataUtensil, loading: loadingUtensil, error: utensilError }] = useAxios({
    url: `/Utensil/all`,
    method: 'GET',
  })
  const [{ data: dataRecipe, loading: loadingRecipe, error: recipeError }] = useAxios({
    url: `/Recipe/all`,
    method: 'GET',
  })

  const Row = (props) => {
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

          <TableCell sx={{ borderBottom: 0, borderRadius: title !== 'recipe' ? '20px 0 0 20px' : 0 }}>
            {title === 'recipe' ? (
              row.name
            ) : (
              <Grid container sx={{ alignItems: 'center' }}>
                <Avatar src={row.img} sx={{ m: 1 }} />
                {row.name}
              </Grid>
            )}
          </TableCell>
          {title !== 'utensil' ? (
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
          ) : null}
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
                                setValues({ title: 'ingredient', id: item.id })
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
          {title === 'recipe' ? (
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
                                setValues({ title: 'ingredient', id: item.id })
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
      </React.Fragment>
    )
  }

  if (loadingIngriedient || loadingUtensil || loadingRecipe) return <LinearProgress />
  if (ingredientError || utensilError || recipeError) return <Typography>ERROR</Typography>

  return (
    <Grid>
      <TableContainer>
        <Table sx={{ borderCollapse: 'separate', borderSpacing: '0 10px', border: 'transparent' }}>
          <TableHead sx={{ backgroundColor: '#fff', boxShadow: '0px 20px 25px -15px RGB(213 217 219)' }}>
            <TableRow>
              {title === 'recipe' ? (
                <>
                  <TableCell sx={{ borderBottom: 0, borderRadius: '20px 0 0 20px' }}></TableCell>
                  <TableCell sx={{ borderBottom: 0 }}>img</TableCell>
                </>
              ) : null}
              <TableCell sx={{ borderBottom: 0, borderRadius: title !== 'recipe' ? '20px 0 0 20px' : 0 }}>
                name
              </TableCell>
              {title !== 'utensil' ? (
                <TableCell sx={{ borderBottom: 0 }}>{title === 'recipe' ? 'videoLink' : 'brand'}</TableCell>
              ) : null}
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
              ? dataRecipe?.map((row) => <Row key={row.id} row={row} setValues={setValues} />)
              : title === 'ingredient'
              ? dataIngredient?.map((row) => <Row key={row.id} row={row} setValues={setValues} />)
              : dataUtensil?.map((row) => <Row key={row.id} row={row} setValues={setValues} />)}
          </TableBody>
        </Table>
      </TableContainer>
    </Grid>
  )
}
