using GerenciamentoBiblioteca.Data;
using GerenciamentoBiblioteca.Model;
using GerenciamentoBiblioteca.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoBiblioteca.Repositories
{
    public class LivroRepository(LivrosDbContext _context) : ILivroRepository
    {
        public async Task AdicionarLivro(Livro livro)
        {
            var novaChavePix = _context.Livros.Add(livro);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarLivro(Livro model)
        {
            var livro = await _context
                .Livros
                .FirstOrDefaultAsync(x => x.Id == model.Id);

            if (livro is null) return;

            livro = model;

            _context.Livros.Update(livro);
            await _context.SaveChangesAsync();
        }

        public async Task DeletarLivro(int id)
        {
            var livro = await _context.Livros
                .AsNoTracking()
                .FirstOrDefaultAsync(_ => _.Id == id);

            if (livro is null) return;

            _context.Livros.Remove(livro);

            await _context.SaveChangesAsync();
        }

        public async Task<Livro?> ObterLivro(int id)
        {
            var livro = await _context.Livros
                .AsNoTracking()
                .FirstOrDefaultAsync(_ => _.Id == id);
            if (livro is null) return null;

            return livro;
        }

        public async Task<IEnumerable<Livro>> ObterLivros()
        {
            var livros = await _context.Livros.AsNoTracking().ToListAsync();
            if (livros is null) return null;

            return livros;
        }
    }
}
