import {
  FormControl,
  Grid,
  InputLabel,
  MenuItem,
  Select,
  TextField,
} from '@mui/material';
import React, { useContext, useState } from 'react';
import ListContext from '@pathListContext';

function InformationForm({ type, nameResponse,values, updateInputs, action }) {
  const { nameContainer, encryptionSelected } = useContext(ListContext);
  const encryptionType =
    values.encryptionType == undefined
      ? encryptionSelected
      : values.encryptionType;
  const favoriteSelect = values.favorite == undefined ? true : values.favorite;
  return (
    <>
      <Grid item xs={6}>
        <TextField
          margin="normal"
          required
          fullWidth
          id="name"
          label="Name :"
          defaultValue={nameResponse}
          onChange={updateInputs('name')}
        />
      </Grid>
      {action != 'ShowShare' ? (
        <Grid item xs={6}>
          <TextField
            margin="normal"
            required
            fullWidth
            id="container"
            label="Container:"
            value={nameContainer}
          />
        </Grid>
      ) : (
        ''
      )}
      <Grid item xs={action != 'ShowShare' ? 4 : 6}>
        <TextField
          margin="normal"
          required
          fullWidth
          id="type"
          label="Type:"
          value={type}
          onChange={updateInputs('type')}
        />
      </Grid>
      <Grid item xs={8}>
        <TextField
          margin="normal"
          required
          fullWidth
          id="description"
          label="Description:"
          defaultValue={values.description}
          onChange={updateInputs('description')}
        />
      </Grid>
      {action != 'ShowShare' ? (
        <Grid item xs={3}>
          <FormControl fullWidth sx={{ mt: '16px' }}>
            <InputLabel id="demo-simple-select-autowidth-label">
              Favorite
            </InputLabel>
            <Select
              labelId="demo-simple-select-autowidth-label"
              id="demo-simple-select-autowidth"
              defaultValue={favoriteSelect}
              label="Favorite"
              onChange={updateInputs('favorite')}
            >
              <MenuItem value={true}>True</MenuItem>
              <MenuItem value={false}>False</MenuItem>
            </Select>
          </FormControl>
        </Grid>
      ) : (
        ''
      )}
      <Grid item xs={action != 'ShowShare' ? 3 : 4}>
        <FormControl fullWidth sx={{ mt: '16px' }}>
          <InputLabel id="typeencryption-label">Type Encryption</InputLabel>
          <Select
            labelId="typeencryption-label"
            id="typeencryption"
            defaultValue={encryptionType}
            label="Type Encryption"
            onChange={updateInputs('encryptionType')}
          >
            <MenuItem value={'Binary'}>Binary</MenuItem>
            <MenuItem value={'Base64'}>Base64</MenuItem>
            <MenuItem value={'Hex'}>Hex</MenuItem>
            <MenuItem value={'Aes'}>Aes</MenuItem>
          </Select>
        </FormControl>
      </Grid>
      <Grid item xs={action != 'ShowShare' ? 6 : 12}>
        <TextField
          margin="normal"
          required
          fullWidth
          id="tags"
          label="Tags:"
          defaultValue={values.tags}
          onChange={updateInputs('tags')}
        />
      </Grid>
    </>
  );
}

export default InformationForm;
