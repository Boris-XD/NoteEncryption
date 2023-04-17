import { Box, Grid, TextField } from '@mui/material';
import React, { useState } from 'react';
import ButtonsCrud from './ButtonsCrud';
import InformationForm from './InformationForm';
import ListContext from '@pathListContext';
import { PostInformation } from '@pathPost';
import { PutInformation } from '@pathPut';

function KeysForm({ idItem, data, closeModal, action }) {
  const { encryptionSelected, idContainer } = React.useContext(ListContext);
  const { name, type, favorite, description, tags, encryptionType, serial } =
    data;

  let tagsResponse = '';
  if (action != 'Add') {
    tagsResponse = tags.toString();
  }
  let nameResponse = action == 'Clone' ? `${name} -Clone` : name;

  const [keyData, setKeyData] = useState({
    name: nameResponse || '',
    containerId: idContainer || '',
    type: 'Key',
    favorite: favorite == undefined ? true : favorite,
    description: description || '',
    tags: tagsResponse || '',
    encryptionType: encryptionType || encryptionSelected,
    serial: serial || '',
  });

  const addDataForm = () => {
    PostInformation(idContainer, keyData, 'Key');
    closeModal();
  };
  const updateDataForm = () => {
    PutInformation(idContainer, keyData, 'Key', idItem);
    closeModal();
  };
  const cloneDataForm = () => {
    PostInformation(idContainer, keyData, 'Key');
    closeModal();
  };
  const closeDataForm = () => {
    closeModal();
  };
  const updateInputs = (input) => (e) => {
    setKeyData({ ...keyData, [input]: e.target.value });
  };
  const values = {
    name,
    idContainer,
    type,
    favorite,
    description,
    tags,
    encryptionType,
    serial,
  };

  return (
    <>
      <InformationForm
        type={'Key'}
        nameResponse = {nameResponse}
        values={values}
        updateInputs={updateInputs}
        action={action}
      />
      <Grid item xs={12}>
        <TextField
          margin="normal"
          required
          fullWidth
          id="serial"
          label="Serial:"
          defaultValue={serial}
          onChange={(e) => setKeyData({ ...keyData, serial: e.target.value })}
        />
      </Grid>
      <ButtonsCrud
        idItem={idItem}
        addDataForm={addDataForm}
        updateDataForm={updateDataForm}
        closeDataForm={closeDataForm}
        cloneDataForm={cloneDataForm}
        action={action}
      />
    </>
  );
}

export default KeysForm;
