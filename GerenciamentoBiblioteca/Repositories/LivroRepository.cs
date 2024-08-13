using GerenciamentoBiblioteca.Data;
using GerenciamentoBiblioteca.Model;
using GerenciamentoBiblioteca.Repositories.Interface;

namespace GerenciamentoBiblioteca.Repositories
{
    public class LivroRepository(LivrosDbContext context) : ILivroRepository
    {
        private readonly LivrosDbContext _context = context;

        public Task AdicionarLivro(Livro livro)
        {
            throw new NotImplementedException();
        }

        public Task AtualizarLivro(Livro livro)
        {
            throw new NotImplementedException();
        }

        public Task DeletarLivro(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Livro?> ObterLivro(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Livro>> ObterLivros()
        {
            throw new NotImplementedException();
        }
    }
}
