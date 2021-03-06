import Repository from "./Repository";

const resource = "/Curso";
export default {
  get() {
    return Repository.get(`${resource}`);
  },

  getCurso(cursoId) {
    return Repository.get(`${resource}/${cursoId}`);
  },

  create(payload) {
    return Repository.post(`${resource}`, payload);
  }
};
