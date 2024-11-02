import React, { useState } from 'react';
import apiService from '../services/apiService';
import { Login, MyCustomError, Register } from '../types/types';
import { Link } from 'react-router-dom';

interface FormData {
    email: string;
    password: string;
}

const LoginPage: React.FC = () => {
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
            await apiService.login(login);
            setError('Logado com sucesso');
        } catch (error) {
            setError((error as any).response.data.Detail);
        }
    };

    return (
        <div style={styles.container}>
            <h1>Login</h1>
            <form onSubmit={handleSubmit} style={styles.form}>
                <div style={styles.inputGroup}>
                    <label htmlFor="email">E-mail:</label>
                    <input
                        type="email"
                        id="email"
                        name="email"
                        value={formData.email}
                        onChange={handleChange}
                        required
                        style={styles.input}
                    />
                </div>
                <div style={styles.inputGroup}>
                    <label htmlFor="password">Senha:</label>
                    <input
                        type="password"
                        id="password"
                        name="password"
                        value={formData.password}
                        onChange={handleChange}
                        required
                        style={styles.input}
                    />
                </div>
                {error && <p style={styles.error}>{error}</p>}
                <button type="submit" style={styles.button}>Logar</button>
            </form>
            <div style={styles.container}>
                <button style={styles.button}><Link to="/register">Primeiro Acesso</Link></button>
            </div>            
        </div>

    );
};

const styles = {
    form: {
        display: 'flex',
        flexDirection: 'column' as 'column',
        alignItems: 'center',
        gap: '10px',
        width: '300px',
        margin: '20px auto',
        padding: '20px',
        border: '1px solid #ddd',
        borderRadius: '5px',
    },
    inputGroup: {
        display: 'flex',
        flexDirection: 'column' as 'column',
        width: '100%',
        gap: '5px',
    },
    input: {
        padding: '8px',
        borderRadius: '4px',
        border: '1px solid #ccc',
        width: '100%',
    },
    button: {
        padding: '10px 15px',
        backgroundColor: '#007BFF',
        color: 'white',
        border: 'none',
        borderRadius: '5px',
        cursor: 'pointer',
    },
    error: {
        color: 'red',
    },
    container: {
        display: 'flex',
        flexDirection: 'column' as 'column',
        alignItems: 'center'
    }
};

export default LoginPage;