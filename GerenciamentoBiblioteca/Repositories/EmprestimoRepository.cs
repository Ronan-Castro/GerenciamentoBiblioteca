using GerenciamentoBiblioteca.Data;
using GerenciamentoBiblioteca.Model;
using GerenciamentoBiblioteca.Repositories.Interface;

namespace GerenciamentoBiblioteca.Repositories
{
    public class EmprestimoRepository(LivrosDbContext context) : IEmprestimoRepository
    {
        private readonly LivrosDbContext _context = context;

        public Task AdicionarEmprestimo(Emprestimo emprestimo)
        {
            throw new NotImplementedException();
        }

        public Task AtualizarEmprestimo(Emprestimo emprestimo)
        {
            throw new NotImplementedException();
        }

        public Task DeletarEmprestimo(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Emprestimo?> ObterEmprestimo(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Emprestimo>> ObterEmprestimos()
        {
            throw new NotImplementedException();
        }
    }
}
