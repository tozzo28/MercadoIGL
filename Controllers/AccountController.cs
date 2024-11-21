using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MercadoIGL.Models;
using System.Threading.Tasks;

namespace MercadoIGL.Controllers
{
    public class AccountController : Controller
    {
        private readonly Contexto _context;

        // Injeção de dependência para o contexto
        public AccountController(Contexto context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Login")] // Define a rota como /Login
        public IActionResult Login()
        {
            return View(); // Retorna a view Login.cshtml
        }

        [HttpPost]
        [Route("Login")] // Define a rota como /Login
        public async Task<IActionResult> Login(string email, string password)
        {
            // Busca o usuário no banco de dados
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == email);

            if (usuario != null && BCrypt.Net.BCrypt.Verify(password, usuario.SenhaHash))
            {
                // Login bem-sucedido
                TempData["Mensagem"] = "Login realizado com sucesso!";
                return RedirectToAction("Index", "Home");
            }

            // Caso o login falhe
            ModelState.AddModelError(string.Empty, "Email ou senha inválidos.");
            return View();
        }
    }
}
