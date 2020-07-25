<template>
  <v-form ref="form" v-model="valid" lazy-validation outlined width="50px">
    <v-row>
      <v-col cols="12" md="12">
        <v-text-field
          v-model="name"
          :counter="50"
          :rules="[rules.requiredRule, rules.nameRule]"
          label="Nome"
          required
        ></v-text-field>
      </v-col>

      <v-col cols="12" md="12">
        <v-text-field
          v-model="email"
          :rules="[rules.requiredRule, rules.emailRule]"
          label="E-mail"
          required
        ></v-text-field>
      </v-col>

      <v-row>
        <v-col cols="12" md="6">
          <v-menu
        ref="menu"
        v-model="menu"
        :close-on-content-click="false"
        :return-value.sync="date"
        transition="scale-transition"
        offset-y
        min-width="290px"
      >
        <template v-slot:activator="{ on, attrs }">
          <v-text-field
            v-model="date"
            label="Data de Nascimento"
            prepend-icon="event"
            readonly
            v-bind="attrs"
            v-on="on"
          ></v-text-field>
        </template>
        <v-date-picker v-model="date" no-title scrollable>
          <v-spacer></v-spacer>
          <v-btn text color="primary" @click="menu = false">Cancel</v-btn>
          <v-btn text color="primary" @click="$refs.menu.save(date)">OK</v-btn>
        </v-date-picker>
      </v-menu>
        </v-col>
        <v-col cols="12" md="6" justify="center">
          <v-text-field
            v-model="cpf"
            return-masked-value
            label="CPF"
            :rules="[rules.cpfRule]"
            required
            v-mask="'###.###.###-##'"
          ></v-text-field>
        </v-col>
      </v-row>

      <v-row justify="center">
      
          <v-btn
            :disabled="!valid"
            color="success"
            class="mr-4"
            @click="validate"
          >
            Validate
          </v-btn>

          <v-btn color="error" class="mr-4" @click="reset">
            Reset Form
          </v-btn>

          <v-btn color="warning" @click="resetValidation">
            Reset Validation
          </v-btn>
      </v-row>
    </v-row>
  </v-form>
</template>

<script>
export default {
  data: () => ({
   date: new Date().toISOString().substr(0, 10),
     menu: false,
    dataNascimento: "",
    cpf: "",
    valid: true,
    name: "",
    email: "",
    select: null,
    checkbox: false,
    rules: {
      requiredRule: (value) => !!value || "Obrigatório.",
      counterRule: (value) => value.length <= 20 || "Máximo 20 caracteres.",
      nameRule: (v) => (v && v.length <= 50) || "Máximo de 50 caracteres.",
      emailRule: (value) => {
        const pattern = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        return pattern.test(value) || "Email Inválido";
      },
      cpfRule: (value) => {
        function validateCpf(cpf) {
          console.log("entrou", cpf);

          if (cpf == undefined || cpf == "") {
            console.log("validadecpf", false);
            return false;
          }

          cpf = cpf.replace(/\D/g, "");
          if (cpf.toString().length != 11 || /^(\d)\1{10}$/.test(cpf))
            return false;
          var result = true;
          console.log("validadecpf", result);
          [9, 10].forEach(function(j) {
            var soma = 0,
              r;
            cpf
              .split(/(?=)/)
              .splice(0, j)
              .forEach(function(e, i) {
                soma += parseInt(e) * (j + 2 - (i + 1));
              });
            r = soma % 11;
            r = r < 2 ? 0 : 11 - r;
            if (r != cpf.substring(j, j + 1)) result = false;
          });
          return result;
        }
        var validCpf = validateCpf(value);
        return validCpf || "CPF Inválido.";
      },
    },
  }),

  methods: {
    validateCpf: function(cpf) {
      console.log("entrou");

      if (cpf == undefined || cpf == "") {
        console.log("validadecpf", false);
        return false;
      }

      cpf = cpf.replace(/\D/g, "");
      if (cpf.toString().length != 11 || /^(\d)\1{10}$/.test(cpf)) return false;
      var result = true;
      console.log("validadecpf", result);
      [9, 10].forEach(function(j) {
        var soma = 0,
          r;
        cpf
          .split(/(?=)/)
          .splice(0, j)
          .forEach(function(e, i) {
            soma += parseInt(e) * (j + 2 - (i + 1));
          });
        r = soma % 11;
        r = r < 2 ? 0 : 11 - r;
        if (r != cpf.substring(j, j + 1)) result = false;
      });
      return result;
    },
    validate() {
      this.$refs.form.validate();
    },
    reset() {
      this.$refs.form.reset();
    },
    resetValidation() {
      this.$refs.form.resetValidation();
    },
  },
};
</script>
