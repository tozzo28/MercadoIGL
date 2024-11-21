using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MercadoIGL.Models;
using Microsoft.Data.SqlClient;

namespace MercadoIGL.Controllers
{
    public class VendasController : Controller
    {
        private readonly Contexto _context;

        public VendasController(Contexto context)
        {
            _context = context;
        }

        // GET: Vendas
        public async Task<IActionResult> Index()
        {
            var vendas = _context.Vendas
                .Include(v => v.produto)
                .Include(v => v.cliente)
                .Include(v => v.funcionario);
            return View(await vendas.ToListAsync());
        }

        // GET: Vendas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Vendas == null)
            {
                return NotFound();
            }

            var venda = await _context.Vendas
                .Include(v => v.produto)
                .Include(v => v.cliente)
                .Include(v => v.funcionario)
                .FirstOrDefaultAsync(m => m.idVenda == id);
            if (venda == null)
            {
                return NotFound();
            }

            return View(venda);
        }

        // GET: Vendas/Create
        public IActionResult Create()
        {
            ViewBag.Produtos = new SelectList(_context.Produtos, "idProduto", "descricao");
            ViewBag.Clientes = new SelectList(_context.Clientes, "cpfCliente", "nome");
            ViewBag.Funcionarios = new SelectList(_context.Funcionarios, "cpfFuncionario", "nome");
            return View();
        }

        // POST: Vendas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProdutoID,ClienteID,FuncionarioID,QntdVendida,valorTotal,data")] Venda venda)
        {
            if (ModelState.IsValid)
            {
                // Chama a stored procedure para inserir uma nova venda
                await _context.Database.ExecuteSqlRawAsync("EXEC InsertVenda @ProdutoID, @ClienteID, @FuncionarioID, @QntdVendida, @valorTotal, @data",
                    new SqlParameter("@ProdutoID", venda.ProdutoID),
                    new SqlParameter("@ClienteID", venda.ClienteID),
                    new SqlParameter("@FuncionarioID", venda.FuncionarioID),
                    new SqlParameter("@QntdVendida", venda.QntdVendida),
                    new SqlParameter("@valorTotal", venda.valorTotal),
                    new SqlParameter("@data", venda.data)
                );

                return RedirectToAction(nameof(Index));
            }

            ViewBag.Produtos = new SelectList(_context.Produtos, "idProduto", "descricao", venda.ProdutoID);
            ViewBag.Clientes = new SelectList(_context.Clientes, "cpfCliente", "nome", venda.ClienteID);
            ViewBag.Funcionarios = new SelectList(_context.Funcionarios, "cpfFuncionario", "nome", venda.FuncionarioID);
            return View(venda);
        }

        // GET: Vendas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Vendas == null)
            {
                return NotFound();
            }

            var venda = await _context.Vendas.FindAsync(id);
            if (venda == null)
            {
                return NotFound();
            }

            ViewBag.Produtos = new SelectList(_context.Produtos, "idProduto", "descricao", venda.ProdutoID);
            ViewBag.Clientes = new SelectList(_context.Clientes, "cpfCliente", "nome", venda.ClienteID);
            ViewBag.Funcionarios = new SelectList(_context.Funcionarios, "cpfFuncionario", "nome", venda.FuncionarioID);
            return View(venda);
        }

        // POST: Vendas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idVenda,ProdutoID,ClienteID,FuncionarioID,QntdVendida,valorTotal,data")] Venda venda)
        {
            if (id != venda.idVenda)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(venda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VendaExists(venda.idVenda))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Produtos = new SelectList(_context.Produtos, "idProduto", "descricao", venda.ProdutoID);
            ViewBag.Clientes = new SelectList(_context.Clientes, "cpfCliente", "nome", venda.ClienteID);
            ViewBag.Funcionarios = new SelectList(_context.Funcionarios, "cpfFuncionario", "nome", venda.FuncionarioID);
            return View(venda);
        }

        // GET: Vendas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Vendas == null)
            {
                return NotFound();
            }

            var venda = await _context.Vendas
                .Include(v => v.produto)
                .Include(v => v.cliente)
                .Include(v => v.funcionario)
                .FirstOrDefaultAsync(m => m.idVenda == id);
            if (venda == null)
            {
                return NotFound();
            }

            return View(venda);
        }

        // POST: Vendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var venda = await _context.Vendas.FindAsync(id);
            if (venda != null)
            {
                _context.Vendas.Remove(venda);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool VendaExists(int id)
        {
            return _context.Vendas.Any(e => e.idVenda == id);
        }
    }
}
