import React, { useState } from 'react'
import { useNavigate } from 'react-router-dom'
import {
  Button,
  FormControl,
  Grid,
  IconButton,
  InputAdornment,
  InputLabel,
  OutlinedInput,
  Paper,
  Stack,
  Typography,
} from '@mui/material'
import Visibility from '@mui/icons-material/Visibility'
import VisibilityOff from '@mui/icons-material/VisibilityOff'

const Home = () => {
  const navigate = useNavigate()

  const [username, setUsername] = useState()
  const [password, setPassword] = useState()
  const [showPassword, setShowPassword] = useState(false)

  return (
    <Grid container sx={{ height: '100vh', width: '100vw', justifyContent: 'center', alignContent: 'center' }}>
      <Paper elevation={3} sx={{ p: 5 }}>
        <Stack sx={{ alignContent: 'center', justifyContent: 'center' }}>
          <Typography variant='h2' sx={{ m: 2, color: 'primary.dark', textAlign: 'center' }}>
            Login
          </Typography>
          <FormControl sx={{ m: 1, width: '25ch' }}>
            <InputLabel>username</InputLabel>
            <OutlinedInput label='username' value={username} onChange={(e) => setUsername(e.target.value)} />
          </FormControl>
          <FormControl sx={{ m: 1, width: '25ch' }}>
            <InputLabel>password</InputLabel>
            <OutlinedInput
              type={showPassword ? 'text' : 'password'}
              endAdornment={
                <InputAdornment position='end'>
                  <IconButton
                    onClick={() => {
                      setShowPassword(!showPassword)
                    }}
                    edge='end'
                  >
                    {showPassword ? <VisibilityOff /> : <Visibility />}
                  </IconButton>
                </InputAdornment>
              }
              label='password'
              value={password}
              onChange={(e) => setPassword(e.target.value)}
            />
          </FormControl>
          <Button
            variant='contained'
            disabled={!username || !password}
            onClick={() => {
              navigate('/recipe')
            }}
            sx={{ m: 1 }}
          >
            Login
          </Button>
        </Stack>
      </Paper>
    </Grid>
  )
}

export default Home
