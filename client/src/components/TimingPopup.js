import React, { useState } from 'react'
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
  MenuItem,
  OutlinedInput,
  Select,
  Stack,
  Typography,
} from '@mui/material'
import { TimeField } from '@mui/x-date-pickers/TimeField'
import useAxios, { configure } from 'axios-hooks'
import apiUrl from '../common/apiUrl'
import CloseIcon from '@mui/icons-material/Close'

export const TimingPopup = (props) => {
  const { values, openTimingPopup, handleClose } = props

  const axios = apiUrl()
  configure({ axios })

  const [id, setId] = useState(values?.id)
  const [brand, setBrand] = useState(values?.brand)
  const [from, setFrom] = useState(values?.from ? values.from : '00:00:00')
  const [till, setTill] = useState(values?.till ? values.till : '00:00:00')

  const [{ data: dataUtensil, loading: loadingUtensil }] = useAxios({
    url: `/Utensil/all`,
    method: 'GET',
  })
  const [{ data: dataIngredient, loading: loadingIngriedient }] = useAxios({
    url: `/Ingredient/all`,
    method: 'GET',
  })
  const [{ data: postIngredientData }, executeIngredientPost] = useAxios(
    {
      url: `/Recipe/${values.recipeId}/ingredient/${id}`,
      method: 'POST',
    },
    { manual: true }
  )
  const [{ data: postUtensilData }, executeUtensilPost] = useAxios(
    {
      url: `/Recipe/${values.recipeId}/utensil/${id}`,
      method: 'POST',
    },
    { manual: true }
  )

  console.log(values.recipeId, id)

  if (loadingUtensil || loadingIngriedient) return <Typography>LOADING</Typography>

  return (
    <Dialog open={openTimingPopup} onClose={handleClose} PaperProps={{ sx: { borderRadius: '20px' } }}>
      <IconButton sx={{ position: 'absolute', alignSelf: 'end' }} onClick={handleClose}>
        <CloseIcon fontSize='large' />
      </IconButton>
      <DialogTitle variant='h4' m={1}>
        Timing
      </DialogTitle>
      <DialogContent>
        <Stack justifyContent='space-evenly' alignItems='stretch' spacing={3} width={550}>
          <FormControl>
            <InputLabel>name</InputLabel>
            <Select
              label='name'
              value={id}
              onChange={(e) => {
                setId(e.target.value)
              }}
              sx={{ borderRadius: '20px' }}
            >
              {values?.title === 'utensil'
                ? dataUtensil.map((e) => <MenuItem value={e.id}>{e.name}</MenuItem>)
                : dataIngredient.map((e) => <MenuItem value={e.id}>{e.name}</MenuItem>)}
            </Select>
          </FormControl>
          {values?.title === 'ingredient' ? (
            <FormControl>
              <InputLabel>brand</InputLabel>
              <OutlinedInput label='brand' value={brand} disabled margin='normal' sx={{ borderRadius: '20px' }} />
            </FormControl>
          ) : null}
          <TimeField
            label='from'
            value={moment(from, 'HH:mm:ss')}
            onChange={(e) => setFrom(e.format('HH:mm:ss'))}
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
          <TimeField
            label='till'
            value={moment(till, 'HH:mm:ss')}
            onChange={(e) => setTill(e.format('HH:mm:ss'))}
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
      <DialogActions sx={{ justifyContent: 'center' }}>
        <Button
          onClick={() => {
            if (values.title === 'ingredient') {
              executeIngredientPost({ data: { from: from, till: till } })
              console.log(postIngredientData)
            }
            if (values.title === 'utensil') {
              executeUtensilPost({ data: { from: from, till: till } })
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
