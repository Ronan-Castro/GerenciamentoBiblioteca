using GerenciamentoBiblioteca.Data;
using GerenciamentoBiblioteca.Model;
using GerenciamentoBiblioteca.Repositories.Interface;

namespace GerenciamentoBiblioteca.Repositories
{
    public class UsuarioRepository(LivrosDbContext context) : IUsuarioRepository
    {
        private readonly LivrosDbContext _context = context;

        public Task AdicionarUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Task AtualizarUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Task DeletarUsuario(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario?> ObterUsuario(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Usuario>> ObterUsuarios()
        {
            throw new NotImplementedException();
        }
    }
}
