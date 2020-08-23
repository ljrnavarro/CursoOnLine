import Repository from "./Repository";

const resource = "/Aluno";
export default {
  get() {
    return Repository.get(`${resource}`);
  },

  getAluno(alunoId) {
    return Repository.get(`${resource}/${alunoId}`);
  },

  create(payload) {
    return Repository.post(`${resource}`, payload);
  },

  update(payload) {
    return Repository.put(`${resource}`, payload);
  }
};
