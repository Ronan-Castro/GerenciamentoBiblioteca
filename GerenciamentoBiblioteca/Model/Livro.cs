using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GerenciamentoBiblioteca.Model
{
    public class Livro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string ISBN { get; set; }
        public int Estoque { get; set; }
        public int AnoPublicacao{ get; set; }

        public List<Emprestimo> Emprestimos { get; set; }

    }
}
