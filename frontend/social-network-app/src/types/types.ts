export type Register = {
    name: string;
    email: string;
    birth: Date;
    password: string;
};

export type Login = {
    email: string;
    password: string;
};

export type Message = {
    message: string;
}

export type PageQuery = {
    size: number;
    page: number;
}

export type PageResult = {
    lines: number;
    pages: number;
    currentPage: number;
    total: number;
    dataSource: PageResultFeed[];
}

export type PageResultFeed = {
    id: number;
    dateMessage: Date;
    message: string;
    name: string;
}