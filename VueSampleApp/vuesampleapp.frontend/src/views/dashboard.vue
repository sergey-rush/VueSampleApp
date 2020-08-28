<template>
  <div class="users-container">
    <h1 id="usersTitle">Manage Users</h1>
    <hr />

    <div class="users-actions">
      <app-button @click.native="showNewMemberModal" id="addNewBtn">Add New User</app-button>      
    </div>

    <table id="usersTable" class="table">
      <tr>        
        <th>Name</th>
        <th>Email</th>
        <th>FirstName</th>
        <th>LastName</th>
        <th>Department</th>
        <th>Delete</th>
      </tr>
      <tr v-for="member in members" :key="member.id">
        <td>{{ member.name }}</td>        
        <td>{{ member.email }}</td>
        <td>{{ member.firstName }}</td>
        <td>{{ member.lastName }}</td>
        <td>{{ member.department.title }}</td>
        <td>
          <div class="lni lni-cross-circle product-archive" @click="deleteMember(member)"></div>
        </td>
      </tr>
    </table> 
    <new-member-modal v-if="isNewMemberVisible" @save:member="saveNewMember" @close="closeModals" />   
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import AppButton from "@/components/AppButton.vue";
import NewMemberModal from "@/components/modals/NewMemberModal.vue";
import {IDepartment} from '@/types/Department';
import { UserService } from "@/services/user-service";
import { ProfileService } from "@/services/profile-service";
import { AccountService } from "@/services/account-service";
import { MemberService } from "@/services/member-service";
import { IMember } from '@/types/Member';
import { IUser } from '@/types/User';

const userService = new UserService();
const profileService = new ProfileService();
const accountService = new AccountService();
const memberService = new MemberService();

@Component({
  name: "dashboard",
  components: { AppButton, NewMemberModal }
})
export default class members extends Vue {
isNewMemberVisible: boolean = false;
  members: IMember[] = [];
  departments: IDepartment[] = [];

  async saveNewMember(newMember: IMember) {
    await memberService.save(newMember);
    this.isNewMemberVisible = false;  
    await this.initialize();
  }

  async deleteMember(member: IMember){
    await memberService.delete(member);
    await this.initialize();
  }

  closeModals() {
    this.isNewMemberVisible = false;
  }

  showNewMemberModal() {
    this.isNewMemberVisible = true;
  }

  async initialize(){
        
    this.members = await memberService.getMembers();
    this.departments = await memberService.getDepartments();
  }

  async created() {
    await this.initialize();
  }
}
</script>

<style scoped lang="scss">
@import "@/scss/global.scss";

.users-actions {
  display: flex;
  margin-bottom: 0.8rem;
}

</style>