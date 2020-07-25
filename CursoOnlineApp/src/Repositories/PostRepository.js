import Repository from "./Repository";

const resource = "/posts";
export default {
  get() {
    return Repository.get(`${resource}`);
  },

  getPost(postId) {
    return Repository.get(`${resource}/${postId}`);
  },

  createPost(payload) {
    return Repository.post(`${resource}`, payload);
  }
};
