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
    </v-row>
    <v-row>
      <v-col :cols="alterDataMode ? 12 : 6" :md="alterDataMode ? 12 : 6">
        <v-text-field
          v-model="email"
          :rules="[rules.requiredRule, rules.emailRule]"
          label="E-mail"
          required
        ></v-text-field>
      </v-col>
      <v-col cols="6" md="6" v-if="!alterDataMode">
        <v-text-field
          v-model="password"
          :append-icon="showPassword ? 'mdi-eye' : 'mdi-eye-off'"
          :rules="[rules.requiredRule, rules.passWordRule]"
          :type="showPassword ? 'text' : 'password'"
          name="input-10-1"
          label="Senha"
          autocomplete="new-password"
          @click:append="showPassword = !showPassword"
        ></v-text-field>
      </v-col>
    </v-row>
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
              :value="computedDateFormattedMomentjs"
              label="Data de Nascimento"
              :rules="[rules.requiredRule]"
              prepend-icon="event"
              readonly
              v-bind="attrs"
              v-on="on"
              @click:clear="dataNascimento = null"
            ></v-text-field>
          </template>
          <v-date-picker
            ref="picker"
            v-model="dataNascimento"
            no-title
            scrollable
            :rules="[rules.requiredRule]"
            :max="new Date().toISOString().substr(0, 10)"
            min="1950-01-01"
            @change="save"
            locale="pt-Br"
          >
            <v-spacer></v-spacer>
            <v-btn text color="primary" @click="menu = false">Cancelar</v-btn>
            <v-btn text color="primary" @click="$refs.menu.save(date)"
              >OK</v-btn
            >
          </v-date-picker>
        </v-menu>
      </v-col>
      <v-col cols="12" md="6" justify="center">
        <v-text-field
          v-model="cpf"
          label="CPF"
          :rules="[rules.cpfRule]"
          required
          v-mask ="{mask:'###.###.###-##', unmaskedVar: 'unmaskedCpf', number: false}"
        ></v-text-field>
      </v-col>
    </v-row>
  </v-form>
</template>

<script>
import moment from "moment";
import { mask } from '@titou10/v-mask'

export default {
  directives: { mask },
  data: () => ({
    date: null,
    dataNascimento: "",
    cpf: "",
    unmaskedCpf: "",
    valid: true,
    name: "",
    email: "",
    password: "",
    showPassword: false,
    select: null,
    checkbox: false,
    menu: false,
    alterDataMode : false,
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
          if (cpf == undefined || cpf == "") {
            return false;
          }

          cpf = cpf.replace(/\D/g, "");
          if (cpf.toString().length != 11 || /^(\d)\1{10}$/.test(cpf))
            return false;
          var result = true;
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
      passWordRule: (value) => {
        function validatePassword(passw) {
          var validated = true;
          if (passw.length < 8) validated = false;
          if (!/\d/.test(passw)) validated = false;
          if (!/[a-z]/.test(passw)) validated = false;
          if (!/[A-Z]/.test(passw)) validated = false;
          if (/[^0-9a-zA-Z!@#$%^&*]/.test(passw)) validated = false;
          return validated;
        }
        var validPassword = validatePassword(value);
        return (
          validPassword ||
          "Senha precisa conter 1 dígito, 1 letra maiúscula e mínimo de 8 caracteres."
        );
      },
    },
  }),
  computed: {
    computedDateFormattedMomentjs() {
      return this.dataNascimento
        ? moment(this.dataNascimento).format("DD/MM/YYYY")
        : "";
    }
  },
  watch: {
    menu(val) {
      val && setTimeout(() => (this.$refs.picker.activePicker = "YEAR"));
    },
  },
  methods: {
    save(date) {
      this.$refs.menu.save(date);
    },
    registrar() {
      this.$emit("registrarNovaConta");
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
