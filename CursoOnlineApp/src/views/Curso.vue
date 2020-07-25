<template>
  <v-container class="eee">
    <v-row>
      <v-col cols="10">
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
      <v-col cols="10">
        <v-sheet>
          <v-slide-group
            v-model="model"
            class=""
            center-active
            show-arrows
            v-if="!isLoading"
          >
            <v-slide-item
              v-for="(item, i) in cards"
              :key="i"
              v-slot:default="{ active, toggle }"
            >
              <div v-show="!isLoading">
                <curso
                  :key="cursoComponent"
                  v-bind:cursoItem="item"
                  v-bind:active="active"
                  v-on:click.native="toggle"
                  ref="curso"
                >
                </curso>
              </div>
            </v-slide-item>
          </v-slide-group>
        </v-sheet>
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
    isLoading: false,
    model: null,
    cards: [],
    cursoComponent: null,
  }),
  mounted() {
    this.fetch();
  },
  created() {},
  methods: {
    async fetch() {
      this.isLoading = true;
      const { data } = await CursoRepository.get();
      this.isLoading = false;
      this.cards = data;
    },
  },
};
</script>
