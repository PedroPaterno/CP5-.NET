using CrudMongoDB.Config;
using CrudMongoDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudMongoDB.Controllers {
    public class BicicletasController : Controller {
        private readonly BicicletaContexto _bicicletaContexto;

        public BicicletasController(IOptions<ConfigDB> opcoes) {
            _bicicletaContexto = new BicicletaContexto(opcoes);
        }

        public async Task<IActionResult> Index() {
            return View(await _bicicletaContexto.Bicicletas.Find(b => true).ToListAsync());
        }

        [HttpGet]
        public IActionResult NovaBicicleta() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NovaBicicleta(Bicicleta bicicleta) {
            bicicleta.BicicletaId = Guid.NewGuid();
            await _bicicletaContexto.Bicicletas.InsertOneAsync(bicicleta);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> AtualizarBicicleta(Guid bicicletaId) {
            Bicicleta bicicleta = await _bicicletaContexto.Bicicletas.Find(b => b.BicicletaId == bicicletaId).FirstOrDefaultAsync();
            return View(bicicleta);
        }

        [HttpPost]
        public async Task<IActionResult> AtualizarBicicleta(Bicicleta bicicleta) {
            await _bicicletaContexto.Bicicletas.ReplaceOneAsync(b => b.BicicletaId == bicicleta.BicicletaId, bicicleta);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> ExcluirBicicleta(Guid bicicletaId) {
            await _bicicletaContexto.Bicicletas.DeleteOneAsync(b => b.BicicletaId == bicicletaId);
            return RedirectToAction(nameof(Index));
        }
    }
}
