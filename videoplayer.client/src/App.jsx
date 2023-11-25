import React from "react";
import { Routes, Route, Navigate, BrowserRouter } from "react-router-dom";
import { createTheme } from "@mui/material/styles";
import { useState, useMemo } from "react";
import { ThemeProvider } from "@mui/material/styles";
import { LocalizationProvider } from "@mui/x-date-pickers";
import Home from "./Pages/HomePage";
import Login from "./Pages/LoginPage";
import Admin from "./Pages/AdminPage";
import Navbar from "./Components/Navbar";

//TODO make darkmode/ lightmode
const App = () => {

  const theme = 
    createTheme({
      palette: {
        background: {
          default: "#0587C7",
        },
        primary: {
          main: "#0587C7",
          dark: "#035e8b",
          light: "#0587C712",
        },
      },
    }
  );
  return (
    <LocalizationProvider>
      <ThemeProvider theme={theme}>
        <React.Fragment>
          <BrowserRouter>
            <Routes>
              <Route path="*" element={<Navigate to="/" replace />} />
              <Route path="/" element={<Navigate to={"/home"} replace />} />
              <Route
                path="/home"
                element={
                  <>
                    <Navbar />

                    <Home />
                  </>
                }
              />
              <Route
                path="/login"
                element={
                  <>
                    <Navbar />
                    <Login />
                  </>
                }
              />
              <Route path="/:title" element={<Admin />} />
            </Routes>
          </BrowserRouter>
        </React.Fragment>
      </ThemeProvider>
    </LocalizationProvider>
  );
};

export default App;
