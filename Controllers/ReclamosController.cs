﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationSistemaDeReclamos.Models;
using WebApplicationSistemaDeReclamos.Models.ViewModels;
using WebApplicationSistemaDeReclamos.Services;

namespace WebApplicationSistemaDeReclamos.Controllers
{
    public class ReclamosController : Controller
    {
        // GET: ReclamosController
        public ActionResult Index()
        {
            ReclamosService reclamosService = new ReclamosService();
            //TODO tengo que recuperar el listao de reclamos....

            List<ReclamoViewModel> reclamosViewModel = new List<ReclamoViewModel>();

            ReclamoViewModel reclamoViewModel1 = new ReclamoViewModel();
            reclamoViewModel1.Id = 1;
            reclamoViewModel1.Titulo = "Ejemplo titulo";
            reclamoViewModel1.Descripcion = "Ejemplo1";
            reclamoViewModel1.Estado = "abierto";
            reclamoViewModel1.FechaAlta = DateTime.Now;
            reclamosViewModel.Add(reclamoViewModel1);

            return View(reclamosViewModel);
        }

        // GET: ReclamosController/Details/5
        public ActionResult Details(int id)
        {
            ReclamosService reclamosService = new ReclamosService();
            //TODO tengo que recuperar un reclamo....
            
            ReclamoViewModel reclamoViewModel = new ReclamoViewModel();
            reclamoViewModel.Id = id;
            reclamoViewModel.Titulo = "Ejemplo titulo";
            reclamoViewModel.Descripcion = "Ejemplo1";
            reclamoViewModel.Estado = "abierto";
            reclamoViewModel.FechaAlta = DateTime.Now;

            return View(reclamoViewModel);
        }

        // GET: ReclamosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReclamosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReclamoViewModel reclamoViewModel)
        {
            if(ModelState.IsValid)
            {
                ReclamosService reclamosService = new ReclamosService();
                Reclamo reclamo = new Reclamo();
                reclamo.Titulo = reclamoViewModel.Titulo;
                reclamo.Descripcion = reclamoViewModel.Descripcion;
                reclamo.Estado = reclamoViewModel.Estado;
                reclamo.FechaAlta = DateTime.Now;

                reclamosService.AltaDeReclamo(reclamo);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                //HAY ALGUN ERROR DE VALIDACION... VUELVO A MOSTRAR EL FORMULARIO
                return View();
            }
 
        }

        // GET: ReclamosController/Edit/5
        public ActionResult Edit(int id)
        {
            ReclamoViewModel reclamoViewModel = new ReclamoViewModel();
            reclamoViewModel.Id = id;
            reclamoViewModel.Titulo = "Ejemplo editar";
            reclamoViewModel.Descripcion = "Ejemplo de editar 123456";
            reclamoViewModel.Estado = "inicial";
            reclamoViewModel.FechaAlta = DateTime.Now;
            return View(reclamoViewModel);
        }

        // POST: ReclamosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ReclamoViewModel reclamoViewModel)
        {
            if (ModelState.IsValid)
            {
                //TODO HACER EL ALTA EN LA BASE DATOS....
                //VUELVO AL LISTADO DE RECLAMOS
                return RedirectToAction(nameof(Index));
            }
            else
            {
                //HAY ALGUN ERROR DE VALIDACION... VUELVO A MOSTRAR EL FORMULARIO
                return View();
            }
        }

        // GET: ReclamosController/Delete/5
        public ActionResult Delete(int id)
        {
            //TODO borrar de la base de datos el reclamo
            return RedirectToAction(nameof(Index));
        }
        
    }
}
