import axios from 'axios';
import {IUser} from '@/types/User';

export class UserService {
    API_URL = process.env.VUE_APP_API_URL;

    public async getUsers() : Promise<IUser[]> {        
        let result = await axios.get(`${this.API_URL}/user/`);
        return result.data;
    }

    async save(newUser: IUser) {
        let result:any = await axios.post(`${this.API_URL}/user/`, newUser);
        return result.data;
    }

    async delete(user: IUser) {
        let result:any = await axios.delete(`${this.API_URL}/user/${user.id}`);
        return result.data;
    } 
}