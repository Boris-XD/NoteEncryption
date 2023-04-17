import React from 'react';
import { createContext, useState } from 'react';
import { authenticate, register } from '../services/login';
import Swal from 'sweetalert2';

import { SendPostContainer } from '@pathSendPost';
const UserContext = createContext();
const isToken = localStorage.getItem('token');
const InitialUser = isToken == null || isToken.length < 600 ? null : true;

const UserProvider = ({ children }) => {
  const [user, setUser] = useState(InitialUser);

  const login = async ({ email, password }) => {
    try {
      const user = await authenticate({ email, password });
      localStorage.setItem('token', user.token);
      localStorage.setItem('UserId', user.id);
      setUser(true);
    } catch (error) {
      Swal.fire({
        title: 'Access Denied',
        text: 'The Email or Password are incorrect',
        icon: 'error',
        showCloseButton: true,
        timer: '2500',
      });
    }
  };

  const logout = () => {
    setUser(false);
    localStorage.removeItem('token');
    localStorage.removeItem('UserId');
  };

  const signUp = async ({ email, password, fullName, userName }) => {
    try {
      const user = await register({ email, password, fullName, userName });
      localStorage.setItem('token', user.token);
      localStorage.setItem('UserId', user.id);
      SendPostContainer({name: 'Root', favorite: true, userId: user.id});
      setUser(true);
    } catch (error) {
      Swal.fire({
        title: 'Register denied',
        text: 'The Email or User are incorrect',
        icon: 'error',
        showCloseButton: true,
        timer: '2500',
      });
    }
  };

  const data = { user, login, logout, signUp };
  return <UserContext.Provider value={data}>{children}</UserContext.Provider>;
};

export { UserProvider };
export default UserContext;
