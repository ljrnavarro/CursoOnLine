<template>
    <div class="barraTop">
        <nav class="marginPrincipal">
            <router-link to="/Meus Dados">Meus Dados</router-link>
            <router-link to="/Meus Cartões">Cartões</router-link>
            <router-link to="/sobre">Sobre</router-link>
            <button @click="sair">Sair</button>
        </nav>
    </div>
</template>

<script>
  // @ is an alias to /src
import firebase from 'firebase';

export default {
  name: 'nav',
  components: {
  },
  methods: {
    sair: function() {
      firebase.auth().signOut().then(() => {
        this.$router.replace('login')
      })
    }
  }
}
</script>

<style scoped>
.barraTop {
    background-color: rgb(230, 230, 230)
}
nav {
    padding: 20px 20px 20px 0px
}
nav a, button {
    padding: 10px;
    text-decoration: none;
    background-color: #fff;
    border-radius: 3px;
    color: rgb(0, 110, 255);
    font-weight: bold;
    margin-right: 15px; 
}
nav .router-link-active{
    background-color: rgb(160, 160, 160);
    color: white
}
</style>