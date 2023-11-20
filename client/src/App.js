import React from 'react';
import { Routes, Route, Navigate, BrowserRouter } from 'react-router-dom';
import { createTheme } from '@mui/material/styles';
import { ThemeProvider } from '@mui/material/styles';
import { LocalizationProvider } from '@mui/x-date-pickers';
import { AdapterMoment } from '@mui/x-date-pickers/AdapterMoment';
import Home from './pages/Home';
import Login from './pages/Login'; 
import Admin from './pages/Admin';
import { Topbar } from './components/Topbar';

const App = () => {
  const theme = createTheme({
    palette: {
      background: {
        default: '#0587C7',
      },
      primary: {
        main: '#0587C7',
        dark: '#035e8b',
        light: '#0587C712',
      },
    },
    typography: { fontFamily: ['Red Hat Display', 'sans-serif'].join(',') },
  });

  return (
    <LocalizationProvider dateAdapter={AdapterMoment}>
      <ThemeProvider theme={theme}>
        <React.Fragment>
          <BrowserRouter>
            <Routes>
              <Route path='*' element={<Navigate to='/' replace />} />
              <Route path='/' element={<Navigate to={'/home'} replace />} />
              <Route
                path='/home'
                element={
                  <>
                    <Topbar />
                    <Home />
                  </>
                }
              />
              <Route path='/login' element={<Login />} />
              <Route path='/:title' element={<Admin />} />
            </Routes>
          </BrowserRouter>
        </React.Fragment>
      </ThemeProvider>
    </LocalizationProvider>
  );
};

export default App;
