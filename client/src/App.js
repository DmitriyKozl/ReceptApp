import React from 'react'
import { Routes, Route, Navigate, BrowserRouter } from 'react-router-dom'
import { createTheme } from '@mui/material/styles'
import { ThemeProvider } from '@mui/material/styles'
import Home from './pages/Home'
import Admin from './pages/Admin'

const App = () => {
  const theme = createTheme({
    palette: {
      background: {
        default: '#0587C7',
      },
      primary: {
        main: '#0587C7',
      },
    },
    typography: { fontFamily: ['Poppins', 'sans-serif'].join(',') },
  })

  return (
    <ThemeProvider theme={theme}>
      <React.Fragment>
        <BrowserRouter>
          <Routes>
            <Route path='*' element={<Navigate to='/' replace />} />
            <Route path='/' element={<Navigate to={'/home'} replace />} />
            <Route path='/home' element={<Home />} />
            <Route path='/:title' element={<Admin />} />
          </Routes>
        </BrowserRouter>
      </React.Fragment>
    </ThemeProvider>
  )
}

export default App
