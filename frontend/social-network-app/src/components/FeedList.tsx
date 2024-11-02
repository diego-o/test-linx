import React, { useEffect, useState } from 'react';
import FeedItem from './FeedComponent';
import { PageQuery, PageResultFeed } from '../types/types';
import apiService from '../services/apiService';

const FeedList: React.FC = () => {
    const [feeds, setFeeds] = useState<PageResultFeed[]>([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState<string | null>(null);

    const formatDate = (date: Date): string => {
        var formattedDate = new Date(date).toLocaleDateString('pt-BR');
        var formattedTime = new Date(date).toLocaleTimeString('pt-BR');
        return `${formattedDate} ${formattedTime}`;
    };


    useEffect(() => {
        const fetchFeeds = async () => {
            try {
                const pageQuery: PageQuery = {
                    page: 1,
                    size: 5
                };
                var response = await apiService.getFeeds(pageQuery);
                setFeeds(response.dataSource);
            } catch (err) {
                setError(err instanceof Error ? err.message : 'Erro ao carregar os feed.');
            } finally {
                setLoading(false);
            }
        };

        fetchFeeds();
    }, []);

    if (loading) return <div>Carregando...</div>;
    if (error) return <div>Error: {error}</div>;

    return (
        <div className="feed-list">
            {feeds.map(feed => (
                <FeedItem
                    key={feed.id}
                    title={formatDate(feed.dateMessage)}
                    description={feed.message}
                />
            ))}
        </div>
    );
};

export default FeedList;
