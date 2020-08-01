<template>
  <v-container fluid>
    <v-row v-resize="onResize">
      <v-col cols="12" md="12">
        <div style="margin-left:50px">
          <div class="display-2">
            Cursos
          </div>
          <div>
            <p class="text-justify">
              Morbi mattis ullamcorper velit. Donec orci lectus, aliquam ut,
              faucibus non, euismod id, nulla. Fusce convallis metus id felis
              luctus adipiscing. Aenean massa. Vestibulum purus quam,
              scelerisque ut, mollis sed, nonummy id, metus. Nulla consequat
              massa quis enim. Praesent venenatis metus at tortor pulvinar
              varius. Donec venenatis vulputate lorem. Phasellus accumsan cursus
              velit. Pellentesque ut neque.
            </p>
          </div>
        </div>
      </v-col>
    </v-row>
    <v-row>
      <v-col cols="12" v-if="!isMobile" md="12">
        <v-slide-group
          v-if="isLoading"
          v-model="model"
          class="pa-4"
          center-active
        >
          <v-slide-item
            v-for="n in 10"
            :key="n"
            v-slot:default="{ active, toggle }"
          >
            <v-skeleton-loader
              :color="active ? 'primary' : 'grey lighten-1'"
              class="ma-10"
              heigth="50"
              width="300"
              max-width="300"
              type="card, paragraph, actions"
              v-bind:active="active"
              v-on:click.native="toggle"
              elevation="24"
            ></v-skeleton-loader>
          </v-slide-item>
        </v-slide-group>

        <v-slide-group
          v-model="model"
          class="pa-4"
          center-active
          style="margin-left: 0px; margin-right:0px"
          v-if="!isLoading"
          show-arrows
        >
          <v-slide-item
            v-for="(item, i) in cards"
            :key="i"
            v-slot:default="{ active, toggle }"
          >
            <curso
              :key="cursoComponent"
              v-bind:cursoItem="item"
              v-bind:active="active"
              v-on:click.native="toggle"
              ref="curso"
            >
            </curso>
          </v-slide-item>
        </v-slide-group>
      </v-col>
      <v-col v-if="isMobile">
        <v-carousel hide-delimiters>
          <v-carousel-item v-for="(item, i) in cards" :key="i">
            <curso :key="cursoComponent" v-bind:cursoItem="item" ref="curso" />
          </v-carousel-item>
        </v-carousel>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
import curso from "../components/Curso/Curso";
import { RepositoryFactory } from "./../Repositories/RepositoryFactory";
const CursoRepository = RepositoryFactory.get("curso");

export default {
  components: {
    curso,
  },
  data: () => ({
    tokenId: null,
    isLoading: true,
    model: null,
    cards: [],
    cursoComponent: null,
    isMobile: false,
  }),
  mounted() {
    this.fetch();
    this.onResize();
  },
  created() {},
  methods: {
    onResize() {
      this.isMobile = window.innerWidth < 600;
    },
    async fetch() {
      // this.isLoading = true;
      const { data } = await CursoRepository.get();
      this.cards = data;
      this.isLoading = false;
    },
  },
};
</script>
