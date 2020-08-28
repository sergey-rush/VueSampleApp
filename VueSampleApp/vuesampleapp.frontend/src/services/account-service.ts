import axios from 'axios';
import {IAccount} from '@/types/Account';

export class AccountService {
    API_URL = process.env.VUE_APP_API_URL;

    public async getAccounts() : Promise<IAccount[]> {        
        let result = await axios.get(`${this.API_URL}/account/`);
        return result.data;
    }

    async save(newAccount: IAccount) {
        let result:any = await axios.post(`${this.API_URL}/account/`, newAccount);
        return result.data;
    }
    
    async delete(account: IAccount) {
        let result:any = await axios.delete(`${this.API_URL}/account/${account.accountId}`);
        return result.data;
    } 
}