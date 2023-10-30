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
            <InputLabel>name</InputLabel>
            <Select
              label='name'
              value={id}
              onChange={(e) => {
                setId(e.target.value)
                setId(e.target.value)
              }}
              sx={{ borderRadius: '20px' }}
            >
              <MenuItem value={1}>choclade</MenuItem>
              <MenuItem value={2}>gehakt</MenuItem>
              <MenuItem value={3}>aardbeien</MenuItem>
            </Select>
          </FormControl>
          <FormControl>
            <InputLabel>brand</InputLabel>
            <Select
              label='brand'
              value={id}
              onChange={(e) => {
                setId(e.target.value)
                setId(e.target.value)
              }}
              sx={{ borderRadius: '20px' }}
            >
              <MenuItem value={1}>boni</MenuItem>
              <MenuItem value={2}>boni</MenuItem>
              <MenuItem value={3}>boni</MenuItem>
            </Select>
          </FormControl>
          <TimeField
            label='from'
            value={moment(from, 'mm:ss')}
            onChange={(e) => setFrom(e.format('mm:ss'))}
            format='mm:ss'
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
            value={moment(till, 'mm:ss')}
            onChange={(e) => setTill(e.format('mm:ss'))}
            format='mm:ss'
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
