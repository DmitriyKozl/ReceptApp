// eslint-disable-next-line no-unused-vars
import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import axios from 'axios'; // Import Axios for making API requests
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
  Container
} from '@mui/material';
import Background from '../assets/background.jpeg';
import Visibility from '@mui/icons-material/Visibility';
import VisibilityOff from '@mui/icons-material/VisibilityOff';
import "../Style/LoginPage.css";

const Login = () => {
  const navigate = useNavigate();

  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');
  const [showPassword, setShowPassword] = useState(false);

  const handleLogin = async () => {
    try {
      const response = await axios.post('http://localhost:5000/api/user/login', { username, password });

      const token = response.data.token;

      localStorage.setItem('token', token);

      navigate('/recipe');
    } catch (error) {
      console.error('Login failed', error);
    }
  };

  return (
    <Container  maxWidth={"100%"} sx={{ py:0, height: '100vh', display: 'flex', alignItems: 'center', justifyContent: 'center' }}>
    <Grid
      container
      sx={{	
        justifyContent: 'center',
        alignContent: 'center',
        backgroundImage: `url(${Background})`,
        backgroundPosition: 'top',
        backgroundSize: 'cover',
        height: '100%', // Set height to 100%
        display: 'flex', // Use flexbox
        align: 'center', // Center vertically
        justify: 'center', // Center horizontally
        width: '100%',
      }}
    >
        <Paper elevation={3} sx={{ p: 5 }}>
          <Stack sx={{ alignContent: 'center', justifyContent: 'center' }}>
            <Typography variant='h2' sx={{ m: 2, color: 'primary.dark', textAlign: 'center' }}>
              Admin
            </Typography>
            <FormControl sx={{ m: 1, width: '300px' }}>
              <InputLabel>username</InputLabel>
              <OutlinedInput label='username' value={username} onChange={(e) => setUsername(e.target.value)} />
            </FormControl>
            <FormControl sx={{ m: 1, width: '300px' }}>
              <InputLabel>password</InputLabel>
              <OutlinedInput
                type={showPassword ? 'text' : 'password'}
                endAdornment={
                  <InputAdornment position='end'>
                    <IconButton
                      onClick={() => {
                        setShowPassword(!showPassword);
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
            <Button variant='contained' onClick={handleLogin} sx={{ m: 1 }}>
              Login
            </Button>
          </Stack>
        </Paper>
      </Grid>
    </Container>
  );
};

export default Login;
