import React, { useState } from 'react';
import apiService from '../services/apiService';
import { Message } from '../types/types';
import { Link } from 'react-router-dom';
import FeedList from './FeedList';

interface FormData {
    message: string;
}

const FeedPage: React.FC = () => {
    const [formData, setFormData] = useState<FormData>({
        message: ''
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
            setError('');

            const message: Message = {
                message: formData.message
            }
            await apiService.postMessage(message);
            setError('Mensagem postada com sucesso');
            formData.message = "";
        } catch (error) {
            if ((error as any).response?.data?.Detail == undefined)
                setError("Ocorreu um erro inesperado");
            else
                setError((error as any).response?.data?.Detail);
        }
    };

    return (
        <div style={styles.container}>
            <h1>Feed</h1>
            <form onSubmit={handleSubmit} style={styles.form}>
                <div style={styles.inputGroup}>
                    <label htmlFor="message">Digite uma Mensagem:</label>
                    <input
                        type="text"
                        id="message"
                        name="message"
                        value={formData.message}
                        onChange={handleChange}
                        required
                        style={styles.input}
                    />
                </div>

                {error && <p style={styles.error}>{error}</p>}
                <button type="submit" style={styles.button}>Postar</button>
            </form>
            <div>
                <h2>Postagens Recentes</h2>
                <FeedList />
            </div>
            <div style={styles.container}>
                <button style={styles.button}><Link to="/">Sair</Link></button>
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
        width: '800px',
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

export default FeedPage;