import React, { useState } from 'react'
import { Box, DialogContent, DialogTitle, TextField } from '@mui/material'

export const RecipeAndIngredientPopup = (props) => {
  const { title, values } = props

  const [name, setName] = useState(values?.name)
  const [url, setUrl] = useState(values?.url)
  const [brand, setBrand] = useState(values?.brand)

  return (
    <React.Fragment>
      <DialogTitle>{title === 'recipe' ? title : 'ingredient'}</DialogTitle>
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
            label={title === 'recipe' ? 'url' : 'brand'}
            value={title === 'recipe' ? url : brand}
            onChange={(e) => (title === 'recipe' ? setUrl(e.target.value) : setBrand(e.target.value))}
            variant='filled'
            margin='normal'
            sx={{ width: 500 }}
          />
        </Box>
      </DialogContent>
    </React.Fragment>
  )
}
