import { Box } from '@mui/material';
import React from 'react';
import ListShare from '../components/share/ListShare';
import NavbarShare from '../components/share/NavbarShare';

function MainShare() {
  return (
    <Box
      sx={{
        flex: '0 0 78%',
        height: 'calc(100vh - 60px)',
        bgcolor: 'primary.light',
      }}
    >
      <NavbarShare />
      <Box sx={{ display: 'flex' }}>
        <ListShare />
      </Box>
    </Box>
  );
}

export default MainShare;
