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

export type MyCustomError = {
    StatusCode: number;
    Message: string;
    Detail: string;
}

export type Message = {
    message: string;
}