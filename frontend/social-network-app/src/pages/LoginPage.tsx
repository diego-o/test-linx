import React, { useState } from 'react';
import apiService from '../services/apiService';
import { Login } from '../types/types';
import { Link } from 'react-router-dom';
import { useNavigate } from 'react-router-dom';
import tokenService from '../services/tokenService';
import { globalStylesApp } from '../MyCss';

interface FormData {
    email: string;
    password: string;
}

const LoginPage: React.FC = () => {
    tokenService.clearToken();
    const navigate = useNavigate();

    const [formData, setFormData] = useState<FormData>({
        email: '',
        password: ''
    });

    const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        const { name, value } = e.target;
        setFormData((prevData) => ({
            ...prevData,
            [name]: value,
        }));
    };

    const [error, setError] = useState<string>('');

    const handleSubmit = async (e: React.FormEvent) => {
        e.preventDefault();

        try {
            const login: Login = {
                email: formData.email,
                password: formData.password
            }
            var token = await apiService.login(login);
            tokenService.saveToken(token.token);
            setError('Logado com sucesso');
            navigate('/feed');
        } catch (error) {
            setError((error as any).response?.data?.Detail);
        }
    };

    return (
        <div style={globalStylesApp.container}>
            <h1>Login</h1>
            <form onSubmit={handleSubmit} style={globalStylesApp.form}>
                <div style={globalStylesApp.inputGroup}>
                    <label htmlFor="email">E-mail:</label>
                    <input
                        type="email"
                        id="email"
                        name="email"
                        value={formData.email}
                        onChange={handleChange}
                        required
                        style={globalStylesApp.input}
                    />
                </div>
                <div style={globalStylesApp.inputGroup}>
                    <label htmlFor="password">Senha:</label>
                    <input
                        type="password"
                        id="password"
                        name="password"
                        value={formData.password}
                        onChange={handleChange}
                        required
                        style={globalStylesApp.input}
                    />
                </div>
                {error && <p style={globalStylesApp.error}>{error}</p>}
                <button type="submit" style={globalStylesApp.button}>Logar</button>
            </form>
            <div style={globalStylesApp.container}>
                <button style={globalStylesApp.button}><Link to="/register">Primeiro Acesso</Link></button>
            </div>            
        </div>

    );
};

export default LoginPage;