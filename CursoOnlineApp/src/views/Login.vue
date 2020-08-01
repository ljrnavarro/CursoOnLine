<template>
  <v-app id="inspire">
    <v-content>
      <v-container class="fill-height" fluid>
        <v-row align="center" justify="center">
          <v-col cols="12" sm="8" md="4">
            <v-card class="elevation-5">
              <v-toolbar color="primary" dark flat>
                <v-toolbar-title>Efetue o Login</v-toolbar-title>
                <v-spacer></v-spacer>
              </v-toolbar>
              <v-card-text>
                <v-form>
                  <v-text-field
                    v-model="email"
                    outlined
                    label="Email"
                    name="email"
                    autocomplete="off"
                    prepend-icon="person"
                    type="text"
                  ></v-text-field>
                  <v-text-field
                    v-model="senha"
                    label="Senha"
                    name="senha"
                    outlined
                    prepend-icon="lock"
                    placeholder="Senha"
                    type="password"
                  >
                  </v-text-field>
                </v-form>
              </v-card-text>
              <v-card-actions>
                <v-spacer></v-spacer>
                <v-btn
                  color="secondary"
                  @click="newAcount"
                  :loading="loadingNovaConta"
                  :disabled="loadingNovaConta"
                  to="/registrar"
                >
                  Crie uma Conta</v-btn
                >
                <v-btn
                  color="primary"
                  :loading="loadingLogin"
                  :disabled="loadingLogin"
                  @click="login"
                >
                  <template v-slot:loader>
                    <span class="custom-loader">
                      <v-icon light>cached</v-icon>
                    </span>
                  </template>
                  Login
                </v-btn>
              </v-card-actions>
            </v-card>
          </v-col>
        </v-row>
      </v-container>
    </v-content>
  </v-app>
</template>

<script>
import firebase from "firebase";
import "vue2-animate/dist/vue2-animate.min.css";
//import 'sweetalert2/src/SweetAlert/';

export default {
  name: "login",
  data() {
    return {
      email: "",
      senha: "",
      loadingLogin: false,
      loadingNovaConta: false,
      loader: null,
    };
  },
  props: {
    source: String,
  },
  mounted() {
     this.$nextTick(function () {
      console.log("senha", this.senha);
      console.log("email", this.email);
    });
  },
  methods: {
    fetchToken: async function() {
      const currentUser = firebase.auth().currentUser;
      if (currentUser) {
        const tokenId2 = await firebase.auth().currentUser.getIdToken(true);
        console.log("login2");
        this.$store.commit("STORE_USER_TOKEN", {
          user: currentUser,
          token: tokenId2,
        });
      }
    },
    login: async function() {
      this.loadingLogin = true;
      await firebase
        .auth()
        .signInWithEmailAndPassword(this.email, this.senha)
        .then(
          async () => {
            this.loadingLogin = false;
            console.log("login1");
            await this.fetchToken();
            this.$swal({
              icon: "success",
              title: "Login Efetuado com Sucesso",
              text: "Seja bem vindo " + this.email,
              showClass: {
                popup: "animated fadeInDown",
              },
              hideClass: {
                popup: "animated fadeOutUp",
              },
            });
            this.$router.replace("/AppLayout");
          },
          (err) => {
            this.loadingLogin = false;
            this.$swal({
              icon: "error",
              title: "Oops...",
              text: "Não foi possível efetivar seu login. " + err.message,
              showClass: {
                popup: "animated fadeInDown",
              },
              hideClass: {
                popup: "animated fadeOutUp",
              },
            });
          }
        );
    },
    newAcount: function() {
      this.$router.replace("/NovaConta");
    },
  },
};
</script>

<style>
.login {
  margin-top: 40px;
}
input {
  margin: 10px 0;
  width: 20%;
  padding: 15px;
}

button {
  font-family: "Roboto", sans-serif;
  text-transform: uppercase;
  outline: 0;
  background: #4caf50;
  border: 0;
  padding: 15px;
  color: #ffffff;
  font-size: 14px;
  -webkit-transition: all 0.3 ease;
  transition: all 0.3 ease;
  cursor: pointer;
}
p {
  margin-top: 40px;
  font-size: 13px;
}
p a {
  text-decoration: underline;
  cursor: pointer;
}
.custom-loader {
  animation: loader 1s infinite;
  display: flex;
}
@-moz-keyframes loader {
  from {
    transform: rotate(0);
  }
  to {
    transform: rotate(360deg);
  }
}
@-webkit-keyframes loader {
  from {
    transform: rotate(0);
  }
  to {
    transform: rotate(360deg);
  }
}
@-o-keyframes loader {
  from {
    transform: rotate(0);
  }
  to {
    transform: rotate(360deg);
  }
}
@keyframes loader {
  from {
    transform: rotate(0);
  }
  to {
    transform: rotate(360deg);
  }
}

.fill-height {
  padding-bottom: 250px !important;
}
</style>
