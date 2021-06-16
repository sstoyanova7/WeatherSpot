export class NewUser {
    
    private username: string;
    private password: string;
    private role: string;
    
    constructor(username: string, password: string) {
        this.username = username;
        this.password = password;
        if(this.role === undefined) {
            this.role = "";
        }
    }
} 