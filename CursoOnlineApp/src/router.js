import Vue from "vue";
import Router from "vue-router";
import firebase from "firebase";
import Login from "./views/Login";
import AppLayout from "./Layouts/AppLayout";
import NovaConta from "./views/NovaConta";
import DadosConta from "./views/DadosConta";
import Cartao from "./components/Cartao/Cartao";
import Sobre from "./views/Sobre";
import Curso from "./views/Curso";

Vue.use(Router);

const router = new Router({
  duplicateNavigationPolicy: 'ignore',
  mode: 'history',
  routes: [
    {
      path: "*",
      redirect: "/Login",
      meta: {
        baseLayout: true,
      },
    },
    {
      path: "/",
      redirect: "/Login",
      meta: {
        baseLayout: true,
      },
    },
    {
      path: "/Login",
      name: "Login",
      component: Login,
      meta: {
        baseLayout: true,
      },
    },
    {
      path: "/NovaConta",
      name: "NovaConta",
      component: NovaConta,
      meta: {
        baseLayout: true,
      },
    },
    {
      path: "/DadosConta",
      name: "DadosConta",
      component: DadosConta,
      meta: {
        requiresAuth: true,
      },
    },
    {
      path: "/AppLayout",
      name: "AppLayout",
      component: AppLayout,
      meta: {
        requiresAuth: true,
        baseLayout: false,
      },
    },
    {
      path: "/Cartao",
      name: "Cartao",
      component: Cartao,
      meta: {
        requiresAuth: true,
        baseLayout: false,
      },
    },
    {
      path: "/Curso",
      name: "Curso",
      component: Curso,
      meta: {
        requiresAuth: true,
        baseLayout: false
      },
    },
    {
      path: "/Sobre",
      name: "Sobre",
      component: Sobre,
      meta: {
        requiresAuth: true,
        baseLayout: false
      },
    },
   ],
});



router.beforeEach((to, from, next) => {
  const currentUser = firebase.auth().currentUser;
  const requiresAuth = to.matched.some((record) => record.meta.requiresAuth);
  if (requiresAuth && !currentUser) next("Login");
  else next();
});

export default router;
