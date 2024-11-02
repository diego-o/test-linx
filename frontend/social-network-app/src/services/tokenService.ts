const tokenService = {
    saveToken: (token: string): void => {
        localStorage.setItem("token", token);
    },
    getToken: (): string | null => {
        let token = "Bearer " + localStorage.getItem("token");
        return token;
    },
    clearToken: (): void => {
        localStorage.removeItem("token");
    }
};

export default tokenService;