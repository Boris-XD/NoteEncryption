import React, { useContext, useState } from 'react';
import { Box } from '@mui/system';
import LibraryBooksIcon from '@mui/icons-material/LibraryBooks';
import AccountBoxIcon from '@mui/icons-material/AccountBox';
import KeyIcon from '@mui/icons-material/Key';
import CreditCardIcon from '@mui/icons-material/CreditCard';
import PhoneIcon from '@mui/icons-material/Phone';
import IconNav from '../navbar/IconNav';
import { IconButton, Menu, MenuItem, Modal, Tooltip } from '@mui/material';
import MainModal from '../modal/MainModal';
import ListContext from '@pathListContext';
import { iconsNavBar } from '../navbar/ListIconsNavbar';
function Navbar() {
  const [openMainModal, setOpenMainModal] = React.useState(false);
  const [anchorEl, setAnchorEl] = React.useState(null);
  const open = Boolean(anchorEl);
  const [typeSelect, setTypeSelect] = React.useState('Note');
  const { addItemselected, filterSelected, selectFilter } =
    useContext(ListContext);
  const navClick = (e, title) => {
    if (title == 'Add') {
      handleClickMore(e);
    } else {
      selectFilter(title);
    }
  };

  const handleClickMore = (event) => {
    event.stopPropagation();
    setAnchorEl(event.currentTarget);
  };
  const handleCloseMore = (e) => {
    e.stopPropagation();
    setAnchorEl(null);
  };
  const handleOpenMainModal = () => {
    setOpenMainModal(true);
  };
  const handleCloseMainModal = () => {
    addItemselected();
    setOpenMainModal(false);
  };

  const noteSelected = () => {
    setTypeSelect('Note');
    handleOpenMainModal();
  };
  const credentialSelected = () => {
    setTypeSelect('Credential');
    handleOpenMainModal();
  };
  const keySelected = () => {
    setTypeSelect('Key');
    handleOpenMainModal();
  };
  const creditCardSelected = () => {
    setTypeSelect('CreditCard');
    handleOpenMainModal();
  };
  const contactSelected = () => {
    setTypeSelect('Contact');
    handleOpenMainModal();
  };

  return (
    <Box
      sx={{
        height: '70px',
        bgcolor: 'quaternary.contrastText',
        position: 'relative',
      }}
    >
      <Box
        sx={{
          width: '80%',
          display: 'flex',
          justifyContent: 'space-between',
          alignItems: 'center',
          margin: 'auto',
          height: '100%',
        }}
      >
        {iconsNavBar.map(({ elementActive, element, title, id }) => (
          <IconNav
            filterSelected={filterSelected}
            elementActive={elementActive}
            element={element}
            title={title}
            key={id}
            navClick={navClick}
          />
        ))}
        <Menu
          id="basic-menu"
          anchorEl={anchorEl}
          open={open}
          onClose={handleCloseMore}
          MenuListProps={{
            'aria-labelledby': 'basic-button',
          }}
          anchorOrigin={{
            vertical: 'bottom',
            horizontal: 'center',
          }}
          transformOrigin={{
            vertical: 'top',
            horizontal: 'center',
          }}
        >
          <Tooltip title="Notes" disableInteractive placement="right">
            <MenuItem onClick={handleCloseMore}>
              <IconButton onClick={noteSelected} sx={{ padding: '0px' }}>
                <LibraryBooksIcon />
              </IconButton>
            </MenuItem>
          </Tooltip>
          <Tooltip title="Credentials" disableInteractive placement="right">
            <MenuItem onClick={handleCloseMore}>
              <IconButton onClick={credentialSelected} sx={{ padding: '0px' }}>
                <AccountBoxIcon />
              </IconButton>
            </MenuItem>
          </Tooltip>

          <Tooltip title="Keys" disableInteractive placement="right">
            <MenuItem onClick={handleCloseMore}>
              <IconButton onClick={keySelected} sx={{ padding: '0px' }}>
                <KeyIcon />
              </IconButton>
            </MenuItem>
          </Tooltip>

          <Tooltip title="CreditCards" disableInteractive placement="right">
            <MenuItem onClick={handleCloseMore}>
              <IconButton onClick={creditCardSelected} sx={{ padding: '0px' }}>
                <CreditCardIcon />
              </IconButton>
            </MenuItem>
          </Tooltip>
          <Tooltip title="Contacts" disableInteractive placement="right">
            <MenuItem onClick={handleCloseMore}>
              <IconButton onClick={contactSelected} sx={{ padding: '0px' }}>
                <PhoneIcon />
              </IconButton>
            </MenuItem>
          </Tooltip>
        </Menu>
      </Box>

      <Modal open={openMainModal} onClose={handleCloseMainModal}>
        <Box>
          <MainModal
            data={[]}
            action="Add"
            closeModal={handleCloseMainModal}
            typeSelect={typeSelect}
          />
        </Box>
      </Modal>
    </Box>
  );
}

export default Navbar;
