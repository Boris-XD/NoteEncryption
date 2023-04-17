import { Box, Button, Grid, TextField } from '@mui/material';
import React, { useState } from 'react';
import ButtonsCrud from './ButtonsCrud';
import InformationForm from './InformationForm';
import ListContext from '@pathListContext';
import { PostInformation } from '@pathPost';
import { PutInformation } from '@pathPut';

function CreditCardsForm({ idItem, data, closeModal, action }) {
  const { encryptionSelected, idContainer } = React.useContext(ListContext);
  const {
    name,
    type,
    favorite,
    description,
    tags,
    encryptionType,
    number,
    issuer,
    cardName,
    expiration,
    cvv,
  } = data;

  let tagsResponse = '';
  let expirationResponse = '';
  if (action != 'Add') {
    tagsResponse = tags.toString();
    let expirationResponseFormat = expiration.split('T');
    expirationResponse = expirationResponseFormat[0];
  }
  let nameResponse = action == 'Clone' ? `${name} -Clone` : name;

  const [creditCardData, setCreditCardData] = useState({
    name: nameResponse || '',
    containerId: idContainer || '',
    type: 'CreditCard',
    favorite: favorite == undefined ? true : favorite,
    description: description || '',
    tags: tagsResponse || '',
    encryptionType: encryptionType || encryptionSelected,
    number: number || '',
    issuer: issuer || '',
    cardName: cardName || '',
    expiration: expirationResponse || '',
    cvv: cvv || '',
  });
  const addDataForm = () => {
    PostInformation(idContainer, creditCardData, 'CreditCard');
    closeModal();
  };
  const updateDataForm = () => {
    PutInformation(idContainer, creditCardData, 'CreditCard', idItem);
    closeModal();
  };
  const cloneDataForm = () => {
    PostInformation(idContainer, creditCardData, 'CreditCard');
    closeModal();
  };
  const closeDataForm = () => {    
    closeModal();
  };
  const updateInputs = (input) => (e) => {
    setCreditCardData({ ...creditCardData, [input]: e.target.value });
  };
  const values = {
    name,
    idContainer,
    type,
    favorite,
    description,
    tags,
    encryptionType,
    number,
    issuer,
    cardName,
    expiration,
    cvv,
  };
  return (
    <>
      <InformationForm
        type={'CreditCard'}
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
          id="Number"
          label="Number:"
          defaultValue={number}
          onChange={(e) =>
            setCreditCardData({ ...creditCardData, number: e.target.value })
          }
        />
      </Grid>
      <Grid item xs={6}>
        <TextField
          margin="normal"
          required
          fullWidth
          id="issuer"
          label="Issuer:"
          defaultValue={issuer}
          onChange={(e) =>
            setCreditCardData({ ...creditCardData, issuer: e.target.value })
          }
        />
      </Grid>
      <Grid item xs={6}>
        <TextField
          margin="normal"
          required
          fullWidth
          id="expiration"
          label="Expiration:"
          defaultValue={expirationResponse}
          onChange={(e) =>
            setCreditCardData({
              ...creditCardData,
              expiration: e.target.value,
            })
          }
          type="date"
          InputLabelProps={{
            shrink: true,
          }}
        />
      </Grid>
      <Grid item xs={6}>
        <TextField
          margin="normal"
          required
          fullWidth
          id="cvv"
          label="Cvv:"
          defaultValue={cvv}
          onChange={(e) =>
            setCreditCardData({ ...creditCardData, cvv: e.target.value })
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

export default CreditCardsForm;
