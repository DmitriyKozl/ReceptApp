import React, { useState } from 'react'
import { DialogContent, DialogTitle, FormControl, InputLabel, OutlinedInput, Stack } from '@mui/material'

export const RecipePopup = (props) => {
  const { values } = props

  const [name, setName] = useState(values?.name)
  const [url, setUrl] = useState(values?.url)

  return (
    <React.Fragment>
      <DialogTitle variant='h4' m={1}>
        Recipe
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
            {url ? '' : <InputLabel shrink={false}>url</InputLabel>}
            <OutlinedInput
              value={url}
              onChange={(e) => setUrl(e.target.value)}
              margin='normal'
              sx={{ borderRadius: '20px' }}
            />
          </FormControl>
        </Stack>
      </DialogContent>
    </React.Fragment>
  )
}
