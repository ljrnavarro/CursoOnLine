<template>
  <v-card
    class="mx-auto"
    height="auto"
    max-width="350"
    elevation="10"
    outlined
    shaped
  >
    <v-container>
      <v-row justify="space-between">
        <v-col>
          <v-row style="padding-bottom: 10px;" class="flex-column ma-0">
            <div style="font-size:10px">Código do Cartão:</div>
            <div style="font-sise:12px;font-weight:bold">
              {{ numero }}
            </div>
          </v-row>
          <v-row flex-row class="flex-row">
            <v-col class="justify-start">
              <div style="font-size:10px">Vencimento:</div>
              <div style="font-sise:12px;font-weight:bold">
                {{ validade }}
              </div>
            </v-col>
            <v-col class="d-flex justify-end align-end">
              <v-icon class="avatar-size" :color="color" x-large v-on="on"
                >{{bandeiraCartaoIcon}}</v-icon
              >
            </v-col>
          </v-row>
        </v-col>
      </v-row>
    </v-container>
    <v-divider class="mx-4"></v-divider>

    <v-card-actions>
      <v-btn :loading="loading" color="error" @click="excluirCartao" small>
        <v-icon left dark>cancel</v-icon>
        Excluir
      </v-btn>
    </v-card-actions>
  </v-card>
</template>
<script>
export default {
  data() {
    return {
      numero: null,
      validade: null,
      bandeiraCartaoIcon: null,
      bandeiraCartao: null,
      loading: false,
      color: null
    }
  },
  created() {
    this.getBandeiraCartao();
  },
  methods: {
     excluirCartao() {
      this.$emit("excluirCartao");
    },
    getBandeiraCartao() {
      switch (this.bandeiraCartao) {
  case 'master':
    this.bandeiraCartaoIcon= 'fab fa-cc-mastercard',
    this.color= "deep-orange"
    break;
  case 'visa':
     this.bandeiraCartaoIcon= 'fab fa-cc-visa'
     this.color="blue accent-1"
     break;
  case 'amex':
    this.bandeiraCartaoIcon= 'fab fa-cc-amex'
    this.color= "indigo accent-2"
     break;
   case 'diners':
    this.bandeiraCartaoIcon= 'fab fa-cc-diners-club'
    this.color= "indigo darken-4"
     break;
  default:
    console.log(`Sorry, we are out of ${this.bandeira}.`);
    }
  }
},
}
</script>
<style>
.avatar-size {
  font-size: 60px !important;
}
.font-validade {
  font-size: 15px !important;
  color: black;
  font-weight: bold;
}
</style>
