using GerenciamentoBiblioteca.Model;
using System.Text.RegularExpressions;

namespace GerenciamentoBiblioteca.Repositories.Interface
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> ObterUsuarios();
        Task<Usuario?> ObterUsuario(int id);
        Task AdicionarUsuario(Usuario usuario);
        Task DeletarUsuario(int id);
        Task AtualizarUsuario(Usuario usuario);
    }
}
