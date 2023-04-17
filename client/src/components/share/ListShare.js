import { Box } from '@mui/material';
import React, { useEffect, useState } from 'react';
import Pagination from '../helpers/Pagination';
import ItemShare from '../list/ItemShare';
import { GetShareInformation } from '../../services/information/GetShare';
import ListContext from '@pathListContext';

function ListShare() {
  const [information, setInformation] = useState([]);
  const [currentPage, setCurrentPage] = useState(1);
  const [postsPerPage, setPostsPerPage] = useState(4);
  const indexOfLastPost = currentPage * postsPerPage;
  const indexOfFirstPost = indexOfLastPost - postsPerPage;
  const { filterSelectedShare } = React.useContext(ListContext);

  let listfilter = [];
  if (filterSelectedShare == 'All') {
    listfilter = information && information;
  } else if (filterSelectedShare == 'Notes') {
    listfilter =
      information &&
      information.filter(function (el) {
        return el.informationType == 'Note';
      });
  } else if (filterSelectedShare == 'Credentials') {
    listfilter =
      information &&
      information.filter(function (el) {
        return el.informationType == 'Credential';
      });
  } else if (filterSelectedShare == 'Keys') {
    listfilter =
      information &&
      information.filter(function (el) {
        return el.informationType == 'Key';
      });
  } else if (filterSelectedShare == 'CreditCards') {
    listfilter =
      information &&
      information.filter(function (el) {
        return el.informationType == 'CreditCard';
      });
  } else if (filterSelectedShare == 'Contacts') {
    listfilter =
      information &&
      information.filter(function (el) {
        return el.informationType == 'Contact';
      });
  } else if (filterSelectedShare == 'Favorites') {
    listfilter =
      information &&
      information.filter(function (el) {
        return el.favorite == true;
      });
  }

  const currentPosts =
    listfilter &&
    listfilter
      .sort(SortArrayName)
      .sort(SortArrayFavorite)
      .slice(indexOfFirstPost, indexOfLastPost);

  const paginate = (pageNumber) => {
    setCurrentPage(pageNumber + 1);
  };

  useEffect(() => {
    const ShareList = () => {
      GetShareInformation().then((data) => {
        setInformation(data.informations);
      });
    };
    ShareList();
  }, []);

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
    <Box sx={{ width: '45%', margin: 'auto' }}>
      <Box>
        {currentPosts.map((item) => (
          <ItemShare data={item} key={item.informationId} />
        ))}
      </Box>
      <Pagination
        postsPerPage={postsPerPage}
        totalPosts={information.length}
        paginate={paginate}
      />
    </Box>
  );
}

export default ListShare;
