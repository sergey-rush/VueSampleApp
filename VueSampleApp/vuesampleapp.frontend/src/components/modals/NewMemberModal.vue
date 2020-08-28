<template>
  <App-modal>
    <template v-slot:header>Add new user</template>

    <template v-slot:body>
      <ul> 
        <li>
          <label for="firstName">FirstName</label>
          <input type="text" id="firstName" v-model="newMember.firstName">
        </li>

        <li>
          <label for="lastName">LastName</label>
          <input type="text" id="lastName" v-model="newMember.lastName">
        </li>

        <li>
          <label for="email">Email</label>
          <input type="text" id="email" v-model="newMember.email">
        </li>        
      </ul>
    </template>

    <template v-slot:footer>
      <app-button type="button" @click.native="save" aria-label="save new item">Save User</app-button>
      <app-button type="button" @click.native="close" aria-label="close modal">Close</app-button>
    </template>
  </App-modal>
</template>

<script lang="ts">
import { Component, Prop, Vue } from "vue-property-decorator";
import AppButton from "@/components/AppButton.vue";
import AppModal from "@/components/modals/AppModal.vue";
import { IUser } from "@/types/User";
import { IMember } from '@/types/Member';
import { IDepartment } from '@/types/Department';

@Component({
  name: "NewMemberModal",
  components: { AppButton, AppModal }
})
export default class NewMemberModal extends Vue {
  department:IDepartment = {id:1, title:"HR"};
  newMember: IMember = {
    id: 0,
    accountId: 0,
    profileId: 0,
    firstName: "",
    lastName: "",
    department:this.department,
    name: "",
    email: ""    
  };

  close() {
    this.$emit("close");
  }

  save() {
    this.$emit('save:member', this.newMember);
  }
}
</script>

<style scoped lang="scss">
  .newMember {
    list-style: none;
    padding: 0;
    margin: 0;

    input {
      width: 100%;
      height: 1.8rem;
      margin-bottom: 1.2rem;
      font-size: 1.1rem;
      line-height: 1.3rem;
      padding: 0.2rem;
      color: #555;
    }

    label {
      font-weight: bold;
      display: block;
      margin-bottom: 0.3rem;
    }
  }
</style>