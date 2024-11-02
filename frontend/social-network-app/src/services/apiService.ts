import axios from 'axios';
import { Login, Register } from '../types/types';

const API_URL = 'https://localhost:7292/api';

const api = axios.create({
    baseURL: API_URL,
    headers: {
      'Content-Type': 'application/json',
    },
  });

  const apiService = {
    register: async (register: Register): Promise<any> => {
      const response = await api.post('/Register', register);
      return response.data;
    },
    login: async (login: Login): Promise<any> => {
        const response = await api.post('/Login', login);
        return response.data;
      },
  };

  export default apiService;