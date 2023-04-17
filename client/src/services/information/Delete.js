export const DeleteInformation = (idContainer, type, idInformation) => {
  const isToken = localStorage.getItem('token');
  const UserId = localStorage.getItem('UserId');
  fetch(
    `http://localhost:5000/api/users/${UserId}/containers/${idContainer}/${type}/${idInformation}`,
    {
      method: 'DELETE',
      headers: new Headers({
        Authorization: `Bearer ${isToken}`,
        Accept: 'application/json',
        'Content-Type': 'application/json',
      }),
    }
  )
    .then((resp) => resp.json())
    .catch((error) => console.log(error));
};
