import { Grid, TextField } from '@mui/material';
import React, { useState } from 'react';
import ButtonsCrud from './ButtonsCrud';
import InformationForm from './InformationForm';
import ListContext from '@pathListContext';
import { PostInformation } from '@pathPost';
import { PutInformation } from '@pathPut';
import { validateEmail, validateDate } from '../../helpers/validateForms';
import Swal from 'sweetalert2';

function ContactsForm({ idItem, data, closeModal, action }) {
  const { encryptionSelected, idContainer } = React.useContext(ListContext);
  const {
    name,
    type,
    favorite,
    description,
    tags,
    encryptionType,
    fullName,
    firstName,
    lastName,
    business,
    country,
    state,
    zip,
    birthday,
    phones,
    emails,
    addresses,
  } = data;

  let tagsResponse = '';
  let emailsResponse = '';
  let phonesResponse = '';
  let addressesResponse = '';
  let birthdayResponse = '';
  if (action != 'Add') {
    tagsResponse = tags.toString();
    emailsResponse = emails.toString();
    phonesResponse = phones.toString();
    addressesResponse = addresses.toString();
    let birthdayResponseFormat = birthday.split('T');
    birthdayResponse = birthdayResponseFormat[0];
  }
  let nameResponse = action == 'Clone' ? `${name} -Clone` : name;
  const [contactData, setContactData] = useState({
    name: nameResponse || '',
    containerId: idContainer || '',
    type: 'Contact',
    favorite: favorite == undefined ? true : favorite,
    description: description || '',
    tags: tagsResponse || '',
    encryptionType: encryptionType || encryptionSelected,
    fullName: fullName || '',
    firstName: firstName || '',
    lastName: lastName || '',
    business: business || '',
    country: country || '',
    state: state || '',
    zip: zip || '',
    birthday: birthdayResponse || '',
    phones: phonesResponse || '',
    emails: emailsResponse || '',
    addresses: addressesResponse || '',
  });
  const addDataForm = () => {
    let validate = validateEmail(contactData.emails);
    let validateD = validateDate(contactData.birthday);
    if (!validate || !validateD) {
      Swal.fire({
        target: document.getElementById('ModalMain'),
        title: 'Register denied',
        text: 'The Email is wrong or The Date is not selected',
        icon: 'error',
        showCloseButton: true,
      });
    } else {
      PostInformation(idContainer, contactData, 'Contact');
      closeModal();
    }
  };
  const updateDataForm = () => {
    PutInformation(idContainer, contactData, 'Contact', idItem);
    closeModal();
  };
  const cloneDataForm = () => {
    PostInformation(idContainer, contactData, 'Contact');
    closeModal();
  };
  const closeDataForm = () => {    
    closeModal();
  };
  const updateInputs = (input) => (e) => {
    setContactData({ ...contactData, [input]: e.target.value });
  };
  const values = {
    name,
    idContainer,
    type,
    favorite,
    description,
    tags,
    encryptionType,
    fullName,
    firstName,
    lastName,
    business,
    country,
    state,
    zip,
    birthday,
    phones,
    emails,
    addresses,
  };
  return (
    <>
      <InformationForm
        type={'Contact'}
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
          id="fullName"
          label="FullName"
          defaultValue={fullName}
          onChange={(e) =>
            setContactData({ ...contactData, fullName: e.target.value })
          }
        />
      </Grid>
      <Grid item xs={3}>
        <TextField
          margin="normal"
          required
          fullWidth
          id="firstName"
          label="FirstName"
          defaultValue={firstName}
          onChange={(e) =>
            setContactData({ ...contactData, firstName: e.target.value })
          }
        />
      </Grid>
      <Grid item xs={3}>
        <TextField
          margin="normal"
          required
          fullWidth
          id="lastName"
          label="LastName"
          defaultValue={lastName}
          onChange={(e) =>
            setContactData({ ...contactData, lastName: e.target.value })
          }
        />
      </Grid>
      <Grid item xs={4}>
        <TextField
          margin="normal"
          required
          fullWidth
          id="business"
          label="Business"
          defaultValue={business}
          onChange={(e) =>
            setContactData({ ...contactData, business: e.target.value })
          }
        />
      </Grid>
      <Grid item xs={4}>
        <TextField
          margin="normal"
          required
          fullWidth
          id="country"
          label="Country"
          defaultValue={country}
          onChange={(e) =>
            setContactData({ ...contactData, country: e.target.value })
          }
        />
      </Grid>
      <Grid item xs={4}>
        <TextField
          margin="normal"
          required
          fullWidth
          id="state"
          label="State"
          defaultValue={state}
          onChange={(e) =>
            setContactData({ ...contactData, state: e.target.value })
          }
        />
      </Grid>
      <Grid item xs={4}>
        <TextField
          margin="normal"
          required
          fullWidth
          id="zip"
          label="Zip"
          defaultValue={zip}
          onChange={(e) =>
            setContactData({ ...contactData, zip: e.target.value })
          }
        />
      </Grid>
      <Grid item xs={4}>
        <TextField
          margin="normal"
          required
          fullWidth
          id="birthday"
          label="Birthday"
          defaultValue={birthdayResponse}
          onChange={(e) =>
            setContactData({ ...contactData, birthday: e.target.value })
          }
          type="date"
          InputLabelProps={{
            shrink: true,
          }}
        />
      </Grid>
      <Grid item xs={4}>
        <TextField
          margin="normal"
          required
          fullWidth
          id="phones"
          label="phones"
          defaultValue={phones}
          onChange={(e) =>
            setContactData({ ...contactData, phones: e.target.value })
          }
        />
      </Grid>
      <Grid item xs={6}>
        <TextField
          margin="normal"
          required
          fullWidth
          id="emails"
          label="Emails"
          defaultValue={emails}
          onChange={(e) =>
            setContactData({ ...contactData, emails: e.target.value })
          }
        />
      </Grid>
      <Grid item xs={6}>
        <TextField
          margin="normal"
          required
          fullWidth
          id="address"
          label="Address"
          defaultValue={addresses}
          onChange={(e) =>
            setContactData({ ...contactData, addresses: e.target.value })
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

export default ContactsForm;
