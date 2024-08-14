namespace GerenciamentoBiblioteca.Model
{
    public class Emprestimo
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdLivro { get; set; }
        public decimal ValorEmprestimo { get; set; }
        public StatusEmprestimo Status{ get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolucao { get; set; }

        public Usuario Usuario{ get; set; }
        public Livro Livro{ get; set; }
    }

    public enum StatusEmprestimo
    {
        Emprestado = 0,
        Devolvido = 1
    }
}
