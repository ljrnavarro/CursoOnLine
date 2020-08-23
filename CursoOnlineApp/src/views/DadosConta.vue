<template>
  <v-app>
    <v-row>
      <v-col cols="12" sm="8" md="4">
        <v-card class="elevation-5">
          <v-toolbar color="primary" dark flat>
            <v-toolbar-title>Alteração de dados</v-toolbar-title>
            <v-spacer></v-spacer>
          </v-toolbar>
          <v-card-text>
            <DadosAluno ref="dadosAluno" />
          </v-card-text>
          <v-card-actions>
            <v-spacer></v-spacer>
            <v-btn color="error">
              <v-icon left dark>cancel</v-icon>
              Cancelar</v-btn
            >
            <v-btn
              color="primary"
              @click="updateAcount"
              :loading="loadingUpdateAcount"
              :disabled="loadingUpdateAcount"
            >
              <template v-slot:loader>
                <span class="custom-loader">
                  <v-icon light>cached</v-icon>
                </span>
              </template>
              <v-icon left dark>fas fa-save</v-icon>
              Alterar
            </v-btn>
          </v-card-actions>
        </v-card>
      </v-col>
    </v-row>
  </v-app>
</template>

<script>
import DadosAluno from "../components/Aluno/DadosAluno";
import firebase from "firebase";
import { RepositoryFactory } from "./../Repositories/RepositoryFactory";
//import MessageBoxMixins from './../mixins/MessageBoxMixins.js';
const AlunoRepository = RepositoryFactory.get("aluno");

export default {
  name: "MeusDados",
  components: {
    DadosAluno,
  },
 // mixins:[MessageBoxMixins],
  data: () => ({
      loadingUpdateAcount: false,
      loader: null,
      dadosAlunoConta: null,
  }),
  props: {
    source: String,
  },
  mounted() {
    this.$refs.dadosAluno.alterDataMode = true;
    this.getUser();
  },
  methods: {
    async getUser() {
      await (async () => {
        this.dadosAlunoConta = await AlunoRepository.getAluno(
          this.$store.state.user.uid
        );
        this.$refs.dadosAluno.email = this.dadosAlunoConta.data.email;
        this.$refs.dadosAluno.dataNascimento = this.dadosAlunoConta.data.nascimento;
        this.$refs.dadosAluno.cpf = this.dadosAlunoConta.data.cpf;
        this.$refs.dadosAluno.name = this.dadosAlunoConta.data.nome;
      })();
    },
    async updateAcount() {
      this.loadingUpdateAcount = true;
      this.$refs.dadosAluno.validate();
      var UpdateAlunoAcount = {
        Nome: this.$refs.dadosAluno.name,
        Email: this.$refs.dadosAluno.email,
        CPF: this.$refs.dadosAluno.unmaskedCpf,
        Nascimento: this.$refs.dadosAluno.dataNascimento,
        RefUser: this.$store.state.user.uid,
        id: this.dadosAlunoConta.Id,
      };
      var user = firebase.auth().currentUser;
      user.updateEmail(this.$refs.dadosAluno.email).then(async () => {
        //atualizando no banco de dados
        try {
          await AlunoRepository.update(UpdateAlunoAcount);
        } catch (Error) {
          console.log("erro", Error);
          this.showMessage(this.messageType.ERROR, "Dados não atualizados", "Contate o suporte.", null);
          this.loadingUpdateAcount = false;

          //Voltando o email
          user.updateEmail(this.dadosAlunoConta.data.email).then(async () => {})
          return;
        }
        this.showMessage(this.messageType.SUCCESS, "Dados Atualizados",
           "Dados atualizados.Você será redirecionado ao login.", "Login");
              this.loadingUpdateAcount = false;
      });
    },
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
