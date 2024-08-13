using GerenciamentoBiblioteca.Model;

namespace GerenciamentoBiblioteca.Repositories.Interface
{
    public interface ILivroRepository
    {
        Task<IEnumerable<Livro>> ObterLivros();
        Task<Livro?> ObterLivro(int id);
        Task AdicionarLivro(Livro livro);
        Task DeletarLivro(int id);
        Task AtualizarLivro(Livro livro);
    }
}
