import React, { useEffect, useState } from 'react';
import apiService from '../services/apiService';
import { Message, PageQuery, PageResult, PageResultFeed } from '../types/types';
import { Link } from 'react-router-dom';
import FeedItem from '../components/FeedComponent';
import { globalStylesApp } from '../MyCss';

interface FormData {
    message: string;
}

const FeedPage: React.FC = () => {
    const [feed, setFeed] = useState<PageResultFeed[]>([]);
    const [pagination, setPagination] = useState<PageResult>();
    const [pages, setPages] = useState<number[]>([]);

    useEffect(() => {
        const fetchData = async () => {
            await listFeed();
        };
        fetchData();
    }, []);

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

    const formatDate = (date: Date): string => {
        var formattedDate = new Date(date).toLocaleDateString('pt-BR');
        var formattedTime = new Date(date).toLocaleTimeString('pt-BR');
        return `${formattedDate} ${formattedTime}`;
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
            await listFeed();
        } catch (error) {
            if ((error as any).response?.data?.Detail == undefined)
                setError("Ocorreu um erro inesperado");
            else
                setError((error as any).response?.data?.Detail);
        }
    };

    const listFeed = async (page: number = 1) => {
        try {
            const pageQuery: PageQuery = {
                page: page,
                size: 5
            };
            var response = await apiService.getFeed(pageQuery);
            setFeed(response.dataSource);
            setPagination(response);

            const pageNumbers = [];
            for (let i = 1; i <= response.pages; i++) {
                pageNumbers.push(i);
            }
            setPages(pageNumbers);
        } catch (err) {
            setError(err instanceof Error ? err.message : 'Erro ao carregar os feed.');
        }
    };

    return (
        <div style={globalStylesApp.container}>
            <h1>Feed</h1>
            <form onSubmit={handleSubmit} style={globalStylesApp.form}>
                <div style={globalStylesApp.inputGroup}>
                    <label htmlFor="message">Digite uma Mensagem:</label>
                    <input
                        type="text"
                        id="message"
                        name="message"
                        value={formData.message}
                        onChange={handleChange}
                        required
                        style={globalStylesApp.input}
                    />
                </div>
                {error && <p style={globalStylesApp.error}>{error}</p>}
                <button type="submit" style={globalStylesApp.button}>Postar</button>
            </form>
            <div>
                <h2>Postagens Recentes</h2>
                <div className="feed-list">
                    {feed.map(feed => (
                        <FeedItem
                            key={feed.id}
                            title={formatDate(feed.dateMessage)}
                            description={feed.message}
                            name={feed.name}
                        />
                    ))}
                </div>
                <div className='fedd-pagination'>
                    {pages.map(page => (
                        <button style={feedStyle.buttonPage} onClick={() => listFeed(page)}>{page}</button>
                    ))}
                </div>
            </div>
            <br></br>
            <div style={globalStylesApp.container}>
                <button style={globalStylesApp.button}><Link to="/">Sair</Link></button>
            </div>

        </div>

    );
};

export const feedStyle = {
    buttonPage: {
        marginLeft: '10px',
        backgroundColor: '#007BFF',
        cursor: 'pointer',
        padding: '10px 15px',
        color: 'white',
        border: 'none',
        borderRadius: '5px'
    }
}

export default FeedPage;