import React from 'react'
import { DialogContent, DialogTitle, TextField } from '@mui/material'

export const Popup = (props) => {
  const { title } = props

  return (
    <React.Fragment>
      <DialogTitle>{title}</DialogTitle>
      <DialogContent>
        <TextField label='name' sx={{ m: 1 }} />
        <TextField label='url' sx={{ m: 1 }} />
      </DialogContent>
    </React.Fragment>
  )
}
