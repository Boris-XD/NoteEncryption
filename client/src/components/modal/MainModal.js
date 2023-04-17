import * as React from 'react';
import Box from '@mui/material/Box';
import ContentModal from './ContentModal';
import ListContext from '../../context/ListContext';
import { GetInformation } from '../../services/information/Get';
const style = {
  position: 'absolute',
  top: '50%',
  left: '50%',
  transform: 'translate(-50%, -50%)',
  width: '65%',
  bgcolor: 'background.paper',
  border: '3px solid quaternary.dark',
  boxShadow: 24,
  bgcolor: 'primary.light',
};

export default function MainModal({
  data,
  idItem,
  action,
  closeModal,
  typeSelect,
}) {
  const [itemShare, setItemShare] = React.useState('');
  React.useEffect(() => {
    const getItem = () => {
      GetInformation(idItem, typeSelect, idItem).then((data) => {
        setItemShare(data);
      });
    };
    getItem();
  }, []);
  return (
    <Box sx={style} id='ModalMain'>
      <Box
        sx={{
          width: '100%',
          bgcolor: 'secondary.main',
          fontSize: '30px',
          display: 'flex',
          justifyContent: 'center',
          borderBotton: '3px solid quaternary.dark',
          color: 'secondary.light',
        }}
      >
        {action.toUpperCase()}
      </Box>
      <Box
        sx={{
          width: '100%',
          bgcolor: 'primary.light',
          overflowY: 'auto',
          maxHeight: '70vh',
        }}
      >
        {action != 'ShowShare' ? (
          <ContentModal
            data={data}
            idItem={idItem}
            action={action}
            closeModal={closeModal}
            typeSelect={typeSelect}
          />
        ) : (
          itemShare && (
            <ContentModal
              data={data}
              idItem={idItem}
              action={action}
              closeModal={closeModal}
              typeSelect={typeSelect}
              itemShare={itemShare}
            />
          )
        )}
      </Box>
    </Box>
  );
}
