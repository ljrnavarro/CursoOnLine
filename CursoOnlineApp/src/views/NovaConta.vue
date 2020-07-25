<template>
  <v-app id="inspire">
    <v-content>
      <v-container class="fill-height" fluid>
        <v-row align="center" justify="center">
          <v-col cols="12" sm="8" md="4">
            <v-card class="elevation-5">
              <v-toolbar color="primary" dark flat>
                <v-toolbar-title>Nova conta</v-toolbar-title>
                <v-spacer></v-spacer>
              </v-toolbar>
              <v-card-text>
             <DadosAluno></DadosAluno>
              </v-card-text>
              <v-card-actions>
                <v-spacer></v-spacer>
                <v-btn color="secondary" to="/registrar"> Crie uma Conta</v-btn>
                <v-btn
                  color="primary"
                  :loading="loadingLogin"
                  :disabled="loadingLogin"
                 
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
import DadosAluno from "../components/Aluno/DadosAluno";
//import VueSweetalert2 from "vue-sweetalert2";
//import "sweetalert2/dist/sweetalert2.min.css";
//import "vue2-animate/dist/vue2-animate.min.css";
//import 'sweetalert2/src/SweetAlert/';

export default {
  name: "MeusDados",
  components: {
    DadosAluno,
  },
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
    // this.autocomplete.addListener("place_changed", () => {
    //    var place = self.autocomplete.getPlace();
    //    this.address = place.name; // update the value
    //  });
  },
  methods: {
  },
};
</script>

<style scoped>
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
