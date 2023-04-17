import * as React from 'react';
import Box from '@mui/material/Box';
import ContactsForm from './ContactsForm';
import CreditCardsForm from './CreditCardsForm';
import KeysForm from './KeysForm';
import NotesForm from './NotesForm';
import CredentialsForm from './CredentialsForm';
import { Grid } from '@mui/material';
import ListContext from '@pathListContext';
import ShareForm from './ShareForm';

export default function ContentModal({
  data,
  idItem,
  action,
  closeModal,
  typeSelect,
  itemShare,
}) {
  const { informationType } = data;
  const { idContainer } = React.useContext(ListContext);
  if (action == 'ShowShare') {
    data = itemShare;
  }
  const formType = () => {
    switch (informationType || typeSelect) {
      case 'Note':
        return (
          <NotesForm
            idItem={idItem}
            data={data}
            action={action}
            closeModal={closeModal}
          />
        );
      case 'Credential':
        return (
          <CredentialsForm
            idItem={idItem}
            data={data}
            action={action}
            closeModal={closeModal}
          />
        );
      case 'Key':
        return (
          <KeysForm
            idItem={idItem}
            data={data}
            action={action}
            closeModal={closeModal}
          />
        );
      case 'CreditCard':
        return (
          <CreditCardsForm
            idItem={idItem}
            data={data}
            action={action}
            closeModal={closeModal}
          />
        );
      case 'Contact':
        return (
          <ContactsForm
            idItem={idItem}
            data={data}
            action={action}
            closeModal={closeModal}
          />
        );
      default:
        console.log('This is a form built with React');
    }
  };
  const handleSubmit = () => {};
  return (
    <Box sx={{ width: '100%', typography: 'body1' }}>
      <Box
        component="form"
        onSubmit={handleSubmit}
        sx={{ height: '100%', padding: '20px' }}
      >
        <Grid
          container
          spacing={2}
          sx={{
            '& > .MuiGrid-item': {
              pt: '0px',
            },
          }}
        >
          {action == 'Share' ? (
            <ShareForm
              idItem={idItem}
              data={data}
              action={action}
              closeModal={closeModal}
            />
          ) : (
            formType()
          )}
        </Grid>
      </Box>
    </Box>
  );
}
