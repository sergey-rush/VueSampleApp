import { IDepartment } from "./Department";

export interface IProfile {
    profileId: number;    
    firstName: string;
    lastName: string;    
    department: IDepartment;
}