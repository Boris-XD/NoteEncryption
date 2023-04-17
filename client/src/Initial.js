import React, { useContext } from 'react';

import { BrowserRouter as Router, useRoutes } from 'react-router-dom';
import Dashboard from './components/dashboard/Dashboard';
import UserContext from './context/UserContext';
import Login from './components/login/Login';
import Settings from './pages/Settings';
import Share from './pages/Share';

function Initial() {
  const { user } = useContext(UserContext);

  if (!user) {
    return <Login />;
  }
  return (
    <Router>
      <Pages />
    </Router>
  );
}
const Pages = () => {
  const routes = useRoutes([
    { path: '/', element: <Dashboard /> },
    { path: '/settings', element: <Settings /> },
    { path: '/share', element: <Share /> },
  ]);

  return routes;
};
export default Initial;
