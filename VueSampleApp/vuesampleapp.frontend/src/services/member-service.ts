import axios from 'axios';
import {IMember} from '@/types/Member';
import {IDepartment} from '@/types/Department';
import { IUser } from '@/types/User';
import { IAccount } from '@/types/Account';
import { IProfile } from '@/types/Profile';
import { UserService } from "@/services/user-service";
import { ProfileService } from "@/services/profile-service";
import { AccountService } from "@/services/account-service";

const userService = new UserService();
const profileService = new ProfileService();
const accountService = new AccountService();


export class MemberService {
    API_URL = process.env.VUE_APP_API_URL;    
    members: IMember[] = [];
    users: IUser[] = [];
    profiles: IProfile[] = [];
    accounts: IAccount[] = [];
    departments: IDepartment[] = [];

    async delete(member: IMember) {
      let account:any = await accountService.delete(member as IAccount);
      let profile:any = await profileService.delete(member as IProfile);
      let user:any = await userService.delete(member as IUser);
    }

    async save(newMember: IMember) {
      newMember.name = newMember.firstName + " " + newMember.lastName;
      let account:any = await accountService.save(newMember as IAccount);
      newMember.accountId = account.data.id;
      let profile:any = await profileService.save(newMember as IProfile);      
      newMember.profileId = profile.data.id;
      let user:any = await userService.save(newMember as IUser);      
    }  

  getDepartments = async () => {    
    const departmentList = await axios.get(`${this.API_URL}/department/`);
    this.departments = departmentList.data;
    return this.departments;
  }
    
    getMembers = async () => {
        try {
          this.members = [];
        const userList = await axios.get(`${this.API_URL}/user/`);
        this.users = userList.data;
        const accountList = await axios.get(`${this.API_URL}/account/`);
        this.accounts = accountList.data;
        const profileList = await axios.get(`${this.API_URL}/profile/`);
        this.profiles = profileList.data;        

        for (var i = 0; i < this.users.length; i++) {

            var user = this.users[i];
            let account = this.accounts.find(i => i.accountId === user.accountId);
            let profile = this.profiles.find(i => i.profileId === user.profileId);
            let mem = {id:user.id, 
                accountId:user.accountId, 
                profileId:user.profileId, 
                firstName:profile?.firstName, 
                lastName:profile?.lastName,
                department:profile?.department,
                name:account?.name, 
                email:account?.email }
            this.members.push(mem as IMember);           
        } 
        } catch(e) {
          console.log(e);
        }
        return this.members;
    }  
  }