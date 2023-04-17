import React from 'react';
import ReplyIcon from '@mui/icons-material/Reply';
import Tooltip from '@mui/material/Tooltip';
import { Box, IconButton, Modal } from '@mui/material';
import GroupIcon from '@mui/icons-material/Group';
import MainModal from '../modal/MainModal';
import ItemsIcons from './ItemsIcons';
import DeleteIcon from '@mui/icons-material/Delete';
import Swal from 'sweetalert2';

function ItemShare({ data }) {
  const [openMainModal, setOpenMainModal] = React.useState(false);
  const [action, setAction] = React.useState('Show');
  const handleOpenMainModal = () => {
    setAction('ShowShare');
    setOpenMainModal(true);
  };
  const handleCloseMainModal = () => {
    setOpenMainModal(false);
  };
  const removeItem = (e) => {
    e.stopPropagation();
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
  return (
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
            flex: '0 0 70%',
            pt: '25px',
            pb: '25px',
          }}
        >
          {data.name}
        </Box>
        <Box
          sx={{
            flex: '0 0 25%',
            display: 'flex',
            justifyContent: 'space-between',
          }}
        >
          <ItemsIcons informationType={data.informationType} />
          <Tooltip
            title={data.username}
            enterDelay={500}
            leaveDelay={200}
            placement="bottom"
          >
            <IconButton>
              <ReplyIcon />
              <GroupIcon fontSize="large" />
            </IconButton>
          </Tooltip>
          <Tooltip title="Delete" disableInteractive placement="right">
            <IconButton onClick={removeItem} sx={{ padding: '0px' }}>
              <DeleteIcon />
            </IconButton>
          </Tooltip>
        </Box>
      </Box>
      <Modal open={openMainModal} onClose={handleCloseMainModal}>
        <Box>
          <MainModal
            data=""
            idItem={data.informationId}
            action={action}
            closeModal={handleCloseMainModal}
            typeSelect={data.informationType}
          />
        </Box>
      </Modal>
    </Box>
  );
}

export default ItemShare;
