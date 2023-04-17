import React from 'react';
import Tooltip from '@mui/material/Tooltip';
import IconButton from '@mui/material/IconButton';

function IconNav({ filterSelected, elementActive, element, title, navClick }) {
  return (
    <Tooltip
      title={title}
      enterDelay={500}
      leaveDelay={200}
      placement={title == 'Add' ? 'right' : 'bottom'}
      onClick={(e) => navClick(e, title)}
    >
      <IconButton>
        {filterSelected == title ? elementActive : element}
      </IconButton>
    </Tooltip>
  );
}

export default IconNav;
