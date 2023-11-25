// TableHeader.js
import React from "react";
import { TableHead, TableRow, TableCell } from "@mui/material";
import { createTheme, ThemeProvider } from "@mui/material/styles";

const TableHeader = ({ title }) => {
  // Define the header cells based on the 'title' prop
  const headers = {
    Recipe: [" ", "Image", "Name", "Video Link", "Servings", "Cooking Time"],
    Ingredient: ["Image", "Name", "Brand", "Price"],
    Utensil: ["Image", "Name"],
  };

  const theme = createTheme({
    components: {
      // Styling for TableHead
      MuiTableHead: {
        styleOverrides: {
          root: {
          },
        },
      },
      // Styling for TableRow in the TableHead
      MuiTableRow: {
        styleOverrides: {
          head: {

          },
        },
      },
      // Styling for TableCell in the TableHead
      MuiTableCell: {
        styleOverrides: {
          head: {
            // Targeting cells specifically in the TableHead
            // Add your styles here
            color: "#516975",
            fontFamily: "inherit",
            fontSize: "10px",
            fontStyle: "normal",
            fontWeight: "400",
            lineHeight: "normal",
            padding: "0.4rem",
            border: "none",

          },
        },
      },
    },
  });
  return (
    <ThemeProvider theme={theme}>
      <TableHead>
        <TableRow>
          {headers[title].map((header, index) => (
            <TableCell key={index}>{header}</TableCell>
          ))}
        </TableRow>
      </TableHead>
    </ThemeProvider>
  );
};

export default TableHeader;
