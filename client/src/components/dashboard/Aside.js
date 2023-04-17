import React from 'react';
import { Box, margin } from '@mui/system';
import Container from '../aside/Container';
import Accordion from '../aside/Accordion';
function Aside() {
  return (
    <Box
      sx={{
        flex: '0 0 22%',
        height: 'calc(100vh - 60px)',
        bgcolor: 'secondary.main',
      }}
    >
      <Box sx={{ width: '90%', margin: 'auto' }}>
        <Accordion />
      </Box>
    </Box>
  );
}

export default Aside;
