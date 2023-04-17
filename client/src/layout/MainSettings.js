import {
  Box,
  FormControl,
  Grid,
  InputLabel,
  MenuItem,
  Select,
} from '@mui/material';
import React, { useContext } from 'react';
import ListContext from '../context/ListContext';
function MainSettings() {
  const { encryptionSelected, selectEncryption } = useContext(ListContext);
  return (
    <Box
      sx={{
        height: 'calc(100vh - 60px)',
        bgcolor: 'primary.light',
        display: 'flex',
        justifyContent: 'center',
        alignItems: 'center',
      }}
    >
      <Grid item xs={6}>
        <FormControl fullWidth sx={{ mt: '16px' }}>
          <InputLabel id='typeencryption-label'>Type Encryption</InputLabel>
          <Select
            labelId='typeencryption-label'
            id='typeencryption'
            defaultValue={encryptionSelected}
            label='Type Encryption'
            onChange={(e) => selectEncryption(e.target.value)}
          >
            <MenuItem value={'Binary'}>Binary</MenuItem>
            <MenuItem value={'Base64'}>Base64</MenuItem>
            <MenuItem value={'Hex'}>Hex</MenuItem>
            <MenuItem value={'Aes'}>Aes</MenuItem>
          </Select>
        </FormControl>
      </Grid>
    </Box>
  );
}

export default MainSettings;
