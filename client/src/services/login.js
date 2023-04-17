import axios from 'axios';

const authenticateUrl = 'http://localhost:5000/api/Account/authenticate';

const registerUrl = 'http://localhost:5000/api/Account/register';

export const authenticate = async (credentials) => {
  const config = {
    headers: {
      'Content-Type': 'application/json'
    }
  };
  const { data } = await axios.post(authenticateUrl, credentials, config);
  return data;
};

export const register = async (credentials) => {
  const config = {
    headers: {
      'Content-Type': 'application/json'
    }
  };
  const { data } = await axios.post(registerUrl, credentials, config);
  return data;
};
