import React, { useContext, useEffect } from 'react';
import { Box } from '@mui/system';
import MoreHorizIcon from '@mui/icons-material/MoreHoriz';
import StarIcon from '@mui/icons-material/Star';
import StarBorderIcon from '@mui/icons-material/StarBorder';
import Tooltip from '@mui/material/Tooltip';
import IconButton from '@mui/material/IconButton';
import EditIcon from '@mui/icons-material/Edit';
import DeleteIcon from '@mui/icons-material/Delete';
import { Menu, MenuItem } from '@mui/material';
import { SendPutContainer } from '@pathSendPut';
import { SendDelete } from '@pathSendDelete';
import Modal from '@mui/material/Modal';
import ContainerModal from '../modal/ContainerModal';
import Swal from 'sweetalert2';
import ListContext from '@pathListContext';

function Container({ data, reRender }) {
  const { name, id, favorite } = data;
  const {
    nameContainer,
    selectContainerName,
    idRootContainer,
    rootIdContainer,
    selectContainer,
    SearchList,
  } = useContext(ListContext);
  const [anchorEl, setAnchorEl] = React.useState(null);
  const [isFavorite, setIsFavorite] = React.useState(favorite);
  const UserId = localStorage.getItem('UserId');
  const [dataContainer, SetDataContainer] = React.useState({
    name: name,
    favorite: favorite,
    userId: UserId,
  });
  const [action, setAction] = React.useState('Show');
  const [openMainModal, setOpenMainModal] = React.useState(false);
  const open = Boolean(anchorEl);

  const handleCloseMainModal = () => {
    setOpenMainModal(false);
    reRender();
  };
  const handleClickMore = (event) => {
    event.stopPropagation();
    setAnchorEl(event.currentTarget);
  };
  const handleCloseMore = (e) => {
    e.stopPropagation();
    setAnchorEl(null);
  };

  const handleFavorite = (event) => {
    event.stopPropagation();
    setIsFavorite(!isFavorite);
    reRender();
    SendPutContainer({ ...dataContainer, favorite: !favorite }, id);
  };

  const handleChangeNameItem = () => {
    setAction('Edit');
    setOpenMainModal(true);
  };
  const handleRemoveItem = () => {
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
        SendDelete(id);
        Swal.fire('Deleted!', '', 'success');
        selectContainer(idRootContainer);
        selectContainerName('Root');
        reRender();
      } else if (result.isDenied) {
        Swal.fire('Deleted canceled', '', 'info');
      }
    });
  };
  useEffect(() => {
    if (name == 'Root') {
      rootIdContainer(id);
    }
  }, []);
  const handleSelectContainer = () => {
    selectContainer(id);
    selectContainerName(name);
    SearchList('');
    const formSearch = document.querySelector('#FormSearchInput');
    formSearch.value = '';
  };
  return (
    <Box
      sx={
        name == nameContainer
          ? {
              bgcolor: 'primary.main',
              display: 'flex',
              justifyContent: 'space-between',
              alignItems: 'center',
              height: '40px',
              width: '100%',
              mt: '10px',
              padding: '30px 20px',
            }
          : {
              bgcolor: 'quaternary.light',
              '&:hover': {
                bgcolor: 'primary.main',
              },
              display: 'flex',
              justifyContent: 'space-between',
              alignItems: 'center',
              height: '40px',
              width: '100%',
              mt: '10px',
              padding: '30px 20px',
            }
      }
      onClick={handleSelectContainer}
    >
      <Box
        sx={{
          overflow: 'hidden',
          whiteSpace: 'nowrap',
          maxWidth: '16ch',
        }}
      >
        {name}
      </Box>
      {name != 'Root' && (
        <Box sx={{ display: 'flex', columnGap: '15px' }}>
          {favorite ? (
            <Tooltip title='No favorite' enterDelay={500} leaveDelay={200}>
              <IconButton onClick={handleFavorite}>
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
            <Tooltip title='No favorite' enterDelay={500} leaveDelay={200}>
              <IconButton onClick={handleFavorite}>
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
          <Tooltip title='Options' enterDelay={500} disableInteractive>
            <IconButton onClick={handleClickMore}>
              <MoreHorizIcon
                id='basic-button'
                aria-controls={open ? 'basic-menu' : undefined}
                aria-haspopup='true'
                aria-expanded={open ? 'true' : undefined}
                sx={{ cursor: 'pointer' }}
              />
            </IconButton>
          </Tooltip>
          <Menu
            id='basic-menu'
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
            <Tooltip title='Edit' placement='right' disableInteractive>
              <MenuItem onClick={handleCloseMore}>
                <IconButton
                  onClick={handleChangeNameItem}
                  sx={{ padding: '0px' }}
                >
                  <EditIcon />
                </IconButton>
              </MenuItem>
            </Tooltip>
            <Tooltip title='Delete' placement='right' disableInteractive>
              <MenuItem onClick={handleCloseMore}>
                <IconButton onClick={handleRemoveItem} sx={{ padding: '0px' }}>
                  <DeleteIcon />
                </IconButton>
              </MenuItem>
            </Tooltip>
          </Menu>
        </Box>
      )}
      <Modal open={openMainModal} onClose={handleCloseMainModal}>
        <Box>
          <ContainerModal
            name={name}
            favorite={favorite}
            idItem={id}
            closeModal={handleCloseMainModal}
            action={action}
          />
        </Box>
      </Modal>
    </Box>
  );
}

export default Container;
