import React, { useState } from 'react'
import { Box, DialogContent, DialogTitle, TextField } from '@mui/material'

export const RecipePopup = (props) => {
  const { values } = props

  const [name, setName] = useState(values?.name)
  const [url, setUrl] = useState(values?.url)

  return (
    <React.Fragment>
      <DialogTitle>Recipe</DialogTitle>
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
            label='url'
            value={url}
            onChange={(e) => setUrl(e.target.value)}
            variant='filled'
            margin='normal'
            sx={{ width: 500 }}
          />
        </Box>
      </DialogContent>
    </React.Fragment>
  )
}
