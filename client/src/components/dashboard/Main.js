import { Box } from '@mui/system';
import React from 'react';
import List from './List';
import Navbar from './Navbar';

function Main() {
  return (
    <Box
      sx={{
        flex: '0 0 78%',
        height: 'calc(100vh - 60px)',
        bgcolor: 'primary.light'
      }}
    >
      <Navbar />
      <List />
    </Box>
  );
}

export default Main;
