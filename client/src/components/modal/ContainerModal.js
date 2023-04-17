import React from 'react';
import Box from '@mui/material/Box';
import ContainerForm from './ContainerForm';

const style = {
  position: 'absolute',
  top: '50%',
  left: '50%',
  transform: 'translate(-50%, -50%)',
  width: '50%',
  bgcolor: 'background.paper',
  border: '3px solid quaternary.dark',
  boxShadow: 24,
  bgcolor: 'primary.light',
};

function ContainerModal({ name, favorite, idItem, closeModal, action }) {
  return (
    <Box sx={style} >
      <Box
        sx={{
          width: '100%',
          bgcolor: 'secondary.main',
          fontSize: '30px',
          display: 'flex',
          justifyContent: 'center',
          borderBotton: '3px solid quaternary.dark',
        }}
        
      >
        {action.toUpperCase()}
      </Box>
      <Box
        sx={{
          width: '100%',
          bgcolor: 'primary.light',
        }}
      >
        <ContainerForm
          name={name}
          favorite={favorite}
          idItem={idItem}
          closeModal={closeModal}
          action={action}
        />
      </Box>
    </Box>
  );
}

export default ContainerModal;
