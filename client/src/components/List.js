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
} from '@mui/material'
import EditIcon from '@mui/icons-material/Edit'
import DeleteIcon from '@mui/icons-material/Delete'
import KeyboardArrowDownIcon from '@mui/icons-material/KeyboardArrowDown'
import KeyboardArrowUpIcon from '@mui/icons-material/KeyboardArrowUp'

export const List = (props) => {
  const { title, setValues, setOpenRecipePopup, setOpenTimingPopup, setOpenIngredientPopup } = props
  const dummydataRecipe = [
    {
      id: 1,
      img: 'https://images.unsplash.com/photo-1517427294546-5aa121f68e8a?auto=format&fit=crop&q=80&w=1964&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D',
      name: 'Surprise Chocoladetaart',
      url: 'https://www.youtube.com/watch?v=55Rn2ma2SvY',
      ingredients: [
        {
          id: 1,
          name: 'chocolade',
          brand: 'boni',
          from: '1:20',
          till: '1:42',
          img: 'https://images.unsplash.com/photo-1623660053975-cf75a8be0908?auto=format&fit=crop&q=80&w=1974&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D',
          brandImg:
            'https://www.colruytgroup.com/content/dam/colruytgroup/merken/consumentenmerken/boni/LP_reference-image_boni-new.png/_jcr_content/renditions/cq5dam.web.1280.1280.png',
        },
      ],
    },
    {
      id: 2,
      img: 'https://images.unsplash.com/photo-1629115916087-7e8c114a24ed?auto=format&fit=crop&q=80&w=1964&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D',
      name: 'Lasagne Bolognese',
      url: 'https://www.youtube.com/watch?v=55Rn2ma2SvY',
      ingredients: [
        {
          id: 1,
          name: 'gehakt',
          brand: 'boni',
          from: '1:20',
          till: '1:42',
          img: 'https://plus.unsplash.com/premium_photo-1670357599528-c604816e04f6?auto=format&fit=crop&q=80&w=1974&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D',
          brandImg:
            'https://www.colruytgroup.com/content/dam/colruytgroup/merken/consumentenmerken/boni/LP_reference-image_boni-new.png/_jcr_content/renditions/cq5dam.web.1280.1280.png',
        },
      ],
    },
    {
      id: 3,
      img: 'https://images.unsplash.com/photo-1610393742736-72b0185368dc?auto=format&fit=crop&q=80&w=1974&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D',
      name: 'Aardbei confituur maken',
      url: 'https://www.youtube.com/watch?v=55Rn2ma2SvY',
      ingredients: [
        {
          id: 1,
          name: 'aardbeiden',
          brand: 'boni',
          from: '1:20',
          till: '1:42',
          img: 'https://images.unsplash.com/photo-1587393855524-087f83d95bc9?auto=format&fit=crop&q=80&w=1960&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D',
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
      img: 'https://images.unsplash.com/photo-1623660053975-cf75a8be0908?auto=format&fit=crop&q=80&w=1974&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D',
      brandImg:
        'https://www.colruytgroup.com/content/dam/colruytgroup/merken/consumentenmerken/boni/LP_reference-image_boni-new.png/_jcr_content/renditions/cq5dam.web.1280.1280.png',
    },
    {
      id: 2,
      name: 'gehakt',
      brand: 'boni',
      img: 'https://plus.unsplash.com/premium_photo-1670357599528-c604816e04f6?auto=format&fit=crop&q=80&w=1974&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D',
      brandImg:
        'https://www.colruytgroup.com/content/dam/colruytgroup/merken/consumentenmerken/boni/LP_reference-image_boni-new.png/_jcr_content/renditions/cq5dam.web.1280.1280.png',
    },
    {
      id: 3,
      name: 'aardbeiden',
      brand: 'boni',
      img: 'https://images.unsplash.com/photo-1587393855524-087f83d95bc9?auto=format&fit=crop&q=80&w=1960&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D',
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
              row.url
            ) : (
              <Grid container sx={{ alignItems: 'center' }}>
                <Avatar src={row.brandImg} sx={{ m: 1 }} />
                {row.brand}
              </Grid>
            )}
          </TableCell>
          <TableCell align='right' sx={{ borderBottom: 0, borderRadius: '0 20px 20px 0' }}>
            <IconButton
              onClick={() => {
                if (title === 'recipe') {
                  setValues({ name: row.name, url: row.url })
                  setOpenRecipePopup(true)
                }
                if (title === 'ingredient') {
                  setValues({ name: row.name, brand: row.brand })
                  setOpenIngredientPopup(true)
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
            <TableCell sx={{ pb: 0, pt: 0, borderBottom: 0, borderRadius: '20px' }} colSpan={6}>
              <Collapse in={open} timeout='auto' unmountOnExit>
                <Box sx={{ margin: 1 }}>
                  <Grid container sx={{ width: '100%' }} justifyContent={'space-between'}>
                    <Typography variant='h6' gutterBottom component='div'>
                      Ingredients
                    </Typography>
                    <Button
                      onClick={() => {
                        setValues({ new: true })
                        setOpenTimingPopup(true)
                      }}
                      sx={{ border: 1, borderRadius: 10, m: 1 }}
                    >
                      + add a timing
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
                          <TableCell>{item.from}</TableCell>
                          <TableCell>{item.till}</TableCell>
                          <TableCell align='right'>
                            <IconButton
                              onClick={() => {
                                setValues({ id: item.id, from: item.from, till: item.till })
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
          ) : (
            <></>
          )}
        </TableRow>
      </React.Fragment>
    )
  }

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
              <TableCell sx={{ borderBottom: 0 }}>{title === 'ingredient' ? 'brand' : 'url'}</TableCell>
              <TableCell sx={{ borderBottom: 0, borderRadius: '0 20px 20px 0' }}></TableCell>
            </TableRow>
          </TableHead>
          <TableBody sx={{ backgroundColor: '#fff' }}>
            {title === 'recipe'
              ? dummydataRecipe.map((row) => <Row key={row.id} row={row} setValues={setValues} />)
              : dummydataIngredient.map((row) => <Row key={row.id} row={row} setValues={setValues} />)}
          </TableBody>
        </Table>
      </TableContainer>
    </Grid>
  )
}
