<template>
  <v-app>
    <custom-app-bar></custom-app-bar>
    <v-main>
        <router-view></router-view>
    </v-main>
  </v-app>
</template>

<script lang="ts">
import { Options, Vue } from 'vue-class-component';
import CustomAppBar from './components/CustomAppBar.vue';

@Options({
  components: {
    CustomAppBar,
  },
})
export default class App extends Vue {}
</script>

<style lang="scss">
html {
    overflow-y: auto !important; 
}
</style>