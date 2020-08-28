import axios from 'axios';
import {IProfile} from '@/types/Profile';

export class ProfileService {
    API_URL = process.env.VUE_APP_API_URL;

    public async getProfiles() : Promise<IProfile[]> {
        let result = await axios.get(`${this.API_URL}/profile/`);
        return result.data;
    }

    async save(newProfile: IProfile) {
        let result:any = await axios.post(`${this.API_URL}/profile/`, newProfile);
        return result.data;
    }

    async delete(profile: IProfile) {
        let result:any = await axios.delete(`${this.API_URL}/profile/${profile.profileId}`);
        return result.data;
    } 
}