<template>
  <v-card
    :color="active ? 'primary' : 'grey lighten-1'"
    class="ma-10"
    heigth="50"
    width="300"
    elevation="24"
  >
    <v-img
      class="white--text align-end"
     
      src="../../images/tech.jpg"
    >
      <v-card-title class="titulo">{{ cursoItem.titulo }}</v-card-title>
    </v-img>

    <v-card-subtitle class="pb-0">{{cursoItem.nivel}}</v-card-subtitle>

    <v-card-text style="height:150px" class="text--primary text-justify">
      <div>{{ cursoItem.descricao  | CutText(210, '...') }}</div>
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

