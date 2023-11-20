import React, { useState } from 'react';
import moment from 'moment';
import {
  Button,
  Dialog,
  DialogActions,
  DialogContent,
  DialogTitle,
  FormControl,
  IconButton,
  InputLabel,
  MenuItem,
  OutlinedInput,
  Select,
  Stack,
  Typography,
} from '@mui/material';
import { TimeField } from '@mui/x-date-pickers/TimeField';
import useAxios, { configure } from 'axios-hooks';
import apiUrl from '../common/apiUrl';
import CloseIcon from '@mui/icons-material/Close';

// Component for the Popup used for adding/editing Timings (Ingredient or Utensil)
export const TimingPopup = (props) => {
  const { values, openTimingPopup, handleClose } = props;

  // Axios configuration using axios-hooks
  const axios = apiUrl();
  configure({ axios });

  // State variables to manage form fields
  const [id, setId] = useState(values?.id);
  const [brand, setBrand] = useState(values?.brand);
  const [from, setFrom] = useState(values?.from ? values.from : '00:00:00');
  const [till, setTill] = useState(values?.till ? values.till : '00:00:00');

  // Use axios-hooks for fetching Utensil and Ingredient data
  const [{ data: dataUtensil, loading: loadingUtensil }] = useAxios({
    url: `/Utensil`,
    method: 'GET',
  });
  const [{ data: dataIngredient, loading: loadingIngredient }] = useAxios({
    url: `/Ingredient/${values.id} || ''`,
    method: 'GET',
  });

  // Use axios-hooks for making POST requests for Ingredient and Utensil
  const [{ data: postIngredientData }, executeIngredientPost] = useAxios(
    {
      url: `/Recipe/${values.recipeId}/ingredient/${id}`,
      method: 'POST',
    },
    { manual: true }
  );
  const [{ data: postUtensilData }, executeUtensilPost] = useAxios(
    {
      url: `/Recipe/${values.recipeId}/utensil/${id}`,
      method: 'POST',
    },
    { manual: true }
  );

  // Loading check
  if (loadingUtensil || loadingIngredient) return <Typography>Loading...</Typography>;

  // JSX for rendering the Popup
  return (
    <Dialog open={openTimingPopup} onClose={handleClose} PaperProps={{ sx: { borderRadius: '20px' } }}>
      <IconButton sx={{ position: 'absolute', alignSelf: 'end' }} onClick={handleClose}>
        <CloseIcon fontSize='large' />
      </IconButton>
      <DialogTitle variant='h4' m={1}>
        Timing
      </DialogTitle>
      <DialogContent>
        <Stack justifyContent='space-evenly' alignItems='stretch' spacing={3} width={550}>
          {/* Dropdown for selecting Ingredient or Utensil */}
          <FormControl>
            <InputLabel>name</InputLabel>
            <Select
              label='name'
              value={id}
              onChange={(e) => {
                setId(e.target.value);
              }}
              sx={{ borderRadius: '20px' }}
            >
              {values?.title === 'utensil' && dataUtensil?.length > 0 ? (
                dataUtensil.map((e) => (
                  <MenuItem key={e.id} value={e.id}>
                    {e.name}
                  </MenuItem>
                ))
              ) : values?.title === 'ingredient' && dataIngredient?.length > 0 ? (
                dataIngredient.map((e) => (
                  <MenuItem key={e.id} value={e.id}>
                    {e.name}
                  </MenuItem>
                ))
              ) : null}
            </Select>
          </FormControl>
          {/* Display brand for Ingredient */}
          {values?.title === 'ingredient' ? (
            <FormControl>
              <InputLabel>brand</InputLabel>
              <OutlinedInput label='brand' value={brand} disabled margin='normal' sx={{ borderRadius: '20px' }} />
            </FormControl>
          ) : null}
          {/* TimeField for 'from' */}
          <TimeField
            label='from'
            value={moment(from, 'HH:mm:ss')}
            onChange={(e) => setFrom(e.format('HH:mm:ss'))}
            format='HH:mm:ss'
            sx={{
              '& .MuiOutlinedInput-root': {
                '& fieldset': {
                  borderRadius: '20px',
                },
                '&:hover fieldset': {
                  borderRadius: '20px',
                },
                '&.Mui-focused fieldset': {
                  borderRadius: '20px',
                },
              },
            }}
          />
          {/* TimeField for 'till' */}
          <TimeField
            label='till'
            value={moment(till, 'HH:mm:ss')}
            onChange={(e) => setTill(e.format('HH:mm:ss'))}
            format='HH:mm:ss'
            sx={{
              '& .MuiOutlinedInput-root': {
                '& fieldset': {
                  borderRadius: '20px',
                },
                '&:hover fieldset': {
                  borderRadius: '20px',
                },
                '&.Mui-focused fieldset': {
                  borderRadius: '20px',
                },
              },
            }}
          />
        </Stack>
      </DialogContent>
      {/* Save button */}
      <DialogActions sx={{ justifyContent: 'center' }}>
        <Button
          onClick={() => {
            // Execute POST request based on Ingredient or Utensil type
            if (values.title === 'ingredient') {
              executeIngredientPost({ data: { from: from, till: till } });
              console.log(postIngredientData);
            }
            if (values.title === 'utensil') {
              executeUtensilPost({ data: { from: from, till: till } });
              console.log(postUtensilData);
            }
            handleClose();
          }}
          sx={{
            p: '10px 50px',
            borderRadius: '20px',
            color: '#fff',
            backgroundColor: 'primary.main',
            ':hover': { backgroundColor: 'primary.main' },
          }}
        >
          save
        </Button>
      </DialogActions>
    </Dialog>
  );
};
