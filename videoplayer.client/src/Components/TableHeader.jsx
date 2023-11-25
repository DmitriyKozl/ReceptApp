import React from 'react'
import { TableCell, TableHead, TableRow } from '@mui/material'

const TableHeader = (props) => {
    const { title } = props
    switch (title) {
      case 'recipe':
        return (
          <TableHead sx={{ backgroundColor: '#fff', boxShadow: '0px 20px 25px -15px RGB(213 217 219)' }}>
            <TableRow>
              <TableCell sx={{ borderBottom: 0, borderRadius: '20px 0 0 20px' }}></TableCell>
              <TableCell sx={{ borderBottom: 0 }}>img</TableCell>
              <TableCell sx={{ borderBottom: 0 }}>name</TableCell>
              <TableCell sx={{ borderBottom: 0 }}>videoLink</TableCell>
              <TableCell sx={{ borderBottom: 0 }}>serving</TableCell>
              <TableCell sx={{ borderBottom: 0 }}>cookingTime</TableCell>
              <TableCell sx={{ borderBottom: 0, borderRadius: '0 20px 20px 0' }}></TableCell>
            </TableRow>
          </TableHead>
        )
      case 'ingredient':
        return (
          <TableHead sx={{ backgroundColor: '#fff', boxShadow: '0px 20px 25px -15px RGB(213 217 219)' }}>
            <TableRow>
              <TableCell sx={{ borderBottom: 0, borderRadius: '20px 0 0 20px' }}>name</TableCell>
              <TableCell sx={{ borderBottom: 0 }}>brand</TableCell>
              <TableCell sx={{ borderBottom: 0 }}>price</TableCell>
              <TableCell sx={{ borderBottom: 0, borderRadius: '0 20px 20px 0' }}></TableCell>
            </TableRow>
          </TableHead>
        )
      case 'utensil':
        return (
          <TableHead sx={{ backgroundColor: '#fff', boxShadow: '0px 20px 25px -15px RGB(213 217 219)' }}>
            <TableRow>
              <TableCell sx={{ borderBottom: 0, borderRadius: '20px 0 0 20px' }}>name</TableCell>
              <TableCell sx={{ borderBottom: 0, borderRadius: '0 20px 20px 0' }}></TableCell>
            </TableRow>
          </TableHead>
        )
      default:
        return (
          <TableHead sx={{ backgroundColor: '#fff', boxShadow: '0px 20px 25px -15px RGB(213 217 219)' }}>
            <TableRow>
              <TableCell sx={{ borderBottom: 0, borderRadius: '20px 0 0 20px' }}></TableCell>
              <TableCell sx={{ borderBottom: 0, borderRadius: '0 20px 20px 0' }}></TableCell>
            </TableRow>
          </TableHead>
        )
    }
}

export default TableHeader