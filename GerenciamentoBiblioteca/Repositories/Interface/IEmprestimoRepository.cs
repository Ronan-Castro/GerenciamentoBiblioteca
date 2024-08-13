using GerenciamentoBiblioteca.Model;

namespace GerenciamentoBiblioteca.Repositories.Interface
{
    public interface IEmprestimoRepository
    {
        Task<IEnumerable<Emprestimo>> ObterEmprestimos();
        Task<Emprestimo?> ObterEmprestimo(int id);
        Task AdicionarEmprestimo(Emprestimo emprestimo);
        Task DeletarEmprestimo(int id);
        Task AtualizarEmprestimo(Emprestimo emprestimo);
    }
}
