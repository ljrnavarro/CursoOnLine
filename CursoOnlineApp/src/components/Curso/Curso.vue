<template>
  <v-card
    :color="active ? 'primary' : 'grey lighten-1'"
    class="mx-auto"
    elevation="24"
    style="max-width:auto; max-height:430px; margin-right: 40px !important; margin-left:40px !important"
  >
    <v-img
      class="white--text align-end"
      max-height="150px"
      max-width="300px"
      src="../../images/tech.jpg"
    >
      <v-card-title class="titulo">{{ cursoItem.titulo }}</v-card-title>
    </v-img>

    <v-card-subtitle style="font-weight: bold">{{cursoItem.nivel}}</v-card-subtitle>

    <v-card-text style="max-height:auto ; max-width:290px" class="text--primary text-justify">
      <div>{{ cursoItem.descricao  | CutText(200, '...') }}</div>
    </v-card-text>

    <v-card-actions>
      <v-btn color="orange" text>
        Share
      </v-btn>

      <v-btn color="orange" text>
        Explore
      </v-btn>
    </v-card-actions>
  </v-card>
</template>

<script>
export default {
  props: {
    cursoItem: {
      titulo: String,
      descricao: String,
      nivel: String,
      id: String,
    },
    active: Boolean,
  },
  data: () => ({
    model: null,
    Cursos : []
  }),
  created() {
  },
   filters: {
    CutText(text, length, suffix) {
      return text.substring(0, length) + suffix;
    }
  },
};
</script>

