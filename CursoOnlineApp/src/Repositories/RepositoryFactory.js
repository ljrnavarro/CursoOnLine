import PostsRepository from "./PostRepository";
import CursoRepository from "./CursoRepository";
import AlunoRepository from "./AlunoRepository";

const repositories = {
  posts: PostsRepository,
  curso: CursoRepository,
  aluno: AlunoRepository
  // other repositories ...
};

export const RepositoryFactory = {
  get: name => repositories[name]
};
