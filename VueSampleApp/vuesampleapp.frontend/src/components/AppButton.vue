<template>
  <div class="btn-link">
    <button
      @click="onClick"
      :class="['app-button']"
      type="button">
      <slot></slot>
    </button>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import Component from "vue-class-component";


@Component({
  name: "AppButton",
  components: {}
})
export default class AppButton extends Vue { 
  
  onClick() {
      this.$emit('button:click')
  }
}
</script>

<style scoped lang="scss">
@import "@/scss/global.scss";

.app-button {
  background: lighten($app-blue, $amount: 10%);
  color: white;
  padding: 0.8rem;
  transition: background-color 0.5s;
  margin: 0.3rem 0.2rem;
  display: inline-block;
  cursor: pointer;
  font-size: 1rem;
  min-width: 100px;
  border: none;
  border-bottom: 2px solid darken($app-blue, 20%);
  border-radius: 3px;

  &:hover {
    background: lighten($app-blue, 20%);
    transition: background-color 0.5s;
  }

  &:disabled {
    background: lighten($app-blue, 15%);
    border-bottom: 2px solid lighten($app-blue, 20%);
  }

  &:active {
    background: $app-yellow;
    border-bottom: 2px solid lighten($app-yellow, 20%);
  }
}
</style>