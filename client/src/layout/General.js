import { Box } from '@mui/system';
import React from 'react';
import Aside from '../components/dashboard/Aside';
import Main from '../components/dashboard/Main';

function General() {
  
  return (
    <Box sx={{ display: 'flex'}}>
      <Aside />
      <Main /> 
    </Box>
  );
}

export default General;