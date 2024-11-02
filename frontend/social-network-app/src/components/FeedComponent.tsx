import React from 'react';

interface FeedProps {
    title: string;
    description: string;
}

const FeedItem: React.FC<FeedProps> = ({ title, description }) => {
    return (
        <div className="card">
            <div className="card-body">
                <h4 className="card-title">{title}</h4>
                <p className="card-description">{description}</p>
            </div>
            <hr></hr>
        </div>
        
    );
};

export default FeedItem;
