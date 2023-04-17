import React from 'react';
import Initial from './Initial';
import { ThemeProvider } from '@mui/material/styles';
import CreateTheme from './styles';
import CssBaseline from '@mui/material/CssBaseline';
import { UserProvider } from './context/UserContext';
import { ListProvider } from './context/ListContext';

function App() {
  return (
    <React.StrictMode>
      <ThemeProvider theme={CreateTheme}>
        <UserProvider>
          <ListProvider>
            <CssBaseline />
            <Initial />
          </ListProvider>
        </UserProvider>
      </ThemeProvider>
    </React.StrictMode>
  );
}

export default App;
