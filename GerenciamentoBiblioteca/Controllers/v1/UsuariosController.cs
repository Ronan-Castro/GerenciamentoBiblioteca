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
    [Route("v{version:apiVersion}/usuarios")]
    public class UsuariosController(IUsuarioRepository usuarioRepository) : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository = usuarioRepository;

        [HttpGet]
        public async Task<IActionResult> BuscaTodosUsuariosAsync()
        {
            try
            {
                var listaUsuarios = await _usuarioRepository.ObterUsuarios();

                if (listaUsuarios is null)
                    return BadRequest(new ResultViewModel<string>("U001 - Usuario não encontrado"));


                return Ok(new ResultViewModel<IEnumerable<Usuario>>(listaUsuarios));
            }
            catch (Exception ex)
            {
                LogErro.SetLog(ex, "Erro UsuarioController - BuscaTodosUsuariosAsync");
                return StatusCode(500, new ResultViewModel<string>("U002 - Erro interno no servidor"));
            }
        }

        [HttpGet("{contaId:int}")]
        public async Task<IActionResult> BuscaUsuarioAsync(
           [FromRoute] int contaId
        )
        {
            try
            {
                var usuario = await _usuarioRepository.ObterUsuario(contaId);

                if (usuario is null)
                    return BadRequest(new ResultViewModel<string>("U001 - Usuario não encontrado"));


                return Ok(new ResultViewModel<Usuario>(usuario));
            }
            catch (Exception ex)
            {
                LogErro.SetLog(ex, "Erro UsuarioController - BuscaUsuarioAsync");
                return StatusCode(500, new ResultViewModel<string>("U002 - Erro interno no servidor"));
            }
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarUsuarioAsync(
           [FromBody] Usuario usuario
        )
        {
            if (usuario == null)
            {
                return BadRequest(new ResultViewModel<string>("U004 - O corpo da requisição está mal formatado!"));
            }
            if (!ModelState.IsValid)
                return BadRequest(new ResultViewModel<string>(ModelState.GetErrors()));

            try
            {
                await _usuarioRepository.AdicionarUsuario(usuario);

                return Ok(new ResultViewModel<Usuario>(usuario));
            }
            catch (Exception ex)
            {
                LogErro.SetLog(ex, "Erro UsuarioController - AdicionarUsuarioAsync");
                return StatusCode(500, new ResultViewModel<string>("U002 - Erro interno no servidor"));
            }
        }

        [HttpPut]
        public async Task<IActionResult> AtualizarUsuarioAsync(
           [FromBody] Usuario usuario
        )
        {

            if (usuario == null)
            {
                return BadRequest(new ResultViewModel<string>("U004 - O corpo da requisição está mal formatado!"));
            }
            if (!ModelState.IsValid)
                return BadRequest(new ResultViewModel<string>(ModelState.GetErrors()));

            try
            {
                await _usuarioRepository.AtualizarUsuario(usuario);

                return Ok(new ResultViewModel<Usuario>(usuario));
            }
            catch (Exception ex)
            {
                LogErro.SetLog(ex, "Erro UsuarioController - AtualizarUsuarioAsync");
                return StatusCode(500, new ResultViewModel<string>("U002 - Erro interno no servidor"));
            }
        }

        [HttpDelete("{contaId:int}")]
        public async Task<IActionResult> DeletarUsuarioAsync(
           [FromRoute] int contaId
        )
        {
            try
            {
                await _usuarioRepository.DeletarUsuario(contaId);


                return Ok(new ResultViewModel<string>("Usuario Removido Com Sucesso!"));
            }
            catch (Exception ex)
            {
                LogErro.SetLog(ex, "Erro UsuarioController - DeletarUsuarioAsync");
                return StatusCode(500, new ResultViewModel<string>("U002 - Erro interno no servidor"));
            }
        }

    }
}
