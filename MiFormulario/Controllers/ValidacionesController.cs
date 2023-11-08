﻿using Microsoft.AspNetCore.Mvc;
using MiFormulario.Services.Contracts;
using MiFormulario.Models;

namespace MiFormulario.Controllers
{
    public class ValidacionesController : Controller
    {
        private readonly ICurriculumService _curriculumService;

        public ValidacionesController(ICurriculumService curriculumService)
        {
            _curriculumService = curriculumService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EnviarInformacion(Curriculum model)
        {

            string mensaje = "";
            //model.RutaFoto = "FakePath";

            if (ModelState.IsValid)
            {
                var response = _curriculumService.Create(model).Result;

                mensaje = response.Message;
                TempData["msj"] = mensaje;
                return RedirectToAction("Index");
            }
            else
            {
                mensaje = "Datos incorrectos";
                TempData["msj"] = mensaje;

                return View("Index", model);
            }

        }

        public IActionResult Lista()
        {
            return View(_curriculumService.GetAll());
        }
    }
}
