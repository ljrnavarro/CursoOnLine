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
import '@fortawesome/fontawesome-free/css/all.css' // Ensure you are using css-loader


Vue.use(Vuex);
Vue.use(VueResource);
Vue.use(VueSweetalert2);
//Vue.use(VueTheMask ,{ masked : false });
Vue.use(Vuetify)

// Initialize Firebase
var config = {
  apiKey: "xxxxxxxxxxx",
  authDomain: "xxxxxxxxxxxx",
  databaseURL: "xxxxxxxxxxxx",
  projectId: "xxxxxxxxxxxx",
  storageBucket: "xxxxxxxxxxxxxm",
  messagingSenderId: "xxxxxxxxxxxxxx",
  appId: "1:xxxxxxxxxxxxxxxxxxxx"
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
      template: '<App/>',
      render: h => h(App),
    }).$mount('#app');
  }
});
