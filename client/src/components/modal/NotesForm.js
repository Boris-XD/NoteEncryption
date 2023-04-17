import { Grid, TextField } from '@mui/material';
import React, { useState } from 'react';
import ButtonsCrud from './ButtonsCrud';
import InformationForm from './InformationForm';
import ListContext from '@pathListContext';
import { PostInformation } from '@pathPost';
import { PutInformation } from '@pathPut';

function NotesForm({ idItem, data, closeModal, action }) {
  const { encryptionSelected, idContainer } = React.useContext(ListContext);
  const { text, name, tags, favorite, description, type, encryptionType } =
    data;
  let tagsResponse = '';
  if (action != 'Add') {
    tagsResponse = tags.toString();
  }
  let nameResponse = action == 'Clone' ? `${name} -Clone` : name;
  const [noteData, setNoteData] = useState({
    text: text || '',
    containerId: idContainer,
    name: nameResponse || '',
    tags: tagsResponse || '',
    favorite: favorite == undefined ? true : favorite,
    description: description || '',
    type: 'Note',
    encryptionType: encryptionType || encryptionSelected,
  });
  const addDataForm = () => {
    PostInformation(idContainer, noteData, 'Note');
    closeModal();
  };
  const updateDataForm = () => {
    PutInformation(idContainer, noteData, 'Note', idItem);
    closeModal();
  };
  const cloneDataForm = () => {
    PostInformation(idContainer, noteData, 'Note');
    closeModal();
  };
  const closeDataForm = () => {
    closeModal();
  };
  const updateInputs = (input) => (e) => {
    setNoteData({ ...noteData, [input]: e.target.value });
  };
  const values = {
    idContainer,
    description,
    encryptionType,
    favorite,
    name,
    tags,
    text,
    type,
  };
  return (
    <>
      <InformationForm
        type={'Note'}
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
          id="text"
          label="Text:"
          defaultValue={text}
          onChange={(e) => setNoteData({ ...noteData, text: e.target.value })}
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

export default NotesForm;
