import React, { useContext, useState } from 'react';
import { Box } from '@mui/system';
import IconNav from '../navbar/IconNav';
import { iconsShareNavbar } from '../navbar/ListIconsNavbar';
import ListContext from '@pathListContext';

function NavbarShare() {
  const { selectFilterShare, filterSelectedShare } = useContext(ListContext);
  const navClick = (e, title) => {
    selectFilterShare(title);
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
          width: '90%',
          display: 'flex',
          justifyContent: 'space-around',
          alignItems: 'center',
          margin: 'auto',
          height: '100%',
        }}
      >
        {iconsShareNavbar.map(({ elementActive, element, title, id }) => (
          <IconNav
            filterSelectedShare={filterSelectedShare}
            elementActive={elementActive}
            element={element}
            title={title}
            key={id}
            navClick={navClick}
          />
        ))}
      </Box>
    </Box>
  );
}

export default NavbarShare;
