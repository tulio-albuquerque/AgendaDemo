<template>
  <HelloWorld msg="Welcome to Your Vue.js App"/>
</template>

<script>
import HelloWorld from './components/HelloWorld.vue'

export default {
  name: 'App',
  components: {
    HelloWorld
  }
}
</script>

<style>
* {
    box-sizing: border-box;
    margin: 0;
    padding: 0;
}

li, a, button {
    font-family: "Montserrat", sans-serif;
    font-weight: 500;
    font-size: 16px;
    text-decoration: none;
}
</style>
