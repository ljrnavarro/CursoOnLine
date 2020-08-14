<template>
  <v-app id="inspire">
    <v-content>
      <v-container class="fill-height" fluid>
        <v-row align="center" justify="center">
          <v-col cols="12" sm="8" md="4">
            <v-card class="elevation-5">
              <v-toolbar color="primary" dark flat>
                <v-toolbar-title>Cadastro de novo aluno</v-toolbar-title>
                <v-spacer></v-spacer>
              </v-toolbar>
              <v-card-text>
                <DadosAluno ref="dadosAluno" />
              </v-card-text>
              <v-card-actions>
                <v-spacer></v-spacer>
                <v-btn color="error" to="/login">
                <v-icon left dark>cancel</v-icon>
                Cancelar</v-btn>
                <v-btn
                  color="primary"
                  @click="registreNewAlunoAcount"
                  :loading="loadingNovaConta"
                  :disabled="loadingNovaConta"
                >
                  <template v-slot:loader>
                    <span class="custom-loader">
                      <v-icon light>cached</v-icon>
                    </span>
                  </template>
                   <v-icon left dark>fas fa-save</v-icon>
                  Salvar
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
import firebase from "firebase";
import { RepositoryFactory } from "./../Repositories/RepositoryFactory";
const AlunoRepository = RepositoryFactory.get("aluno");

export default {
  name: "MeusDados",
  components: {
    DadosAluno,
  },
  data() {
    return {
      loadingLogin: false,
      loadingNovaConta: false,
      loader: null,
    };
  },
  props: {
    source: String,
  },
  mounted() {},
  methods: {
    async registreNewAlunoAcount() {
      this.loadingNovaConta = true;
      this.$refs.dadosAluno.validate();
      var newAlunoAcount = {
        Nome: this.$refs.dadosAluno.name,
        Email: this.$refs.dadosAluno.email,
        CPF: this.$refs.dadosAluno.unmaskedCpf,
        Nascimento: this.$refs.dadosAluno.dataNascimento,
        RefUser: "",
      };

      console.log("newAccount", newAlunoAcount);

      firebase
        .auth()
        .createUserWithEmailAndPassword(
          newAlunoAcount.Email,
          this.$refs.dadosAluno.password
        )
        .then(
          async (user) => {
            //Cadastrando no banco, após gravar no firebase e capturar o UID
            await (async () => {
              newAlunoAcount.RefUser = user.user.uid;
              await AlunoRepository.create(newAlunoAcount);

              this.$swal({
                icon: "success",
                title: "Nova conta cadastrada com Sucesso",
                text:
                  "Seja bem vindo(a) " +
                  newAlunoAcount.Nome +
                  " você será redirecionado ao login.",
                showClass: {
                  popup: "animated fadeInDown",
                },
                hideClass: {
                  popup: "animated fadeOutUp",
                },
                onClose: () => {
                  this.$router.replace("Login");
                }
              });
            })();

            this.loadingNovaConta = false;
          },
          (err) => {
            alert("Aconteceu algo inesperado. " + err.message);
            this.loadingNovaConta = false;
          }
        );
      //      const { data } = await AlunoRepository.create(newAlunoAcount);
      //    console.log("newaluno", data)
      this.isLoading = false;
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
