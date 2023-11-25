// IngredientRow.js
import React from 'react';
import { TableRow, TableCell, IconButton, Avatar } from '@mui/material';
import EditIcon from '@mui/icons-material/Edit';
import DeleteIcon from '@mui/icons-material/Delete';
import { ThemeProvider, createTheme } from '@mui/material/styles';
const theme = createTheme({
  components: {
    MuiTableCell: {
      styleOverrides: {
        root: {
          // Targeting cells specifically in the TableHead
          // Add your styles here
          color: "#516975",
          fontFamily: "inherit",
          fontSize: "0.8rem",
          fontStyle: "normal",
          fontWeight: "800",
          lineHeight: "normal",
          padding: "0.4rem",
          border: "none",
          boxShadow: " 0px 4px 30px 0px rgba(0, 0, 0, 0.05)",
        },
      },
    },
  },
});
const IngredientRow = ({ ingredient, setValues, setOpenPopup }) => {
  const handleOpenEditPopup = () => {
    setValues({ title: 'Ingredient', id: ingredient.id });
    setOpenPopup(true);
  };

  return (
    <ThemeProvider theme={theme}>
    <TableRow >
      {/* Table Cells for Ingredient Row */}
      <TableCell
       sx={{ borderRadius: "100px 0 0 100px " }}>
        <Avatar src={ingredient.img} />
      </TableCell>
      <TableCell>
        {ingredient.name}
      </TableCell>   
       <TableCell>
        <Avatar src={ingredient.brandImg} />
      </TableCell>
      <TableCell>€ {ingredient.price}</TableCell>
      <TableCell align="center" sx={{ borderRadius: "0 100px   100px 0" }}>

        <IconButton onClick={handleOpenEditPopup}>
          <EditIcon />
        </IconButton>
        <IconButton>
          <DeleteIcon />
        </IconButton>
      </TableCell>
    </TableRow>
    </ThemeProvider>
  );
};

export default IngredientRow;