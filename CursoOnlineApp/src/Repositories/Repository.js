import axios from "axios";
import store from "../store/store";

// You can use your own logic to set your local or production domain
const baseDomain = "http://localhost:5000/v1/";
// The base URL is empty this time due we are using the jsonplaceholder API
const baseURL = `${baseDomain}`;
console.log("repository", store.state.tokenId);


const http = axios.create({
    baseURL,
    headers: {
        'Content-Type': 'application/json',
        'Access-Control-Allow-Origin': '*'
    },
});

http.interceptors.response.use(function (response) {
    console.log("response");
    return response;
  }, function (error) {
    console.log("response");
    // Any status codes that falls outside the range of 2xx cause this function to trigger
    // Do something with response error
    return Promise.reject(error);
  });

http.interceptors.request.use(function (config) {
    console.log("tokenSession2", store.state);
    const token = store.state.token;
    config.headers.Authorization = `Bearer ${token}`
    return config
}, function (erro) {
    console.log("erro", erro)
    return Promise.reject(erro)
})

export default http
