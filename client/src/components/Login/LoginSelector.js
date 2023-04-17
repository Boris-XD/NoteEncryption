import * as React from 'react';
import Box from '@mui/material/Box';
import InputLabel from '@mui/material/InputLabel';
import FormControl from '@mui/material/FormControl';
import NativeSelect from '@mui/material/NativeSelect';

export default function NativeSelectDemo() {
  return (
    <Box sx={{ minWidth: 120 }}>
      <FormControl fullWidth>
        <InputLabel variant='standard' htmlFor='uncontrolled-native'>
          Select Default Encryptor
        </InputLabel>
        <NativeSelect
          defaultValue={'Binary'}
          inputProps={{
            name: 'Encryption type',
            id: 'uncontrolled-native',
          }}
        >
          <option value={1}>Binary</option>
          <option value={2}>Hexadecimal</option>
          <option value={3}>Base64</option>
          <option value={4}>AES</option>
          <option value={5}>RSA</option>
        </NativeSelect>
      </FormControl>
    </Box>
  );
}
