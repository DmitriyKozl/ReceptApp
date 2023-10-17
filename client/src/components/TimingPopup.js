import React, { useState } from 'react'
import { Box, DialogContent, DialogTitle, FormControl, InputLabel, MenuItem, Select, TextField } from '@mui/material'

export const TimingPopup = (props) => {
  const { values } = props

  const [name, setName] = useState(values?.name)
  const [brand, setBrand] = useState(values?.brand)
  const [from, setFrom] = useState(values?.from)
  const [till, setTill] = useState(values?.till)

  return (
    <React.Fragment>
      <DialogTitle>Ingredient</DialogTitle>
      <DialogContent dividers='true'>
        <Box display={'grid'}>
          {!values?.new ? (
            <>
              <TextField label='name' value={name} disabled variant='filled' margin='normal' sx={{ width: 500 }} />
              <TextField label='brand' value={brand} disabled variant='filled' margin='normal' sx={{ width: 500 }} />
            </>
          ) : (
            <FormControl>
              <InputLabel>name - brand</InputLabel>
              <Select
                value={name}
                onChange={(e) => {
                  setName(e.target.value)
                }}
                variant='filled'
                margin='normal'
              >
                <MenuItem value={'choclade'}>choclade - boni</MenuItem>
                <MenuItem value={'gehakt'}>gehakt - boni</MenuItem>
                <MenuItem value={'aardbeien'}>aardbeien - boni</MenuItem>
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
        </Box>
      </DialogContent>
    </React.Fragment>
  )
}
