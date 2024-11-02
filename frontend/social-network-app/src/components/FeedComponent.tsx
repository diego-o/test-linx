import React from 'react';

interface FeedProps {
    title: string;
    description: string;
    name: string;
}

const FeedItem: React.FC<FeedProps> = ({ title, description, name }) => {
    return (
        <div className="card">
            <div className="card-body">
                <h4 className="card-title">{name} - {title}</h4>
                <p className="card-description">{description}</p>
            </div>
            <hr></hr>
        </div>
        
    );
};

export default FeedItem;
