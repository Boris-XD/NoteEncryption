import React from 'react';
import LibraryBooksIcon from '@mui/icons-material/LibraryBooks';
import AccountBoxIcon from '@mui/icons-material/AccountBox';
import CreditCardIcon from '@mui/icons-material/CreditCard';
import PhoneIcon from '@mui/icons-material/Phone';
import KeyIcon from '@mui/icons-material/Key';
import IconButton from '@mui/material/IconButton';
import Tooltip from '@mui/material/Tooltip';

function ItemsIcons({ informationType }) {
  const iconType = () => {
    switch (informationType) {
      case 'Key':
        return (
          <Tooltip title="Key" enterDelay={500} leaveDelay={200}>
            <IconButton>
              <KeyIcon />
            </IconButton>
          </Tooltip>
        );
      case 'Credential':
        return (
          <Tooltip title="Credential" enterDelay={500} leaveDelay={200}>
            <IconButton>
              <AccountBoxIcon />
            </IconButton>
          </Tooltip>
        );
      case 'CreditCard':
        return (
          <Tooltip title="CreditCard" enterDelay={500} leaveDelay={200}>
            <IconButton>
              <CreditCardIcon />
            </IconButton>
          </Tooltip>
        );
      case 'Contact':
        return (
          <Tooltip title="Contact" enterDelay={500} leaveDelay={200}>
            <IconButton>
              <PhoneIcon />
            </IconButton>
          </Tooltip>
        );
      case 'Note':
        return (
          <Tooltip title="Note" enterDelay={500} leaveDelay={200}>
            <IconButton>
              <LibraryBooksIcon />
            </IconButton>
          </Tooltip>
        );

      default:
        return <h1>No icon match</h1>;
    }
  };
  return <>{iconType(informationType)}</>;
}

export default ItemsIcons;
