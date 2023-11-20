import React, { useEffect, useState } from 'react'
import {
  Button,
  Dialog,
  DialogActions,
  DialogContent,
  DialogTitle,
  FormControl,
  IconButton,
  InputAdornment,
  InputLabel,
  OutlinedInput,
  Stack,
  Typography,
} from '@mui/material'
import { VisuallyHiddenInput } from './VisuallyHiddenInput'
import CloudUploadIcon from '@mui/icons-material/CloudUpload'
import useAxios, { configure } from 'axios-hooks'
import apiUrl from '../common/apiUrl'
import CloseIcon from '@mui/icons-material/Close'

// Component for the Popup used for adding/editing Ingredients and Utensils
export const IngredientAndUntensilPopup = (props) => {
  const { values, openIngredientAndUtensilPopup, handleClose } = props

  // Axios configuration using axios-hooks
  const axios = apiUrl()
  configure({ axios })

  // Fetch data for the existing Ingredient or Utensil based on 'values.id'
  const [{ data: ingredient, loading: ingredientLoading, error: ingredientError }] = useAxios({
    url: `/Ingredient/${values.id}`,
    method: 'GET',
  })

  const [{ data: utensil, loading: utensilLoading, error: utensilError }] = useAxios({
    url: `/Utensil/${values.id}`,
    method: 'GET',
  })

  // Use axios-hooks for POST requests to update/create Ingredient or Utensil
  const [{ data: postUtensilData }, executeUtensilPost] = useAxios(
    {
      url: `/Utensil`,
      method: 'POST',
    },
    { manual: true }
  )

  const [{ data: postIngredientData }, executeIngredientPost] = useAxios(
    {
      url: `/Ingredient`,
      method: 'POST',
    },
    { manual: true }
  )

  // State variables to manage form fields
  const [name, setName] = useState()
  const [brand, setBrand] = useState()
  const [price, setPrice] = useState()

  // Set initial form values based on existing Ingredient or Utensil data
  useEffect(() => {
    setName(values.title === 'ingredient' ? ingredient?.name : utensil?.name)
    setBrand(values.title === 'ingredient' ? ingredient?.brand : utensil?.brand)
    setPrice(values.title === 'ingredient' ? ingredient?.price : '')
  }, [values.title, ingredient, utensil])

  // Loading and error handling
  if (ingredientLoading || utensilLoading) return <Typography>LOADING</Typography>
  if (values.id) if (ingredientError || utensilError) return <Typography>ERROR</Typography>

  // JSX for rendering the Popup
  return (
    <Dialog open={openIngredientAndUtensilPopup} onClose={handleClose} PaperProps={{ sx: { borderRadius: '20px' } }}>
      <IconButton sx={{ position: 'absolute', alignSelf: 'end' }} onClick={handleClose}>
        <CloseIcon fontSize='large' />
      </IconButton>
      <DialogTitle variant='h4' m={1}>
        {values.title}
      </DialogTitle>
      <DialogContent>
        <Stack justifyContent='space-evenly' alignItems='stretch' spacing={3} width={550}>
          {/* Button for uploading product image */}
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
          {/* Form fields for name, brand, and price (for Ingredients) */}
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
          {/* Additional fields for Ingredients */}
          {values.title === 'ingredient' ? (
            <>
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
            </>
          ) : null}
        </Stack>
      </DialogContent>
      {/* Save button */}
      <DialogActions sx={{ justifyContent: 'center' }}>
        <Button
          onClick={() => {
            // Execute the appropriate POST request based on 'values.title'
            if (values.title === 'ingredient') {
              executeIngredientPost({
                data: { name: name, img: '', brand: brand, price: parseInt(price) },
              })
              console.log(postIngredientData)
            }
            if (values.title === 'utensil') {
              executeUtensilPost({
                data: { name: name, img: '' },
              })
              console.log(postUtensilData)
            }
            handleClose()
          }}
          sx={{
            p: '10px 50px',
            borderRadius: '20px',
            color: '#fff',
            backgroundColor: 'primary.main',
            ':hover': { backgroundColor: 'primary.main' },
          }}
        >
          save
        </Button>
      </DialogActions>
    </Dialog>
  )
}
