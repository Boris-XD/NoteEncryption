import {
  Box,
  FormControl,
  Grid,
  InputLabel,
  MenuItem,
  NativeSelect,
  Select,
  TextField
} from '@mui/material';
import Swal from 'sweetalert2';
import React, { useContext, useState } from 'react';
import Button from '@mui/material/Button';

import { SendPostContainer } from '@pathSendPost';
import { SendPutContainer } from '@pathSendPut';
import ButtonsCrud from './ButtonsCrud';
import { ValidateContainerName } from '../../helpers/validateForms';

function ContainerForm({ name, favorite, idItem, closeModal, action }) {
  const UserId = localStorage.getItem('UserId');
  const [containerData, setContainerData] = useState({
    name: name || '',
    favorite: favorite == undefined ? true : favorite,
    userId: UserId
  });
  const handleSubmit = (event) => {
    event.stopPropagation();
  };
  const addDataForm = () => {
    let containerName = ValidateContainerName(containerData.name);
    if (containerName) {
      SendPostContainer(containerData);
      Swal.fire({
        title: 'Container added',
        icon: 'success',
        showCloseButton: true,
        timer: '2500'
      });
      closeModal();
    } else {
      Swal.fire({
        target: document.getElementById('ContainerModal'),
        title: 'Root is not a valid name',
        icon: 'warning',
        showCloseButton: true
      });
    }
  };

  const updateDataForm = () => {
    SendPutContainer(containerData, idItem);
    Swal.fire({
      title: 'Container updated',
      icon: 'success',
      showCloseButton: true,
      timer: '2500'
    });
    closeModal();
  };
  const closeDataForm = () => {
    //SendPutContainer(containerData, id);
    closeModal();
  };

  return (
    <Box
      onSubmit={(e) => handleSubmit(e)}
      sx={{ height: '100%', width: '80%', margin: 'auto' }}
    >
      <Grid
        container
        spacing={2}
        sx={{
          '& > .MuiGrid-item': {
            pt: '0px'
          },
          mt: '0px'
        }}
      >
        <Grid item xs={12}>
          <TextField
            margin="normal"
            required
            fullWidth
            id="name"
            label="Container name"
            onChange={(e) =>
              setContainerData({ ...containerData, name: e.target.value })
            }
            name="name"
            defaultValue={name}
          />
        </Grid>
        <Grid item xs={12}>
          <FormControl fullWidth sx={{ mt: '16px' }}>
            <InputLabel id="demo-simple-select-autowidth-label">
              Favorite
            </InputLabel>
            <Select
              labelId="demo-simple-select-autowidth-label"
              id="demo-simple-select-autowidth"
              defaultValue={favorite}
              onChange={(e) =>
                setContainerData({
                  ...containerData,
                  favorite: e.target.value
                })
              }
              label="Favorite"
            >
              <MenuItem value={true}>True</MenuItem>
              <MenuItem value={false}>False</MenuItem>
            </Select>
          </FormControl>
        </Grid>

        <ButtonsCrud
          idItem={idItem}
          addDataForm={addDataForm}
          updateDataForm={updateDataForm}
          closeDataForm={closeDataForm}
          action={action}
        />
      </Grid>
    </Box>
  );
}

export default ContainerForm;
