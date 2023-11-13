import React, { useEffect, useState } from 'react'
import moment from 'moment'
import {
  Button,
  DialogContent,
  DialogTitle,
  FormControl,
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

export const RecipePopup = (props) => {
  const { values } = props

  const axios = apiUrl()
  configure({ axios })

  const [{ data, loading, error }] = useAxios({
    url: `/Recipe/{recipeId}?recipeId=${values?.id}`,
    method: 'GET',
  })

  const [name, setName] = useState()
  const [videoLink, setVideoLink] = useState()
  const [servings, setServings] = useState()
  const [cookingtime, setCookingtime] = useState()

  useEffect(() => {
    setName(data?.name)
    setVideoLink(data?.videoLink)
    setServings(data?.servings)
    setCookingtime(data?.cookingTime ? data.cookingTime : '00:00:00')
  }, [data])

  if (loading) return <Typography>LOADING</Typography>
  if (values.id && error) return <Typography>ERROR</Typography>

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
    </React.Fragment>
  )
}
