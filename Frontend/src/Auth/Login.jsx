import './css/Login.css';
import React from 'react';
import { Avatar, Container, Paper, Typography, Box } from '@mui/material';
import {
  LockOutlined,
  AccountCircleRounded,
  LoginOutlined
} from '@mui/icons-material';
import Logo from '../Public/Img/mobile-logo.png'

function Login() {
  const handleSubmit = () => console.log('Submitted');
  return (
    <>
      <Container
        maxWidth="xs"
        sx={{
          bgcolor: 'black',
        }}
      >
        <Paper elevation={10} sx={{ marginTop: 8, padding: 2, color: 'black' }}>
          <Avatar   
            sx={{
              mx: 'auto',
              textAlign: 'center',
              bgcolor: 'black',
              mb: 1,
              width: 100,
              height: 100,
            }}
          >
          </Avatar>
          <Typography component="h1" variant="h5" sx={{ textAlign: 'center' }}>
            Sign In
          </Typography>
          <Box
            component="form"
            onsubmit={handleSubmit}
            noValidate
            sx={{ mt: 1 }}
          >
            <div class="LabelUser mt-6 flex max-w-md gap-x-4">
              <AccountCircleRounded />
              <input
                id=""
                name="Username"
                type="text"
                autocomplete="Username"
                autoFocus
                required
                class="min-w-0 flex-auto rounded-md border-0 bg-white/5 px-3.5 py-2 text-black shadow-sm ring-1 ring-inset ring-white/10 focus:ring-2 focus:ring-inset focus:ring-indigo-500 sm:text-sm/6"
                placeholder="Enter your email"
              />
            </div>

            <div class="LabelUser mt-6 flex max-w-md gap-x-4">
              <LockOutlined />
              <input
                id=""
                name="Username"
                type="text"
                autocomplete="Username"
                autoFocus
                required
                class="min-w-0 flex-auto rounded-md border-0 bg-white/5 px-3.5 py-2 text-black shadow-sm ring-1 ring-inset ring-white/10 focus:ring-2 focus:ring-inset focus:ring-indigo-500 sm:text-sm/6"
                placeholder="Enter your email"
              />
            </div>
          </Box>
          <div className="flex w-full h-screen">
      <div className="w-full flex items-center justify-center lg:w-1/2">
        <Login />
      </div>
      <div className='hidden relative lg:flex h-full w-1/2 items-center justify-center bg-gray-200'>
        <div className="w-60 h-60 bg-gradient-to-tr from-violet-500 to-pink-500 rounded-full animate-bounce"></div>
        <div className="w-full h-1/2 absolute bottom-0  bg-white/10 backdrop-blur-lg"></div>
      </div>
    </div>
        </Paper>
      </Container>
    </>
  );
}

export default Login;
