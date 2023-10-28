import React, { useState } from 'react'
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

export const TimingPopup = (props) => {
  const { values } = props

  const [id, setId] = useState(values?.id)
  const [from, setFrom] = useState(values?.from)
  const [till, setTill] = useState(values?.till)

  return (
    <React.Fragment>
      <DialogTitle variant='h4' m={1}>
        Timing
      </DialogTitle>
      <DialogContent>
        <Stack justifyContent='space-evenly' alignItems='stretch' spacing={3} width={550}>
          <FormControl>
            {id ? '' : <InputLabel shrink={false}>name</InputLabel>}
            <Select
              value={id}
              onChange={(e) => {
                setId(e.target.value)
                setId(e.target.value)
              }}
              margin='normal'
              sx={{ borderRadius: '20px' }}
            >
              <MenuItem value={1}>choclade</MenuItem>
              <MenuItem value={2}>gehakt</MenuItem>
              <MenuItem value={3}>aardbeien</MenuItem>
            </Select>
          </FormControl>
          <FormControl>
            {id ? '' : <InputLabel shrink={false}>brand</InputLabel>}
            <Select
              value={id}
              onChange={(e) => {
                setId(e.target.value)
                setId(e.target.value)
              }}
              margin='normal'
              sx={{ borderRadius: '20px' }}
            >
              <MenuItem value={1}>boni</MenuItem>
              <MenuItem value={2}>boni</MenuItem>
              <MenuItem value={3}>boni</MenuItem>
            </Select>
          </FormControl>
          <FormControl>
            <InputLabel>from</InputLabel>
            <OutlinedInput
              label='from'
              value={from}
              onChange={(e) => setFrom(e.target.value)}
              margin='normal'
              sx={{ borderRadius: '20px' }}
            />
          </FormControl>
          <FormControl>
            <InputLabel>till</InputLabel>
            <OutlinedInput
              label='till'
              value={till}
              onChange={(e) => setTill(e.target.value)}
              margin='normal'
              sx={{ borderRadius: '20px' }}
            />
          </FormControl>
        </Stack>
        {/* <Box display={'grid'}>
          {!values?.new ? (
            <>
              <TextField label='name' value={name} disabled variant='filled' margin='normal' sx={{ width: 500 }} />
              <TextField label='brand' value={brand} disabled variant='filled' margin='normal' sx={{ width: 500 }} />
            </>
          ) : (
            <FormControl>
              <InputLabel>name - brand</InputLabel>
              <Select
                value={selected}
                onChange={(e) => {
                  setSelected(e.target.value)
                }}
                variant='filled'
                margin='normal'
              >
                <MenuItem value={1}>choclade - boni</MenuItem>
                <MenuItem value={2}>gehakt - boni</MenuItem>
                <MenuItem value={3}>aardbeien - boni</MenuItem>
              </Select>
            </FormControl>
          )}

          <TextField
            label='from'
            value={from}
            onChange={(e) => setFrom(e.target.value)}
            variant='filled'
            margin='normal'
            sx={{ width: 500 }}
          />
          <TextField
            label='till'
            value={till}
            onChange={(e) => setTill(e.target.value)}
            variant='filled'
            margin='normal'
            sx={{ width: 500 }}
          />
        </Box> */}
      </DialogContent>
    </React.Fragment>
  )
}
