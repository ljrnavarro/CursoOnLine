import Repository from "./Repository";

const resource = "/Curso";
export default {
  get() {
    return Repository.get(`${resource}`);
  },

  getCurso(cursoId) {
    return Repository.get(`${resource}/${cursoId}`);
  },

  createCurso(payload) {
    return Repository.post(`${resource}`, payload);
  }
};
