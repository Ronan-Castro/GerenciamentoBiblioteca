using GerenciamentoBiblioteca.Data;
using GerenciamentoBiblioteca.Model;
using GerenciamentoBiblioteca.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoBiblioteca.Repositories
{
    public class UsuarioRepository(LivrosDbContext _context) : IUsuarioRepository
    {
        public async Task AdicionarUsuario(Usuario usuario)
        {
            var novaChavePix = _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarUsuario(Usuario model)
        {
            var usuario = await _context
                .Usuarios
                .FirstOrDefaultAsync(x => x.Id == model.Id);

            if (usuario is null) return;

            usuario = model;

            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task DeletarUsuario(int id)
        {
            var usuario = await _context.Usuarios
                .AsNoTracking()
                .FirstOrDefaultAsync(_ => _.Id == id);

            if (usuario is null) return;

            _context.Usuarios.Remove(usuario);

            await _context.SaveChangesAsync();
        }

        public async Task<Usuario?> ObterUsuario(int id)
        {
            var usuario = await _context.Usuarios
                .AsNoTracking()
                .FirstOrDefaultAsync(_ => _.Id == id);
            if (usuario is null) return null;

            return usuario;
        }

        public async Task<IEnumerable<Usuario>> ObterUsuarios()
        {
            var usuarios = await _context.Usuarios.AsNoTracking().ToListAsync();
            if (usuarios is null) return null;

            return usuarios;
        }
    }
}
