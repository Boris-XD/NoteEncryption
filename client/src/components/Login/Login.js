import * as React from 'react';
import { useContext, useState } from 'react';
import Avatar from '@mui/material/Avatar';
import Button from '@mui/material/Button';
import CssBaseline from '@mui/material/CssBaseline';
import TextField from '@mui/material/TextField';
import Link from '@mui/material/Link';
import Box from '@mui/material/Box';
import Grid from '@mui/material/Grid';
import LockOutlinedIcon from '@mui/icons-material/LockOutlined';
import Typography from '@mui/material/Typography';
import Container from '@mui/material/Container';
import { ThemeProvider } from '@mui/material/styles';
import CreateTheme from '@pathstylesindex';
import UserContext from '@pathUserContext';
import { validateBothPasswords } from '@pathvalidatePassword';
import Swal from 'sweetalert2';

function Copyright(props) {
  return (
    <Typography
      variant="body2"
      color="text.secondary"
      align="center"
      {...props}
    >
      {'Copyright © '}
      <Link color="tertiary.main" href="https://mui.com/">
        Security4You
      </Link>{' '}
      {new Date().getFullYear()}
      {'.'}
    </Typography>
  );
}

function Login() {
  const [account, setAccount] = useState({
    email: '',
    password: '',
    userName: '',
    password2: '',
    fullName: '',
  });

  const [signin, setSignin] = useState(true);
  const { login, signUp } = useContext(UserContext);

  const handleSubmit = async (event) => {
    event.preventDefault();
    if (signin) {
      login(account);
    } else {
      const isValidPassword = validateBothPasswords({
        password: account.password,
        password2: account.password2,
      });
      isValidPassword === 'ok'
        ? signUp(account)
        : Swal.fire({
            title: isValidPassword,
            icon: 'error',
            showCloseButton: true,
            timer: '2500',
          });
    }
  };
  return (
    <ThemeProvider theme={CreateTheme}>
      <Container component="main" maxWidth="xs">
        <CssBaseline />
        <Box
          sx={{
            marginTop: 8,
            display: 'flex',
            flexDirection: 'column',
            alignItems: 'center',
          }}
        >
          <Avatar sx={{ m: 1, bgcolor: 'secondary.dark' }}>
            <LockOutlinedIcon />
          </Avatar>
          <Typography component="h1" variant="h5">
            {signin ? 'Sign In' : 'Sign Up'}
          </Typography>
          <Box
            component="form"
            onSubmit={handleSubmit}
            noValidate
            sx={{ mt: 1 }}
          >
            <TextField
              margin="normal"
              required
              fullWidth
              id="email"
              label="Email Address"
              onChange={(e) =>
                setAccount({ ...account, email: e.target.value })
              }
              name="email"
              autoFocus
            />
            {!signin && (
              <>
                <TextField
                  margin="normal"
                  required
                  fullWidth
                  id="email"
                  label="User name"
                  onChange={(e) =>
                    setAccount({ ...account, userName: e.target.value })
                  }
                  name="text"
                  autoFocus
                />
                <TextField
                  margin="normal"
                  required
                  fullWidth
                  id="text"
                  label="Full name"
                  onChange={(e) =>
                    setAccount({ ...account, fullName: e.target.value })
                  }
                  name="text"
                  autoFocus
                />
                <TextField
                  margin="normal"
                  required
                  fullWidth
                  name="password"
                  label="Password"
                  onChange={(e) =>
                    setAccount({ ...account, password2: e.target.value })
                  }
                  type="password"
                  id="password"
                />
              </>
            )}
            <TextField
              margin="normal"
              required
              fullWidth
              name="password"
              label={!signin ? 'Repeat Password' : 'Password'}
              onChange={(e) =>
                setAccount({ ...account, password: e.target.value })
              }
              type="password"
              id="password"
            />
            <Button
              type="submit"
              fullWidth
              variant="contained"
              sx={{
                ':hover': {
                  bgcolor: 'tertiary.dark',
                },
                mt: 3,
                mb: 2,
                bgcolor: 'tertiary.main',
                color: 'quaternary.light',
              }}
            >
              {!signin ? 'Confirm' : 'Sign In'}
            </Button>
            {signin && (
              <Grid container>
                <Grid item>
                  <Button
                    onClick={(e) => setSignin(false)}
                    sx={{ color: 'tertiary.main', textDecoration: 'none' }}
                  >
                    {'Dont have an account? Sign Up'}
                  </Button>
                </Grid>
              </Grid>
            )}
            {!signin && (
              <Button
                onClick={(e) => setSignin(true)}
                type="submit"
                fullWidth
                variant="contained"
                sx={{
                  ':hover': {
                    bgcolor: 'secondary.dark',
                  },
                  mt: 3,
                  mb: 2,
                  bgcolor: 'secondary.main',
                  color: 'quaternary.light',
                }}
              >
                Cancel
              </Button>
            )}
          </Box>
        </Box>
        <Copyright sx={{ mt: 8, mb: 4 }} />
      </Container>
    </ThemeProvider>
  );
}

export default Login;
