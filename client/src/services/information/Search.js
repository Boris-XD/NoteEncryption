export const GetItemsSearches = async (value) => {
  const isToken = localStorage.getItem('token');
  const UserId = localStorage.getItem('UserId');

  const getData = await fetch(
    `http://localhost:5000/api/users/${UserId}/information/searchTerm?searchTerm=${value}`,
    {
      method: 'GET',
      headers: new Headers({
        Authorization: `Bearer ${isToken}`,
        Accept: 'application/json',
      }),
    }
  )
    .then(async (resp) => await resp.json())
    .catch((error) => console.log(error));

  return getData;
};
