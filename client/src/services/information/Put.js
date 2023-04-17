export const PutInformation = (idContainer, data, type, idInformation) => {
  const isToken = localStorage.getItem('token');
  const UserId = localStorage.getItem('UserId');
  fetch(
    `http://localhost:5000/api/users/${UserId}/containers/${idContainer}/${type}/${idInformation}`,
    {
      method: 'PUT',
      headers: new Headers({
        Authorization: `Bearer ${isToken}`,
        'Content-Type': 'application/json',
      }),
      body: JSON.stringify(data),
    }
  )
    .then((resp) => resp.json())
    .catch((error) => console.log(error));
};
