using GerenciamentoBiblioteca.Data;
using GerenciamentoBiblioteca.Model;
using GerenciamentoBiblioteca.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoBiblioteca.Repositories
{
    public class EmprestimoRepository(LivrosDbContext _context) : IEmprestimoRepository
    {
        public async Task AdicionarEmprestimo(Emprestimo emprestimo)
        {
            var novaChavePix = _context.Emprestimos.Add(emprestimo);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarEmprestimo(Emprestimo model)
        {
            var emprestimo = await _context
                .Emprestimos
                .FirstOrDefaultAsync(x => x.Id == model.Id);

            if (emprestimo is null) return;

            emprestimo = model;

            _context.Emprestimos.Update(emprestimo);
            await _context.SaveChangesAsync();
        }

        public async Task DeletarEmprestimo(int id)
        {
            var emprestimo = await _context.Emprestimos
                .AsNoTracking()
                .FirstOrDefaultAsync(_ => _.Id == id);

            if (emprestimo is null) return;

            _context.Emprestimos.Remove(emprestimo);

            await _context.SaveChangesAsync();
        }

        public async Task<Emprestimo?> ObterEmprestimo(int id)
        {
            var emprestimo = await _context.Emprestimos
                .AsNoTracking()
                .FirstOrDefaultAsync(_ => _.Id == id);
            if (emprestimo is null) return null;

            return emprestimo;
        }

        public async Task<IEnumerable<Emprestimo>> ObterEmprestimos()
        {
            var emprestimos = await _context.Emprestimos.AsNoTracking().ToListAsync();
            if (emprestimos is null) return null;

            return emprestimos;
        }
    }
}
