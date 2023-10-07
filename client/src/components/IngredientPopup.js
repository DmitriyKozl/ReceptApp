import React, { useState } from 'react'
import { Box, DialogContent, DialogTitle, TextField } from '@mui/material'

export const IngredientPopup = (props) => {
  const { values } = props

  const [name, setName] = useState(values?.name)
  const [brand, setBrand] = useState(values?.brand)
  const [from, setFrom] = useState(values?.from)
  const [till, setTill] = useState(values?.till)

  return (
    <React.Fragment>
      <DialogTitle>Ingredient</DialogTitle>
      <DialogContent dividers='true'>
        <Box display={'grid'}>
          <TextField
            label='name'
            value={name}
            onChange={(e) => setName(e.target.value)}
            variant='filled'
            margin='normal'
            sx={{ width: 500 }}
          />
          <TextField
            label='brand'
            value={brand}
            onChange={(e) => setBrand(e.target.value)}
            variant='filled'
            margin='normal'
            sx={{ width: 500 }}
          />
          <TextField
            label='from'
            value={from}
            onChange={(e) => setFrom(e.target.value)}
            variant='filled'
            margin='normal'
            sx={{ width: 500 }}
          />
          <TextField
            label='till'
            value={till}
            onChange={(e) => setTill(e.target.value)}
            variant='filled'
            margin='normal'
            sx={{ width: 500 }}
          />
        </Box>
      </DialogContent>
    </React.Fragment>
  )
}
