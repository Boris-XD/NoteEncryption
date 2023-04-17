const fetchContainer = async () => {
  const isToken = localStorage.getItem('token');
  const UserId = localStorage.getItem('UserId');
  const getData = await fetch(
    `http://localhost:5000/api/users/${UserId}/Container`,
    {
      method: 'GET',
      headers: new Headers({
        Authorization: `Bearer ${isToken}`,
        Accept: 'application/json',
      }),
    }
  )
    .then(async (resp) => await resp.json())
    .catch((error) => {
      console.log(error);
    });

  return getData;
};

export default fetchContainer;
