import React, { useState } from 'react'
import { Button, DialogContent, DialogTitle, FormControl, InputLabel, OutlinedInput, Stack } from '@mui/material'
import { VisuallyHiddenInput } from './VisuallyHiddenInput'
import CloudUploadIcon from '@mui/icons-material/CloudUpload'

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
          <Button
            component='label'
            startIcon={<CloudUploadIcon />}
            sx={{
              p: '15px 50px',
              borderRadius: '20px',
              color: '#fff',
              backgroundColor: 'primary.main',
              ':hover': { backgroundColor: 'primary.main' },
            }}
          >
            Upload Image
            <VisuallyHiddenInput />
          </Button>
          <FormControl>
            <InputLabel>name</InputLabel>
            <OutlinedInput
              label='name'
              value={name}
              onChange={(e) => setName(e.target.value)}
              margin='normal'
              sx={{ borderRadius: '20px' }}
            />
          </FormControl>
          <FormControl>
            <InputLabel>url</InputLabel>
            <OutlinedInput
              label='url'
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
