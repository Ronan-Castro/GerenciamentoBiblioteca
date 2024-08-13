using GerenciamentoBiblioteca.Utils;
using Asp.Versioning;
using GerenciamentoBiblioteca.Extensions;
using GerenciamentoBiblioteca.Model;
using GerenciamentoBiblioteca.Repositories.Interface;
using GerenciamentoBiblioteca.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoBiblioteca.Controllers.v1
{
    [ApiVersion(1.0)]
    [ApiController]
    [Route("v{version:apiVersion}/livros")]
    public class LivrosController(ILivroRepository livroRepository) : ControllerBase
    {
        private readonly ILivroRepository _livroRepository = livroRepository;

        [HttpGet]
        public async Task<IActionResult> BuscaTodosLivrosAsync()
        {
            try
            {
                var listaLivros = await _livroRepository.ObterLivros();

                if (listaLivros is null)
                    return BadRequest(new ResultViewModel<string>("L001 - Livro não encontrado"));


                return Ok(new ResultViewModel<IEnumerable<Livro>>(listaLivros));
            }
            catch (Exception ex)
            {
                LogErro.SetLog(ex, "Erro LivrosController - BuscaTodosLivrosAsync");
                return StatusCode(500, new ResultViewModel<string>("L002 - Erro interno no servidor"));
            }
        }

        [HttpGet("{contaId:int}")]
        public async Task<IActionResult> BuscarLivroAsync(
           [FromRoute] int contaId
        )
        {
            try
            {
                var livro = await _livroRepository.ObterLivro(contaId);

                if (livro is null)
                    return BadRequest(new ResultViewModel<string>("L001 - Transação não encontrada"));


                return Ok(new ResultViewModel<Livro>(livro));
            }
            catch (Exception ex)
            {
                LogErro.SetLog(ex, "Erro LivrosController - BuscarLivroAsync");
                return StatusCode(500, new ResultViewModel<string>("L002 - Erro interno no servidor"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarLivroAsync(
           [FromBody] Livro livro
        )
        {
            if (livro == null)
            {
                return BadRequest(new ResultViewModel<string>("L004 - O corpo da requisição está mal formatado!"));
            }
            if (!ModelState.IsValid)
                return BadRequest(new ResultViewModel<string>(ModelState.GetErrors()));

            try
            {
                await _livroRepository.AdicionarLivro(livro);

                return Ok(new ResultViewModel<Livro>(livro));
            }
            catch (Exception ex)
            {
                LogErro.SetLog(ex, "Erro LivrosController - AdicionarLivroAsync");
                return StatusCode(500, new ResultViewModel<string>("L002 - Erro interno no servidor"));
            }
        }

        [HttpPut]
        public async Task<IActionResult> AtualizarLivroAsync(
           [FromBody] Livro livro
        )
        {

            if (livro == null)
            {
                return BadRequest(new ResultViewModel<string>("L004 - O corpo da requisição está mal formatado!"));
            }
            if (!ModelState.IsValid)
                return BadRequest(new ResultViewModel<string>(ModelState.GetErrors()));

            try
            {
                await _livroRepository.AtualizarLivro(livro);

                return Ok(new ResultViewModel<Livro>(livro));
            }
            catch (Exception ex)
            {
                LogErro.SetLog(ex, "Erro LivrosController - AtualizarLivroAsync");
                return StatusCode(500, new ResultViewModel<string>("L002 - Erro interno no servidor"));
            }
        }

        [HttpDelete("{contaId:int}")]
        public async Task<IActionResult> DeletarLivroAsync(
           [FromRoute] int contaId
        )
        {
            try
            {
                await _livroRepository.DeletarLivro(contaId);


                return Ok(new ResultViewModel<string>("Livro Removido Com Sucesso!"));
            }
            catch (Exception ex)
            {
                LogErro.SetLog(ex, "Erro LivrosController - DeletarLivroAsync");
                return StatusCode(500, new ResultViewModel<string>("L002 - Erro interno no servidor"));
            }
        }
    }
}
