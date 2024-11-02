const tokenService = {
    saveToken: (token: string): void => {
        localStorage.setItem("token", token);
    },
    getToken: (): string | null => {
        let token = localStorage.getItem("token");
        if (token != null && token != undefined)
            return "Bearer " + token;
        else
            return null;
    },
    clearToken: (): void => {
        localStorage.removeItem("token");
    }
};

export default tokenService;