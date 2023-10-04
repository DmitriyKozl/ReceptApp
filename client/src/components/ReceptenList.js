import React, { useState } from 'react'
import {
  Box,
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

export const ReceptenList = (tab) => {
  const dummydata = [
    {
      id: 1,
      name: 'Surprise Chocoladetaart',
      url: 'https://www.youtube.com/watch?v=55Rn2ma2SvY',
      ingredients: [{ id: 1, name: 'chocolade', brand: 'boni', from: '1:20', till: '1:42' }],
    },
    {
      id: 2,
      name: 'Lasagne Bolognese',
      url: 'https://www.youtube.com/watch?v=55Rn2ma2SvY',
      ingredients: [{ id: 1, name: 'gehakt', brand: 'boni', from: '1:20', till: '1:42' }],
    },
    {
      id: 3,
      name: 'Aardbei confituur maken',
      url: 'https://www.youtube.com/watch?v=55Rn2ma2SvY',
      ingredients: [{ id: 1, name: 'aardbeiden', brand: 'boni', from: '1:20', till: '1:42' }],
    },
  ]

  function Row(props) {
    const { row } = props
    const [open, setOpen] = useState(false)

    return (
      <React.Fragment>
        <TableRow>
          {tab.title === 'timing' ? (
            <TableCell>
              <IconButton onClick={() => setOpen(!open)}>
                {open ? <KeyboardArrowUpIcon /> : <KeyboardArrowDownIcon />}
              </IconButton>
            </TableCell>
          ) : null}
          <TableCell></TableCell>
          <TableCell>{row.name}</TableCell>
          <TableCell>{row.url}</TableCell>
          <TableCell align='right'>
            {tab.title === 'recepten' ? (
              <IconButton onClick={() => {}}>
                <EditIcon />
              </IconButton>
            ) : null}
            <IconButton onClick={() => {}}>
              <DeleteIcon />
            </IconButton>
          </TableCell>
        </TableRow>
        <TableRow>
          <TableCell sx={{ pb: 0, pt: 0 }} colSpan={6}>
            <Collapse in={open} timeout='auto' unmountOnExit>
              <Box sx={{ margin: 1 }}>
                <Typography variant='h6' gutterBottom component='div'>
                  Ingredients
                </Typography>
                <Table>
                  <TableHead>
                    <TableRow>
                      <TableCell>Name</TableCell>
                      <TableCell>Brand</TableCell>
                      <TableCell>From</TableCell>
                      <TableCell>Till</TableCell>
                    </TableRow>
                  </TableHead>
                  <TableBody>
                    {row.ingredients.map((item) => (
                      <TableRow key={item.id}>
                        <TableCell>{item.name}</TableCell>
                        <TableCell>{item.brand}</TableCell>
                        <TableCell>{item.from}</TableCell>
                        <TableCell>{item.till}</TableCell>
                        <TableCell align='right'>
                          <IconButton onClick={() => {}}>
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
    )
  }

  return (
    <Grid>
      <TableContainer>
        <Table>
          <TableHead>
            <TableRow>
              {tab.title === 'timing' ? <TableCell></TableCell> : null}
              <TableCell>img</TableCell>
              <TableCell>name</TableCell>
              <TableCell>url</TableCell>
              <TableCell></TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {dummydata.map((row) => (
              <Row key={row.id} row={row} />
            ))}
          </TableBody>
        </Table>
      </TableContainer>
    </Grid>
  )
}
