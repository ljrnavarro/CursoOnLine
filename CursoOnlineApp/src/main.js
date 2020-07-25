import Vue from 'vue'
import App from './App.vue'
import router from './router'
import VueResource from 'vue-resource'
import firebase from 'firebase'
import vuetify from "./plugins/vuetify"
import Vuetify from 'vuetify'
import VueSweetalert2 from 'vue-sweetalert2';
import 'sweetalert2/dist/sweetalert2.min.css';
import "vue2-animate/dist/vue2-animate.min.css";
import Vuex from 'vuex';
import store  from "./store/store"
import VueTheMask from "vue-the-mask"
import 'vuetify/dist/vuetify.css';


Vue.use(Vuex);
Vue.use(VueResource);
Vue.use(VueSweetalert2);
Vue.use(VueTheMask);
Vue.use(Vuetify)

// Initialize Firebase
var config = {
  apiKey: "AIzaSyBGd-p4l_PLz0MifncuyUjO9VG9afF-1GQ",
  authDomain: "cursoonlie.firebaseapp.com",
  databaseURL: "https://cursoonlie.firebaseio.com",
  projectId: "cursoonlie",
  storageBucket: "cursoonlie.appspot.com",
  messagingSenderId: "878472732578",
  appId: "1:878472732578:web:c35d9f56dc5455c9fb5cfb"
};
firebase.initializeApp(config);


let app = '';
firebase.auth().onAuthStateChanged(function () {

  if (!app) {
    app = new Vue({
      store,
      router,
      vuetify,
      template: '<App/>',
      render: h => h(App),
    }).$mount('#app');
  }
});
