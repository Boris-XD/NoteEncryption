import React, { useContext, useEffect } from 'react';
import { Box } from '@mui/system';
import ShareIcon from '@mui/icons-material/Share';
import EditIcon from '@mui/icons-material/Edit';
import ContentCopyIcon from '@mui/icons-material/ContentCopy';
import DeleteIcon from '@mui/icons-material/Delete';
import MoreHorizIcon from '@mui/icons-material/MoreHoriz';
import IconButton from '@mui/material/IconButton';
import Menu from '@mui/material/Menu';
import MenuItem from '@mui/material/MenuItem';
import MainModal from '../modal/MainModal';
import Modal from '@mui/material/Modal';
import StarIcon from '@mui/icons-material/Star';
import StarBorderIcon from '@mui/icons-material/StarBorder';
import Tooltip from '@mui/material/Tooltip';
import Swal from 'sweetalert2';
import ListContext from '@pathListContext';
import ItemsIcons from './ItemsIcons';
import { GetInformation } from '@pathGet';
import { DeleteInformation } from '@pathDelete';
import { PutInformation } from '@pathPut';

function Item({ data, reRender }) {
  const { informationType, favorite } = data;
  const [anchorEl, setAnchorEl] = React.useState(null);
  const [openMainModal, setOpenMainModal] = React.useState(false);
  const [action, setAction] = React.useState('Show');
  const { idContainer } = useContext(ListContext);
  const [itemInformation, setItemInformation] = React.useState({});
  const open = Boolean(anchorEl);

  const handleClickMore = (event) => {
    event.stopPropagation();
    setAnchorEl(event.currentTarget);
  };
  const handleCloseMore = (e) => {
    e.stopPropagation();
    setAnchorEl(null);
  };
  const handleFavorite = (e, item) => {
    e.stopPropagation();
    const newFavorite = !itemInformation.favorite;
    let tagsResponse = itemInformation.tags.toString();
    item.favorite = newFavorite;
    item.tags = tagsResponse;
    item.containerId = idContainer;
    if (informationType == 'CreditCard') {
      item.cardName = '';
    }
    if (informationType == 'Credential') {
      let urlsResponse = itemInformation.urls.toString();
      item.urls = urlsResponse;
    }
    if (informationType == 'Contact') {
      let emailsResponse = itemInformation.emails.toString();
      let phonesResponse = itemInformation.phones.toString();
      let addressesResponse = itemInformation.addresses.toString();
      item.emails = emailsResponse;
      item.phones = phonesResponse;
      item.addresses = addressesResponse;
    }
    PutInformation(idContainer, item, informationType, data.id);
    setItemInformation({
      ...itemInformation,
      favorite: newFavorite,
    });
    reRender();
  };
  const editItem = () => {
    setAction('Edit');
    setOpenMainModal(true);
  };
  const copyItem = () => {
    setAction('Clone');
    setOpenMainModal(true);
  };
  const shareItem = () => {
    setAction('Share');
    setOpenMainModal(true);
  };
  const removeItem = () => {
    Swal.fire({
      title: 'Are you sure?',
      icon: 'warning',
      showCloseButton: true,
      showConfirmButton: true,
      showDenyButton: true,
      confirmButtonText: 'Deleted',
      denyButtonText: `Cancel`,
    }).then((result) => {
      if (result.isConfirmed) {
        DeleteInformation(idContainer, informationType, data.id);
        Swal.fire('Deleted!', '', 'success');
        reRender();
      } else if (result.isDenied) {
        Swal.fire('Deleted canceled', '', 'info');
      }
    });
  };

  const handleOpenMainModal = () => {
    setAction('Show');
    setOpenMainModal(true);
  };
  const handleCloseMainModal = () => {
    reRender();
    setOpenMainModal(false);
  };
  useEffect(() => {
    GetInformation(idContainer, informationType, data.id).then((data) => {
      setItemInformation(data);
    });
  }, [data]);

  return (
    <>
      <Box
        sx={{
          bgcolor: 'quaternary.light',
          '&:hover': {
            bgcolor: 'primary.main',
          },
          borderRadius: '12px',
          display: 'flex',
          justifyContent: 'space-between',
          alignItems: 'center',
          mt: '30px',
          mb: '30px',
        }}
      >
        <Box
          sx={{
            display: 'flex',
            alignItems: 'center',
            justifyContent: 'space-between',
            width: '100%',
            height: '100%',
            borderRadius: '12px',
            border: '1px solid tertiary.contrastText',
            padding: '0 30px',
          }}
          onClick={handleOpenMainModal}
        >
          <Box
            sx={{
              flex: '0 0 75%',
              pt: '25px',
              pb: '25px',
            }}
          >
            {itemInformation.name}
          </Box>
          <Box
            sx={{
              flex: '0 0 15%',
              flex: '0 0 15%',
              display: 'flex',
              justifyContent: 'space-between',
            }}
          >
            <ItemsIcons informationType={informationType} />
            {itemInformation.favorite ? (
              <Tooltip title="Favorite" enterDelay={500} leaveDelay={200}>
                <IconButton onClick={(e) => handleFavorite(e, itemInformation)}>
                  <StarIcon
                    sx={{
                      color: 'secondary.dark',
                      '&:hover': {
                        color: 'secondary.main',
                      },
                    }}
                  />
                </IconButton>
              </Tooltip>
            ) : (
              <Tooltip title="No favorite" enterDelay={500} leaveDelay={200}>
                <IconButton onClick={(e) => handleFavorite(e, itemInformation)}>
                  <StarBorderIcon
                    sx={{
                      color: 'secondary.dark',
                      '&:hover': {
                        color: 'secondary.main',
                      },
                    }}
                  />
                </IconButton>
              </Tooltip>
            )}
            <Tooltip title="Options" enterDelay={500} disableInteractive>
              <IconButton onClick={handleClickMore}>
                <MoreHorizIcon
                  id="basic-button"
                  aria-controls={open ? 'basic-menu' : undefined}
                  aria-haspopup="true"
                  aria-expanded={open ? 'true' : undefined}
                  sx={{ cursor: 'pointer' }}
                />
              </IconButton>
            </Tooltip>
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
              <Tooltip title="Edit" disableInteractive placement="right">
                <MenuItem onClick={handleCloseMore}>
                  <IconButton onClick={editItem} sx={{ padding: '0px' }}>
                    <EditIcon />
                  </IconButton>
                </MenuItem>
              </Tooltip>
              <Tooltip title="Clone" disableInteractive placement="right">
                <MenuItem onClick={handleCloseMore}>
                  <IconButton onClick={copyItem} sx={{ padding: '0px' }}>
                    <ContentCopyIcon />
                  </IconButton>
                </MenuItem>
              </Tooltip>

              <Tooltip title="Share" disableInteractive placement="right">
                <MenuItem onClick={handleCloseMore}>
                  <IconButton onClick={shareItem} sx={{ padding: '0px' }}>
                    <ShareIcon />
                  </IconButton>
                </MenuItem>
              </Tooltip>

              <Tooltip title="Delete" disableInteractive placement="right">
                <MenuItem onClick={handleCloseMore}>
                  <IconButton onClick={removeItem} sx={{ padding: '0px' }}>
                    <DeleteIcon />
                  </IconButton>
                </MenuItem>
              </Tooltip>
            </Menu>
          </Box>
        </Box>
      </Box>

      <Modal open={openMainModal} onClose={handleCloseMainModal}>
        <Box>
          <MainModal
            data={itemInformation}
            idItem={data.id}
            action={action}
            closeModal={handleCloseMainModal}
            typeSelect={informationType}
          />
        </Box>
      </Modal>
    </>
  );
}

export default Item;
