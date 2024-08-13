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
    [Route("v{version:apiVersion}/emprestimos")]
    public class EmprestimosController(IEmprestimoRepository emprestimoRepository) : ControllerBase
    {
        private readonly IEmprestimoRepository _emprestimoRepository = emprestimoRepository;

        [HttpGet]
        public async Task<IActionResult> BuscaTodosEmprestimosAsync()
        {
            try
            {
                var listaEmprestimos = await _emprestimoRepository.ObterEmprestimos();

                if (listaEmprestimos is null)
                    return BadRequest(new ResultViewModel<string>("E001 - Emprestimo não encontrado"));


                return Ok(new ResultViewModel<IEnumerable<Emprestimo>>(listaEmprestimos));
            }
            catch (Exception ex)
            {
                LogErro.SetLog(ex, "Erro EmprestimosController - BuscaTodosEmprestimosAsync");
                return StatusCode(500, new ResultViewModel<string>("E002 - Erro interno no servidor"));
            }
        }

        [HttpGet("{contaId:int}")]
        public async Task<IActionResult> BuscarEmprestimoAsync(
           [FromRoute] int contaId
        )
        {
            try
            {
                var emprestimo = await _emprestimoRepository.ObterEmprestimo(contaId);

                if (emprestimo is null)
                    return BadRequest(new ResultViewModel<string>("E001 - Transação não encontrada"));


                return Ok(new ResultViewModel<Emprestimo>(emprestimo));
            }
            catch (Exception ex)
            {
                LogErro.SetLog(ex, "Erro EmprestimosController - BuscarEmprestimoAsync");
                return StatusCode(500, new ResultViewModel<string>("E002 - Erro interno no servidor"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarEmprestimoAsync(
           [FromBody] Emprestimo emprestimo
        )
        {
            if (emprestimo == null)
            {
                return BadRequest(new ResultViewModel<string>("E004 - O corpo da requisição está mal formatado!"));
            }
            if (!ModelState.IsValid)
                return BadRequest(new ResultViewModel<string>(ModelState.GetErrors()));

            try
            {
                await _emprestimoRepository.AdicionarEmprestimo(emprestimo);

                return Ok(new ResultViewModel<Emprestimo>(emprestimo));
            }
            catch (Exception ex)
            {
                LogErro.SetLog(ex, "Erro EmprestimosController - AdicionarEmprestimoAsync");
                return StatusCode(500, new ResultViewModel<string>("E002 - Erro interno no servidor"));
            }
        }

        [HttpPut]
        public async Task<IActionResult> AtualizarEmprestimoAsync(
           [FromBody] Emprestimo emprestimo
        )
        {

            if (emprestimo == null)
            {
                return BadRequest(new ResultViewModel<string>("E004 - O corpo da requisição está mal formatado!"));
            }
            if (!ModelState.IsValid)
                return BadRequest(new ResultViewModel<string>(ModelState.GetErrors()));

            try
            {
                await _emprestimoRepository.AtualizarEmprestimo(emprestimo);

                return Ok(new ResultViewModel<Emprestimo>(emprestimo));
            }
            catch (Exception ex)
            {
                LogErro.SetLog(ex, "Erro EmprestimosController - AtualizarEmprestimoAsync");
                return StatusCode(500, new ResultViewModel<string>("E002 - Erro interno no servidor"));
            }
        }

        [HttpDelete("{contaId:int}")]
        public async Task<IActionResult> DeletarEmprestimoAsync(
           [FromRoute] int contaId
        )
        {
            try
            {
                await _emprestimoRepository.DeletarEmprestimo(contaId);


                return Ok(new ResultViewModel<string>("Emprestimo Removido Com Sucesso!"));
            }
            catch (Exception ex)
            {
                LogErro.SetLog(ex, "Erro EmprestimosController - DeletarEmprestimoAsync");
                return StatusCode(500, new ResultViewModel<string>("E002 - Erro interno no servidor"));
            }
        }
    }
}
