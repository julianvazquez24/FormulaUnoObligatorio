﻿using FormulaUnoObligatorio.Data;
using FormulaUnoObligatorio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;

namespace FormulaUnoObligatorio.Controllers
{
    public class PilotoController : Controller
    {
        private readonly AppDbContext _context;

        public PilotoController(AppDbContext context)
        {
            _context = context; 
        }

        public IActionResult Index()
        {
            ViewBag.HabilitarNuevoPiloto = ContarPilotos();
            ViewBag.Pilotos = _context.Pilotos;
            var appDbContext = _context.Pilotos.Include(p => p.EscuderiaPiloto);
             return View("Index", appDbContext.ToList());
        }


    
        public IActionResult Detalles(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var piloto = _context.Pilotos
                .Include(p => p.EscuderiaPiloto)
                .FirstOrDefault(m => m.IdPiloto == id);


            if (piloto == null)
            {
                return NotFound();
            }

            return View(piloto);
        }


     
        public IActionResult Crear()
        {
           ViewBag.IdEscuderia= new SelectList(_context.Escuderias, "IdEscuderia", "NombreEscuderia");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear([Bind("NombrePiloto, ApellidoPiloto, PaisPiloto, FechaNacimiento, IdEscuderia")] Piloto piloto)
        {
            if (ModelState.IsValid)
            {
                var maximoPilotos = _context.Pilotos.Count(p => p.IdEscuderia == piloto.IdEscuderia);
                if (maximoPilotos >= 2)
                {
                    ModelState.AddModelError(string.Empty, "No puede existir mas de 2 pilotos por escuderia.");


                    return View(piloto);
                }

                int totalPilotos = _context.Pilotos.Count();
                if (totalPilotos >= 20)
                {
                    ModelState.AddModelError(string.Empty, "No se puede agregar más de 20 pilotos.");
                    return View(piloto);
                }

                _context.Add(piloto);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEscuderia"] = new SelectList(_context.Escuderias, "IdEscuderia", "NombreEscuderia", piloto.IdEscuderia);

            return View(piloto);
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var piloto = _context.Pilotos.Find(id);
            if (piloto == null)
            {
                return NotFound();
            }

            var maximoPilotos = _context.Pilotos.Count(p => p.IdEscuderia == piloto.IdEscuderia && p.IdPiloto != piloto.IdPiloto);

            if (maximoPilotos >= 2)
            {
                ModelState.AddModelError(string.Empty, "No puede existir más de 2 pilotos por escudería.");
                return View(piloto);
            }

            ViewBag.Escuderia = new SelectList(_context.Escuderias, "IdEscuderia", "NombreEscuderia", piloto.IdEscuderia);
            
            return View(piloto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(int id, [Bind("IdPiloto,NombrePiloto,ApellidoPiloto,PaisPiloto,FechaNacimiento,IdEscuderia")] Piloto piloto)
        {
            if (id != piloto.IdPiloto)
            {
                return NotFound();
            }

            var maximoPilotos = _context.Pilotos.Count(p => p.IdEscuderia == piloto.IdEscuderia && p.IdPiloto != piloto.IdPiloto);

            if (maximoPilotos >= 2)
            {
                ModelState.AddModelError(string.Empty, "No puede existir más de 2 pilotos por escudería.");
               
                ViewBag.Escuderia = new SelectList(_context.Escuderias, "IdEscuderia", "NombreEscuderia", piloto.IdEscuderia);
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(piloto);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Pilotos.Any(p => p.IdPiloto == id))
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

           
            ViewBag.Escuderia = new SelectList(_context.Escuderias, "IdEscuderia", "NombreEscuderia", piloto.IdEscuderia);
            return View(piloto);
        }



        // Get Delete
        public IActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var piloto = _context.Pilotos
                .Include(p => p.EscuderiaPiloto)
                .FirstOrDefault(m => m.IdPiloto == id);


            if (piloto == null)
            {
                return NotFound();
            }

            return View(piloto);
        }

        // Post Delete
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public IActionResult EliminarConfirmada(int id)
        {
            var piloto = _context.Pilotos.Find(id);
            if (piloto != null)
            {
                _context.Pilotos.Remove(piloto);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }


        public bool PilotoExiste(int idPiloto)
        {
            return _context.Pilotos.Any(e => e.IdPiloto == idPiloto);
        }

        private bool ContarPilotos()
        {
            if (_context.Pilotos.Count() == 20)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}

