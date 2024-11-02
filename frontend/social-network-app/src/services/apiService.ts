import axios from 'axios';
import { Login, Message, PageQuery, PageResult, Register } from '../types/types';
import tokenService from './tokenService';

const API_URL : string = (process.env.API_BASE_URL as string);

const api = axios.create({
    baseURL: "https://localhost:7292/api",
    headers: { 'Content-Type': 'application/json' }
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
    postMessage: async (message: Message): Promise<any> => {
        const response = await api.post('/Feed', message, {
            headers: {
                'Content-Type': 'application/json',
                'Authorization': tokenService.getToken(),
            }
        });
        return response.data;
    },
    getFeeds: async (pageQuery: PageQuery): Promise<PageResult> => {
        const response = await api.post<PageResult>('/Feed/paged', pageQuery, {
            headers: {
                'Content-Type': 'application/json',
                'Authorization': tokenService.getToken(),
            }
        });
        return response.data;
    }
};

export default apiService;