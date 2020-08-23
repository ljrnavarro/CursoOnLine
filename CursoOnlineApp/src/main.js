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
import 'vuetify/dist/vuetify.css';
import '@fortawesome/fontawesome-free/css/all.css'
import MessageBoxMixins from './../src/mixins/MessageBoxMixins.js'


Vue.use(Vuex);
Vue.use(VueResource);
Vue.use(VueSweetalert2);
Vue.use(Vuetify)
Vue.mixin(MessageBoxMixins);

// Initialize Firebase
var config = {
  apiKey: "xxxxxxxxxx",
  authDomain: 'wwwwwwwwwwwwwwwwwwwwwwwwww',
  databaseURL: "xxxxxxxxx",
  projectId: "xxxxxxxxxxxxxx",
  storageBucket: "xxxxxxxxxxxxx",
  messagingSenderId: "xxxxxxxxxxxxxxxxx",
  appId: "1:xxxxxxxxxxxxxxxxxxxxxx"
};
firebase.initializeApp(config);


let app = '';
firebase.auth().onAuthStateChanged(function () {

  if (!app) {
    app = new Vue({
      icons: {
        iconfont: 'fa',
      },
      store,
      router,
      vuetify,
      //types,
      template: '<App/>',
      render: h => h(App),
    }).$mount('#app');
  }
});
