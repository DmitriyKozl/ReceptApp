import React, { useState } from 'react'
import {
  Button,
  DialogContent,
  DialogTitle,
  FormControl,
  InputAdornment,
  InputLabel,
  OutlinedInput,
  Stack,
} from '@mui/material'
import { VisuallyHiddenInput } from './VisuallyHiddenInput'
import CloudUploadIcon from '@mui/icons-material/CloudUpload'
import useAxios, { configure } from 'axios-hooks'
import apiUrl from '../common/apiUrl'

export const IngredientAndUntensilPopup = (props) => {
  const { values } = props

  const axios = apiUrl()
  configure({ axios })

  const [{ data: ingredient }] = useAxios({
    url: `/Ingredient/ingredient/${values.id}`,
    method: 'GET',
  })

  const [{ data: utensil }] = useAxios({
    url: `/Utensil/utensil/${values.id}`,
    method: 'GET',
  })

  const [name, setName] = useState(values?.title === 'ingredient' ? ingredient.name : utensil.name)
  const [brand, setBrand] = useState(values?.title === 'ingredient' ? ingredient.brand : utensil.brand)
  const [price, setPrice] = useState(values?.title === 'ingredient' ? ingredient.brand : '')

  return (
    <React.Fragment>
      <DialogTitle variant='h4' m={1}>
        {values.title}
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
            Upload Product Image
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
            Upload Brand Image
            <VisuallyHiddenInput />
          </Button>
          <FormControl>
            <InputLabel>brand</InputLabel>
            <OutlinedInput
              label='brand'
              value={brand}
              onChange={(e) => setBrand(e.target.value)}
              margin='normal'
              sx={{ borderRadius: '20px' }}
            />
          </FormControl>
          {values.title === 'ingredient' ? (
            <FormControl>
              <InputLabel>price</InputLabel>
              <OutlinedInput
                label='price'
                value={price}
                onChange={(e) => setPrice(e.target.value)}
                margin='normal'
                type='number'
                startAdornment={<InputAdornment position='start'>€</InputAdornment>}
                sx={{ borderRadius: '20px' }}
              />
            </FormControl>
          ) : null}
        </Stack>
      </DialogContent>
    </React.Fragment>
  )
}
