<template>
  <div id="app">
    <!-- <img alt="Vue logo" src="./assets/logo.png">
    <HelloWorld msg="Welcome to Your Vue.js App"/> -->
    <header>
      <router-link to="/home"> Home </router-link>|
      <router-link to="/about"> About </router-link>|
      <router-link to="/Vuex"> Vuex </router-link>
      <router-link to="/Login"> Login </router-link>
      <router-view></router-view>
    </header>
  </div>
</template>

<script>
import HelloWorld from './components/HelloWorld.vue'

export default {
  name: 'app',
  components: {
    HelloWorld
  }
}
</script>

<style lang="css">
@import "./style/stylehome.css";
</style>


<style>
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
a.router-link-active{
  color: red;
}
</style>
