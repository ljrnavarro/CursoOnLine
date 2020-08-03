import axios from "axios";
import store from "../store/store";

// You can use your own logic to set your local or production domain
const baseDomain = "/api/v1";
// The base URL is empty this time due we are using the jsonplaceholder API
const baseURL = `${baseDomain}`;


const http = axios.create({
    baseURL,
    headers: {
        'Content-Type': 'application/json',
        'Access-Control-Allow-Origin': '*'
    },
});

http.interceptors.response.use(function (response) {
    return response;
  }, function (error) {
    return Promise.reject(error);
  });

http.interceptors.request.use(function (config) {
    const token = store.state.token;
    config.headers.Authorization = `Bearer ${token}`
    return config
}, function (erro) {
    console.log("erro", erro)
    return Promise.reject(erro)
})

export default http
