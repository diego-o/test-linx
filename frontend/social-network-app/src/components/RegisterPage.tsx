import React, { useState } from 'react';
import apiService from '../services/apiService';
import { Register } from '../types/types';
import { Link } from 'react-router-dom';

interface FormData {
    name: string;
    email: string;
    birthDate: string;
    password: string;
    confirmPassword: string;
}

const RegistrationForm: React.FC = () => {
    const [formData, setFormData] = useState<FormData>({
        name: '',
        email: '',
        birthDate: '',
        password: '',
        confirmPassword: ''
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

        if (formData.password !== formData.confirmPassword) {
            setError('As senhas estão diferentes.');
        } else {
            setError('');
            try {
                const register: Register = {
                    birth: new Date(formData.birthDate),
                    email: formData.email,
                    name: formData.name,
                    password: formData.password
                }
                await apiService.register(register);
                setError('Cadastrado com sucesso');
            } catch (error) {
                setError((error as any).response.data.Detail);
            }
        }
    };

    return (
        <div style={styles.container}>
            <h1>Cadastro</h1>
            <form onSubmit={handleSubmit} style={styles.form}>
                <div style={styles.inputGroup}>
                    <label htmlFor="name">Nome:</label>
                    <input
                        type="text"
                        id="name"
                        name="name"
                        value={formData.name}
                        onChange={handleChange}
                        required
                        style={styles.input}
                    />
                </div>
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
                    <label htmlFor="birthDate">Data de Nascimento:</label>
                    <input
                        type="date"
                        id="birthDate"
                        name="birthDate"
                        value={formData.birthDate}
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
                <div style={styles.inputGroup}>
                    <label htmlFor="confirmPassword">Confirmar Senha:</label>
                    <input
                        type="password"
                        id="confirmPassword"
                        name="confirmPassword"
                        value={formData.confirmPassword}
                        onChange={handleChange}
                        required
                        style={styles.input}
                    />
                </div>
                {error && <p style={styles.error}>{error}</p>}
                <button type="submit" style={styles.button}>Cadastrar</button>
            </form>
            <div style={styles.container}>
                <button style={styles.button}><Link to="/">Retornar para Login</Link></button>
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

export default RegistrationForm;
