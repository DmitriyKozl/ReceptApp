import React, { useEffect, useState } from 'react'
import moment from 'moment'
import {
  DialogContent,
  DialogTitle,
  FormControl,
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

export const TimingPopup = (props) => {
  const { values } = props

  const axios = apiUrl()
  configure({ axios })

  const [{ data: dataUtensil }] = useAxios({
    url: `/Utensil/all`,
    method: 'GET',
  })
  const [{ data: dataIngredient }] = useAxios({
    url: `/Ingredient/all`,
    method: 'GET',
  })

  const [{ data, loading, error }] = useAxios({
    url: `/Recipe/{recipeId}?recipeId=${values?.id}`,
    method: 'GET',
  })

  const [id, setId] = useState(values?.id)
  const [brand, setBrand] = useState()
  const [from, setFrom] = useState()
  const [till, setTill] = useState()

  useEffect(() => {
    setBrand(values?.title === 'ingredient' ? data?.ingedient?.brand : '')
    setFrom(
      values?.title === 'ingredient'
        ? data?.ingedient?.from
          ? data?.ingedient?.from
          : '00:00:00'
        : data?.utensil?.from
        ? data?.utensil?.from
        : '00:00:00'
    )
    setTill(
      values?.title === 'ingredient'
        ? data?.ingedient?.till
          ? data?.ingedient?.till
          : '00:00:00'
        : data?.utensil?.till
        ? data?.utensil?.till
        : '00:00:00'
    )
  }, [values?.title, data])

  if (loading) return <Typography>LOADING</Typography>
  if (values?.id && error) return <Typography>ERROR</Typography>

  return (
    <React.Fragment>
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
    </React.Fragment>
  )
}
