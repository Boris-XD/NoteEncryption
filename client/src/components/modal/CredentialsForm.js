import { Box, Grid, TextField } from '@mui/material';
import React, { useState } from 'react';
import ButtonsCrud from './ButtonsCrud';
import InformationForm from './InformationForm';
import ListContext from '@pathListContext';
import { PostInformation } from '@pathPost';
import { PutInformation } from '@pathPut';

function CredentialsForm({ idItem, data, closeModal, action }) {
  const { encryptionSelected, idContainer } = React.useContext(ListContext);
  const {
    name,
    type,
    favorite,
    description,
    tags,
    encryptionType,
    username,
    password,
    urls,
  } = data;
  let tagsResponse = '';
  let urlsResponse = '';
  if (action != 'Add') {
    tagsResponse = tags.toString();
    urlsResponse = urls.toString();
  }
  let nameResponse = action == 'Clone' ? `${name} -Clone` : name;
  const [credentialData, setCredentialData] = useState({
    name: nameResponse || '',
    containerId: idContainer || '',
    type: 'Credential',
    favorite: favorite == undefined ? true : favorite,
    description: description || '',
    tags: tagsResponse || '',
    encryptionType: encryptionType || encryptionSelected,
    username: username || '',
    password: password || '',
    urls: urlsResponse || '',
  });

  const addDataForm = () => {
    PostInformation(idContainer, credentialData, 'Credential');
    closeModal();
  };
  const updateDataForm = () => {
    PutInformation(idContainer, credentialData, 'Credential', idItem);
    closeModal();
  };
  const cloneDataForm = () => {
    PostInformation(idContainer, credentialData, 'Credential');
    closeModal();
  };
  const closeDataForm = () => {
    //SendPutContainer(containerData, id);
    closeModal();
  };
  const updateInputs = (input) => (e) => {
    setCredentialData({ ...credentialData, [input]: e.target.value });
  };
  const values = {
    name,
    idContainer,
    type,
    favorite,
    description,
    tags,
    encryptionType,
    username,
    password,
    urls,
  };
  return (
    <>
      <InformationForm
        type={'Credential'}
        nameResponse = {nameResponse}
        values={values}
        updateInputs={updateInputs}
        action={action}
      />
      <Grid item xs={6}>
        <TextField
          margin="normal"
          required
          fullWidth
          id="username"
          label="UserName:"
          defaultValue={username}
          onChange={(e) =>
            setCredentialData({ ...credentialData, username: e.target.value })
          }
        />
      </Grid>
      <Grid item xs={6}>
        <TextField
          margin="normal"
          required
          fullWidth
          id="password"
          label="Password:"
          defaultValue={password}
          onChange={(e) =>
            setCredentialData({
              ...credentialData,
              password: e.target.value,
            })
          }
        />
      </Grid>
      <Grid item xs={12}>
        <TextField
          margin="normal"
          required
          fullWidth
          id="urls"
          label="Urls:"
          defaultValue={urlsResponse}
          onChange={(e) =>
            setCredentialData({
              ...credentialData,
              urls: e.target.value,
            })
          }
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

export default CredentialsForm;
