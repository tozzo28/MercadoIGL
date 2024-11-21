using Microsoft.AspNetCore.Mvc;
using MercadoIGL.Models;
using System.Threading.Tasks;

namespace MercadoIGL.Controllers
{
    public class CadastroController : Controller
    {
        private readonly Contexto _context;

        // Construtor para injetar o Contexto
        public CadastroController(Contexto context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Cadastro")] // Define a rota como /Cadastro
        public IActionResult NovoCadastro()
        {
            return View(); // Retorna a view NovoCadastro.cshtml
        }

        [HttpPost]
        [Route("Cadastro")] // Define a rota como /Cadastro
        public async Task<IActionResult> NovoCadastro(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                // Criptografa a senha antes de salvar no banco
                usuario.SenhaHash = BCrypt.Net.BCrypt.HashPassword(usuario.SenhaHash);
                usuario.DataCriacao = DateTime.Now;

                // Salva no banco de dados
                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();

                // Redireciona para a página de login após o cadastro
                return RedirectToAction("Login", "Account");
            }

            return View(usuario); // Retorna à mesma view caso haja erro
        }
    }
}
