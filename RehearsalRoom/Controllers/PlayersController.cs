using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RehearsalRoom.Model;
using RehearsalRoom.Repository;
using RehearsalRoom.Service;

namespace RehearsalRoom.Controllers
{
    public class PlayersController : Controller
    {
        private readonly IPlayerService _service;

        public PlayersController(IPlayerService service)
        {
            _service = service;
        }

        // GET: Players
        public async Task<IActionResult> Index()
        {
            return View(nameof(Index), await _service.GetAllAsync());
        }

        // GET: Players/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //TODO: ver si no estaria bueno poner un metodo que reciba una "query" en el service
            var player = await _service.FindByIdAsync(id);
            if (player == null)
            {
                return NotFound();
            }

            return View(nameof(Details), player);
        }

        // GET: Players/Create
        public IActionResult Create()
        {
            return View(nameof(Create));
        }

        // POST: Players/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PlayerId,LastName,FirstName,NickName")] Player player)
        {
            if (ModelState.IsValid)
            {
                await _service.AddAsync(player);
                return RedirectToAction(nameof(Index));
            }
            //TODO: si ahy combos inicializarlos antes
            return View(nameof(Create), player);
        }

        // GET: Players/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var player = await _service.FindByIdAsync(id);

            if (player == null)
                return NotFound();

            return View(nameof(Edit), player);
        }

        // POST: Players/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PlayerId,LastName,FirstName,NickName")] Player player)
        {
            if (id != player.PlayerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _service.UpdateAsync(player);
                }
                catch (DbUpdateConcurrencyException)
                {
                    //TODO: ver si esta exception no se tiene que manejar mas abajo
                    if (!PlayerExists(player.PlayerId))
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

            return View(nameof(Edit), player);
        }

        // GET: Players/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var player = await _service.FindByIdAsync(id);

            if (player == null)
                return NotFound();

            return View(nameof(Delete),player);
        }

        // POST: Players/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }

        private bool PlayerExists(int id)
        {
            return _service.FindById(id) != null;
            // _context.Players.Any(e => e.PlayerId == id);
        }
    }
}
