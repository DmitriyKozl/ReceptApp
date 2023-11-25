// UtensilRow.js
import React from 'react';
import { TableRow, TableCell, IconButton, Avatar } from '@mui/material';
import EditIcon from '@mui/icons-material/Edit';
import DeleteIcon from '@mui/icons-material/Delete';

const UtensilRow = ({ utensil, setValues, setOpenPopup }) => {
  const handleOpenEditPopup = () => {
    setValues({ title: 'Utensil', id: utensil.id });
    setOpenPopup(true);
  };

  return (
    <TableRow sx={{ boxShadow: '0px 20px 25px -15px RGB(213 217 219)' }}>
      {/* Table Cells for Utensil Row */}
      <TableCell>
        <Avatar src={utensil.img} />
        {utensil.name}
      </TableCell>
      <TableCell align="right">
        <IconButton onClick={handleOpenEditPopup}>
          <EditIcon />
        </IconButton>
        <IconButton>
          <DeleteIcon />
        </IconButton>
      </TableCell>
    </TableRow>
  );
};

export default UtensilRow;