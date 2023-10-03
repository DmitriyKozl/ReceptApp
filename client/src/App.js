import React from 'react'
import { Routes, Route, Navigate, BrowserRouter } from 'react-router-dom'
import { createTheme } from '@mui/material/styles'
import { ThemeProvider } from '@mui/material/styles'
import Home from './pages/Home'
import Recepten from './pages/Recepten'
import Timing from './pages/Timing'

const App = () => {
  const theme = createTheme(
    {
      palette: {
        background: {
          default: '#0587C7',
        },
        primary: {
          main: '#fff',
        },
        secondary: {
          main: '#2a425b',
          light: '#385699',
        },
        text: {
          primary: '#000',
          secondary: '#fff',
        },
      },
      typography: { fontFamily: ['Poppins', 'sans-serif'].join(',') },
    },
  )

  return (
    <ThemeProvider theme={theme}>
      <React.Fragment>
        <BrowserRouter>
          <Routes>
            <Route path='*' element={<Navigate to='/' replace />} />
            <Route path='/' element={<Navigate to={'/home'} replace />} />
            <Route path='/home' element={<Home />} />
            <Route path='/recepten' element={<Recepten />} />
            <Route path='/timing' element={<Timing />} />
          </Routes>
        </BrowserRouter>
      </React.Fragment>
    </ThemeProvider>
  )
}

export default App
