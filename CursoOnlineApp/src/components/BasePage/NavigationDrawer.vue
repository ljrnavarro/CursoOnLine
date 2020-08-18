<template>
  <v-layout>
    <v-navigation-drawer
      id="core-navigation-drawer"
      v-model="drawer"
      :clipped="$vuetify.breakpoint.lgAndUp"
      app
      disable-resize-watcher
      disable-route-watcher
    >
      <v-list-item two-line>
        <v-list-item-avatar>
          <img src="https://randomuser.me/api/portraits/women/81.jpg" />
        </v-list-item-avatar>

        <v-list-item-content>
          <v-list-item-title v-model="userDisplayName">{{
            this.userDisplayName 
          }} <br> {{this.email}}</v-list-item-title>
          <v-list-item-subtitle>conectado</v-list-item-subtitle>
        </v-list-item-content>
      </v-list-item>

      <v-divider></v-divider>

      <v-list dense>
        <v-list-item @click="showDialogRetrievePasswd">
          <v-list-item-action>
            <v-icon>mdi-lock-reset</v-icon>
          </v-list-item-action>
          <v-list-item-content>
            <v-list-item-title>Redefinir Senha</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
        <v-list-item to="/DadosConta" link>
          <v-list-item-action>
            <v-icon>mdi-home</v-icon>
          </v-list-item-action>
          <v-list-item-content>
            <v-list-item-title>Meus dados</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
        <v-list-item to="/Cartao" link>
          <v-list-item-action>
            <v-icon>payment</v-icon>
          </v-list-item-action>
          <v-list-item-content>
            <v-list-item-title>Meus cartões</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
        <v-list-item to="/Curso" link>
          <v-list-item-action>
            <v-icon>school</v-icon>
          </v-list-item-action>
          <v-list-item-content>
            <v-list-item-title>Cursos</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
      </v-list>
      <template>
        <div class="pa-2">
          <v-btn block @click="confirmActionSair">
            <v-icon left>lock_open</v-icon> Sair
          </v-btn>
        </div>
      </template>
    </v-navigation-drawer>
  </v-layout>
</template>

<script>
// @ is an alias to /src
import ContaMixins from '../../mixins/ContaMixins'
import firebase from "firebase";

export default {
  mixins: [ContaMixins],
  props: {
    source: String,
    drawer: Boolean,
  },
  data: () => ({
    userDisplayName: null,
    email: null
  }),
  updated() {},
  created() {
    //  this.$root.$refs.NavigatorDrawer = this;
  },
  components: {
    // VueSweetalert2
  },
  mounted() {
    this.userDisplayName = this.$store.state.user.displayName;
    this.email = this.$store.state.user.email;
   
  },
  events: {},
  methods: {
    getUser: function() {
      firebase.auth().getUser;
    },
    confirmActionSair: function() {
      this.$swal({
        text: "Você será desconectado, confirma?",
        icon: "question",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Sim",
        cancelButtonText: "Não",
      }).then((result) => {
        if (result.value) {
          this.sair();
        }
      });
    },
    sair: function() {
      firebase
        .auth()
        .signOut()
        .then(() => {
          this.$store.commit("LOGOUT_USER");
          this.$router.replace("/Login");
        });
    },
  },
};
</script>
<style scoped>
#core-navigation-drawer {
  top: 64px !important;
  z-index: 3;
}
</style>
