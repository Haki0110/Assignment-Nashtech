import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import axios from 'axios';
import { setAuthToken } from '../api/api';

const Login = ({ onLogin }) => {
  const navigate = useNavigate();
  const [credentials, setCredentials] = useState({ username: '', password: '' });

  const authenticateUser = async ({ username, password }) => {
    try {
      const response = await axios.post('http://localhost:8000/authenticate', {
        username,
        password,
      });
      return response.data.token; // Assuming the token is returned in the response data
    } catch (error) {
      console.error('Authentication failed:', error);
      alert('Invalid username or password');
      return null;
    }
  };

  const handleSubmit = async (event) => {
    event.preventDefault();
    const token = await authenticateUser(credentials);
    if (token) {
      setAuthToken(token);
      onLogin(token);
      navigate('/');
    }
  };

  const handleChange = (event) => {
    const { name, value } = event.target;
    setCredentials({ ...credentials, [name]: value });
  };

  return (
    <form onSubmit={handleSubmit}>
      <div>
        <label>Username:</label>
        <input
          type="text"
          name="username"
          value={credentials.username}
          onChange={handleChange}
        />
      </div>
      <div>
        <label>Password:</label>
        <input
          type="password"
          name="password"
          value={credentials.password}
          onChange={handleChange}
        />
      </div>
      <button type="submit">Login</button>
    </form>
  );
};

export default Login;
