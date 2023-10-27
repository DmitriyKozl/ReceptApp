import React, { useState } from 'react'
import { DialogContent, DialogTitle, FormControl, InputLabel, OutlinedInput, Stack } from '@mui/material'

export const IngredientPopup = (props) => {
  const { values } = props

  const [name, setName] = useState(values?.name)
  const [brand, setBrand] = useState(values?.brand)

  return (
    <React.Fragment>
      <DialogTitle variant='h4' m={1}>
        Ingredient
      </DialogTitle>
      <DialogContent>
        <Stack justifyContent='space-evenly' alignItems='stretch' spacing={3} width={550}>
          <FormControl>
            {name ? '' : <InputLabel shrink={false}>name</InputLabel>}
            <OutlinedInput
              value={name}
              onChange={(e) => setName(e.target.value)}
              margin='normal'
              sx={{ borderRadius: '20px' }}
            />
          </FormControl>
          <FormControl>
            {brand ? '' : <InputLabel shrink={false}>brand</InputLabel>}
            <OutlinedInput
              value={brand}
              onChange={(e) => setBrand(e.target.value)}
              margin='normal'
              sx={{ borderRadius: '20px' }}
            />
          </FormControl>
        </Stack>
      </DialogContent>
    </React.Fragment>
  )
}
