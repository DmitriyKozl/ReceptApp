import React, { useEffect, useState } from 'react'
import moment from 'moment'
import {
  Button,
  Dialog,
  DialogActions,
  DialogContent,
  DialogTitle,
  FormControl,
  IconButton,
  InputLabel,
  OutlinedInput,
  Stack,
  Typography,
} from '@mui/material'
import { TimeField } from '@mui/x-date-pickers/TimeField'
import { VisuallyHiddenInput } from './VisuallyHiddenInput'
import CloudUploadIcon from '@mui/icons-material/CloudUpload'
import useAxios, { configure } from 'axios-hooks'
import apiUrl from '../common/apiUrl'
import CloseIcon from '@mui/icons-material/Close'

// Component for the Popup used for adding/editing Recipes
export const RecipePopup = (props) => {
  const { values, openRecipePopup, handleClose } = props

  // Axios configuration using axios-hooks
  const axios = apiUrl()
  configure({ axios })

  // Use axios-hooks for fetching existing Recipe data and making POST requests
  const [{ data, loading, error }] = useAxios({
    url: `/Recipe/{recipeId}?recipeId=${values?.id}`,
    method: 'GET',
  })

  const [{ data: postData }, executePost] = useAxios(
    {
      url: `/Recipe/recipe`,
      method: 'POST',
    },
    { manual: true }
  )

  // State variables to manage form fields
  const [name, setName] = useState()
  const [videoLink, setVideoLink] = useState()
  const [servings, setServings] = useState()
  const [cookingtime, setCookingtime] = useState()

  // Set initial form values based on existing Recipe data
  useEffect(() => {
    setName(data?.name)
    setVideoLink(data?.videoLink)
    setServings(data?.servings)
    setCookingtime(data?.cookingTime ? data.cookingTime : '00:00:00')
  }, [data])

  // Loading and error handling
  if (loading) return <Typography>LOADING</Typography>
  if (values.id && error) return <Typography>ERROR</Typography>

  // JSX for rendering the Popup
  return (
    <Dialog open={openRecipePopup} onClose={handleClose} PaperProps={{ sx: { borderRadius: '20px' } }}>
      <IconButton sx={{ position: 'absolute', alignSelf: 'end' }} onClick={handleClose}>
        <CloseIcon fontSize='large' />
      </IconButton>
      <DialogTitle variant='h4' m={1}>
        Recipe
      </DialogTitle>
      <DialogContent>
        <Stack justifyContent='space-evenly' alignItems='stretch' spacing={3} width={550}>
          {/* Button for uploading recipe image */}
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
          {/* Form fields for name, videoLink, servings, and cooking time */}
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
            <InputLabel>videoLink</InputLabel>
            <OutlinedInput
              label='videoLink'
              value={videoLink}
              onChange={(e) => setVideoLink(e.target.value)}
              margin='normal'
              sx={{ borderRadius: '20px' }}
            />
          </FormControl>
          <FormControl>
            <InputLabel>servings</InputLabel>
            <OutlinedInput
              label='servings'
              value={servings}
              type='number'
              onChange={(e) => setServings(e.target.value)}
              margin='normal'
              sx={{ borderRadius: '20px' }}
            />
          </FormControl>
          {/* TimeField for cooking time */}
          <TimeField
            label='cookingtime'
            value={moment(cookingtime, 'HH:mm:ss')}
            onChange={(e) => setCookingtime(e.format('HH:mm:ss'))}
            format='HH:mm:ss'
            sx={{
              '& .MuiOutlinedInput-root': {
                '& fieldset': {
                  borderRadius: '20px',
                },
                '&:hover fieldset': {
                  borderRadius: '20px',
                },
                '&.Mui-focused fieldset': {
                  borderRadius: '20px',
                },
              },
            }}
          />
        </Stack>
      </DialogContent>
      {/* Save button */}
      <DialogActions sx={{ justifyContent: 'center' }}>
        <Button
          onClick={() => {
            // Execute POST request to update/create Recipe
            executePost({
              data: { name: name, img: '', videoLink: videoLink, servings: servings, cookingTime: cookingtime },
            })
            console.log(postData)
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
