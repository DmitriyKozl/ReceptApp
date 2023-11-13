/* eslint-disable no-unused-vars */
import React, { useState } from 'react'
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
} from '@mui/material'
import { TimeField } from '@mui/x-date-pickers/TimeField'
import useAxios, { configure } from 'axios-hooks'
import apiUrl from '../common/apiUrl'

export const TimingPopup = (props) => {
  const { values } = props

  const axios = apiUrl()
  configure({ axios })

  const [{ data: dataUtensil, loading: loadingUtensil, error: utensilError }] = useAxios({
    url: `/Utensil/utensil/all`,
    method: 'GET',
  })
  const [{ data: dataIngredient, loading: loadingIngredient, error: recipeIngredient }] = useAxios({
    url: `/Ingredient/ingredient/all`,
    method: 'GET',
  })

  const [{ data }] = useAxios({
    url: `/Recipe/recipe/${values?.id}`,
    method: 'GET',
  })

  const dummydataIngredient = [
    {
      id: 1,
      name: 'chocolade',
      brand: 'boni',
      img: 'https://images.unsplash.com/photo-1623660053975-cf75a8be0908?auto=format&fit=crop&q=80&w=1974&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D',
      brandImg:
        'https://www.colruytgroup.com/content/dam/colruytgroup/merken/consumentenmerken/boni/LP_reference-image_boni-new.png/_jcr_content/renditions/cq5dam.web.1280.1280.png',
    },
    {
      id: 2,
      name: 'gehakt',
      brand: 'boni',
      img: 'https://plus.unsplash.com/premium_photo-1670357599528-c604816e04f6?auto=format&fit=crop&q=80&w=1974&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D',
      brandImg:
        'https://www.colruytgroup.com/content/dam/colruytgroup/merken/consumentenmerken/boni/LP_reference-image_boni-new.png/_jcr_content/renditions/cq5dam.web.1280.1280.png',
    },
    {
      id: 3,
      name: 'aardbeien',
      brand: 'boni',
      img: 'https://images.unsplash.com/photo-1587393855524-087f83d95bc9?auto=format&fit=crop&q=80&w=1960&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D',
      brandImg:
        'https://www.colruytgroup.com/content/dam/colruytgroup/merken/consumentenmerken/boni/LP_reference-image_boni-new.png/_jcr_content/renditions/cq5dam.web.1280.1280.png',
    },
  ]
  const dummydataUtensil = [
    {
      id: 1,
      name: 'pan',
      brand: 'boni',
      img: 'https://images.unsplash.com/photo-1592156328697-079f6ee0cfa5?q=80&w=2080&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D',
    },
    {
      id: 2,
      name: 'maatbeker',
      brand: 'boni',
      img: 'https://images.unsplash.com/photo-1586797166778-7cb76a618157?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D',
    },
    {
      id: 3,
      name: 'houten lepel',
      brand: 'boni',
      img: 'https://images.unsplash.com/photo-1579892876770-461a88bd87df?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D',
    },
  ]

  const [id, setId] = useState(values?.id)
  const [brand, setBrand] = useState(values?.title === 'ingredient' ? data.ingedient.brand : data.utensil.brand)
  const [from, setFrom] = useState(
    values?.title === 'ingredient'
      ? data.ingedient?.from
        ? data.ingedient.from
        : '00:00:00'
      : data.utensil?.from
      ? data.utensil.from
      : '00:00:00'
  )
  const [till, setTill] = useState(
    values?.title === 'ingredient'
      ? data.ingedient?.till
        ? data.ingedient.till
        : '00:00:00'
      : data.utensil?.till
      ? data.utensil.till
      : '00:00:00'
  )

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
                ? dummydataUtensil.map((e) => <MenuItem value={e.id}>{e.name}</MenuItem>)
                : dummydataIngredient.map((e) => <MenuItem value={e.id}>{e.name}</MenuItem>)}
            </Select>
          </FormControl>
          <FormControl>
            <InputLabel>brand</InputLabel>
            <OutlinedInput label='brand' value={brand} disabled margin='normal' sx={{ borderRadius: '20px' }} />
            {/* <Select
              label='brand'
              value={id}
              onChange={(e) => {
                setId(e.target.value)
              }}
              disabled
              sx={{ borderRadius: '20px' }}
            >
              {values.title === 'utensil'
                ? dummydataUtensil.map((e) => <MenuItem value={e.id}>{e.brand}</MenuItem>)
                : dummydataIngredient.map((e) => <MenuItem value={e.id}>{e.brand}</MenuItem>)}
            </Select> */}
          </FormControl>
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
