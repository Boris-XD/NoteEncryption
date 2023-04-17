import React from 'react';
import TablePagination from '@mui/material/TablePagination';

function Pagination({
  postsPerPage,
  totalPosts,
  paginate,
  numberPostsPerPage,
}) {
  const pageNumbers = [];
  for (let i = 0; i <= Math.ceil(totalPosts / postsPerPage); i++) {
    pageNumbers.push(i);
  }
  const [page, setPage] = React.useState(0);
  const [rowsPerPage, setRowsPerPage] = React.useState(postsPerPage);

  const handleChangePage = (event, newPage) => {
    setPage(newPage);
    paginate(newPage);
  };
  const handleChangeRowsPerPage = (event) => {
    setRowsPerPage(parseInt(event.target.value, 10));
    setPage(0);
    numberPostsPerPage(parseInt(event.target.value, 10));
  };

  return (
    <TablePagination
      component="div"
      count={totalPosts}
      page={page}
      onPageChange={handleChangePage}
      rowsPerPage={rowsPerPage}
      rowsPerPageOptions={[4, 6, 8]}
      onRowsPerPageChange={handleChangeRowsPerPage}
    />
  );
}
export default Pagination;
