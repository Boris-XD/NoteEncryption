import React, { useContext, useState } from 'react';
import { Grid, TextField } from '@mui/material';
import ButtonsCrud from './ButtonsCrud';
import { ShareInformation } from '@pathShare';
import ListContext from '../../context/ListContext';
import Swal from 'sweetalert2';

function ShareForm({ idItem, data, closeModal, action }) {
  const { idContainer } = useContext(ListContext);
  const [shareData, setShareData] = useState({
    username: '',
    email: '',
  });

  const closeDataForm = () => {
    closeModal();
  };
  const shareDataForm = () => {
    ShareInformation(shareData, idItem);
    Swal.fire({
      title: 'Success',
      text: 'Share information successfully',
      icon: 'success',
      showConfirmButton: true,
    });
    closeModal();
  };
  return (
    <>
      <Grid item xs={6}>
        <TextField
          margin='normal'
          required
          fullWidth
          id='name'
          label='Name :'
          value={data.name}
          onChange={(e) =>
            setShareData({ ...shareData, username: e.target.value })
          }
        />
      </Grid>
      <Grid item xs={12}>
        <TextField
          id='outlined-multiline-static'
          fullWidth
          id='text'
          label='Users'
          multiline
          rows={4}
          onChange={(e) =>
            setShareData({ ...shareData, email: e.target.value })
          }
        />
      </Grid>

      <ButtonsCrud
        idItem={idItem}
        shareDataForm={shareDataForm}
        closeDataForm={closeDataForm}
        action={action}
      />
    </>
  );
}

export default ShareForm;
