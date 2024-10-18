﻿using Microsoft.AspNetCore.Mvc;
using EventEase2024.Models;
using Microsoft.EntityFrameworkCore;


namespace EventEase2024.Controllers
{
    public class EventosController : Controller
    {
        private readonly AppDbContext _context;

        public EventosController (AppDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {

            var dados = await _context.Eventos.ToListAsync();
            return View(dados);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> Create(Evento evento)
        {

            if (ModelState.IsValid)
            {
                _context.Eventos.Add(evento);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(evento);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();
            var dados = await _context.Eventos.FindAsync(id);

            if(dados ==null)
                return NotFound();

            return View(dados);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Evento evento)
        {
            if (id != evento.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                _context.Eventos.Update(evento);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> Details(int? id)
        {
            if(id == null)
                return NotFound();

            var dados =  await _context.Eventos.FindAsync(id);

            if(dados == null)
                return NotFound();

            return View(dados);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.Eventos.FindAsync(id);

            if (dados == null)
                return NotFound();

            return View(dados);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.Eventos.FindAsync(id);

            if (dados == null)
                return NotFound();

            _context.Eventos.Remove(dados);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }


    }
}
