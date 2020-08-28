import { IDepartment } from "./Department";
export interface IMember {
    id: number;
    accountId: number;
    profileId: number;
    firstName: string;
    lastName: string;    
    name: string;
    email: string;
    department: IDepartment;
}