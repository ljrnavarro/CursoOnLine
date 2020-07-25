import PostsRepository from "./PostRepository";
import CursoRepository from "./CursoRepository";

const repositories = {
  posts: PostsRepository,
  curso: CursoRepository
  // other repositories ...
};

export const RepositoryFactory = {
  get: name => repositories[name]
};
