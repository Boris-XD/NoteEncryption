export const GetShareInformation = () => {
  const isToken = localStorage.getItem('token');
  const UserId = localStorage.getItem('UserId');
  const getData = fetch(`http://localhost:5000/api/users/${UserId}/Shared`, {
    method: 'GET',
    headers: new Headers({
      Authorization: `Bearer ${isToken}`,
      Accept: 'application/json',
    }),
  })
    .then(async (resp) => await resp.json())
    .catch((error) => console.log(error));
  return getData;
};
