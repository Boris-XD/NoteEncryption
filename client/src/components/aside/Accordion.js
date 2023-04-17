import React, { useEffect, useState } from 'react';
import ListSubheader from '@mui/material/ListSubheader';
import List from '@mui/material/List';
import ListItemButton from '@mui/material/ListItemButton';
import ListItemIcon from '@mui/material/ListItemIcon';
import ListItemText from '@mui/material/ListItemText';
import Collapse from '@mui/material/Collapse';
import ExpandLess from '@mui/icons-material/ExpandLess';
import ExpandMore from '@mui/icons-material/ExpandMore';
import BrowserNotSupportedIcon from '@mui/icons-material/BrowserNotSupported';
import Crop169Icon from '@mui/icons-material/Crop169';
import Container from './Container';
import fetchContainer from '@pathuseFetch';
import { Tooltip } from '@mui/material';
import { Box } from '@mui/system';
import AddCircleOutlineIcon from '@mui/icons-material/AddCircleOutline';
import ContainerModal from '../modal/ContainerModal';
import IconButton from '@mui/material/IconButton';
import Modal from '@mui/material/Modal';

const iconStyle = {
  fontSize: '30px',
  color: 'secondary.light',
  cursor: 'pointer',
  '&:hover': {
    bgcolor: 'primary.contrastText',
    transform: 'scale(1.5)',
    borderRadius: '12px'
  }
};
function Accordion() {
  const [information, setInformation] = useState([]);
  const [openContainer, setOpenContainer] = React.useState(true);
  const [openNoContainer, setOpenNoContainer] = React.useState(true);
  const [openMainModal, setOpenMainModal] = React.useState(false);
  const [render, setRender] = React.useState(true);
  const [action, setAction] = React.useState('Add');

  const handleClickContainers = () => {
    setOpenContainer(!openContainer);
  };
  const handleClickNoContainers = () => {
    setOpenNoContainer(!openNoContainer);
  };
  const handleOpenMainModal = () => {
    setOpenMainModal(true);
  };
  const handleCloseMainModal = () => {
    setAction('Add');
    setOpenMainModal(false);
    setRender(!render);
  };
  const reRender = () => {
    setRender(!render);
  };

  useEffect(() => {
    const containerList = () => {
      fetchContainer().then((data) => setInformation(data));
    };
    containerList();
  }, [render]);

  function SortArrayName(x, y) {
    if (x.name.toLowerCase() < y.name.toLowerCase()) {
      return -1;
    }
    if (x.name.toLowerCase() > y.name.toLowerCase()) {
      return 1;
    }
    return 0;
  }
  function SortArrayFavorite(x, y) {
    if (x.favorite > y.favorite) {
      return -1;
    }
    if (x.favorite < y.favorite) {
      return 1;
    }
    return 0;
  }
  return (
    <List
      sx={{
        width: '100%',
        bgcolor: 'secondary.main'
      }}
      component="nav"
      aria-labelledby="nested-list-subheader"
      subheader={
        <Box
          sx={{
            width: '100%',
            bgcolor: 'secondary.main',
            pt: '20px',
            pb: '20px',
            display: 'flex',
            justifyContent: 'space-between',
            alignItems: 'center'
          }}
        >
          <Box sx={{ fontSize: '20px', fontWeight: '400' }}>Containers</Box>
          <Tooltip title="Add" enterDelay={500} leaveDelay={200}>
            <IconButton onClick={handleOpenMainModal}>
              <AddCircleOutlineIcon
                title="Add"
                sx={{
                  ...iconStyle,
                  fontSize: '50px'
                }}
              />
            </IconButton>
          </Tooltip>
        </Box>
      }
    >
      <ListItemButton onClick={handleClickNoContainers}>
        <ListItemIcon>
          <BrowserNotSupportedIcon />
        </ListItemIcon>
        <ListItemText primary="No Containers" />
        {openNoContainer ? <ExpandLess /> : <ExpandMore />}
      </ListItemButton>

      <Collapse in={openNoContainer} timeout="auto" unmountOnExit>
        <List component="div" disablePadding>
          {information ? (
            information.map((container) => {
              if (container.name == 'Root') {
                return (
                  <Container
                    data={container}
                    reRender={reRender}
                    key={container.id}
                  />
                );
              }
            })
          ) : (
            <h1>Loading .....</h1>
          )}
        </List>
      </Collapse>

      <ListItemButton onClick={handleClickContainers}>
        <ListItemIcon>
          <Crop169Icon />
        </ListItemIcon>
        <ListItemText primary="Containers" />
        {openContainer ? <ExpandLess /> : <ExpandMore />}
      </ListItemButton>

      <Collapse
        in={openContainer}
        timeout="auto"
        unmountOnExit
        sx={{
          height: 'calc(50vh - 30px + (6vh - 60px))',
          overflow: 'hidden',
          '& > div': {
            height: 'calc(50vh - 30px + (6vh - 60px))'
          }
        }}
      >
        <List
          component="div"
          disablePadding
          sx={{
            height: '100%',
            overflowY: 'auto',

            '&::-webkit-scrollbar': {
              bgcolor: 'secondary.dark',
              borderRadius: '12px'
            },
            '&::-webkit-scrollbar-thumb': {
              bgcolor: 'quaternary.contrastText',
              borderRadius: '12px',
              border: '2px solid #d3928e'
            }
          }}
        >
          {information ? (
            information
              .sort(SortArrayName)
              .sort(SortArrayFavorite)
              .map((container) => {
                if (container.name != 'Root') {
                  return (
                    <Container
                      data={container}
                      reRender={reRender}
                      key={container.id}
                    />
                  );
                }
              })
          ) : (
            <h1>Loading .....</h1>
          )}
        </List>
      </Collapse>
      <Modal open={openMainModal} onClose={handleCloseMainModal}>
        <Box id="ContainerModal">
          <ContainerModal
            name=""
            favorite={true}
            id={null}
            closeModal={handleCloseMainModal}
            action={action}
          />
        </Box>
      </Modal>
    </List>
  );
}
export default Accordion;
