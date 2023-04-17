export const ShareInformation = (data, ItemId) => {
  const isToken = localStorage.getItem('token');
  const UserId = localStorage.getItem('UserId');
  fetch(`http://localhost:5000/api/users/${UserId}/Shared/items/${ItemId}`, {
    method: 'POST',
    headers: new Headers({
      Authorization: `Bearer ${isToken}`,
      Accept: 'application/json',
      'Content-Type': 'application/json',
    }),
    body: JSON.stringify(data),
  })
    .then((resp) => resp.json())
    .catch((error) => {
      console.log(error);
    });
};
