using Azure;
using Microsoft.AspNetCore.Mvc;
using MiFormulario.Models;
using MiFormulario.Services.Contracts;

namespace MiFormulario.Controllers
{
	public class CurriculumController : Controller
	{
        private readonly ICurriculumService _curriculumService;

        public CurriculumController(ICurriculumService curriculumService)
        {
            _curriculumService = curriculumService;
        }

        public IActionResult Index()
		{
			return View();
		}

        public IActionResult Lista()
        {
            return View(_curriculumService.GetAll());
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
                TempData["msj-true"] = mensaje;
                return RedirectToAction("Lista");
            }
            else
            {
                mensaje = "Datos incorrectos o incompletos";
                TempData["msj-false"] = mensaje;

                return RedirectToAction("Lista");
            }

        }

        public IActionResult View(int id)
        {
            var curriculum = _curriculumService.GetById(id);

            if (curriculum != null)
            {
                return View("View", curriculum);
            }
            else
            {
                return NotFound();
            }
        }

        public IActionResult ViewEdit(int id)
        {
            var curriculum = _curriculumService.GetById(id);

            if (curriculum != null)
            {
                return View("ViewEdit", curriculum);
            }
            else
            {
                return NotFound();
            }
        }

        public IActionResult Delete(int id)
        {
            string mensaje = "";
            var response = _curriculumService.Delete(id);

            if (response.Success == true)
            {
                mensaje = response.Message;
                TempData["msj-true"] = mensaje;
                return RedirectToAction("Lista");
            }
            else
            {
                mensaje = "No se pudo eliminar";
                TempData["msj-false"] = mensaje;

                return RedirectToAction("Lista");
            }
        }

        public async Task<IActionResult> ViewUpdate(Curriculum model)
        {
            string mensaje = "";
            var responseHelper = await _curriculumService.Update(model);

            if (model != null)
            {
                if(responseHelper.Success == true)
                {
                    mensaje = responseHelper.Message;
                    TempData["msj-true"] = mensaje;
                    return RedirectToAction("Lista","Curriculum");
                }
                else
                {
                    mensaje = responseHelper.Message;
                    TempData["msj-false"] = mensaje;

                    return RedirectToAction("Lista");
                }
            }
            else
            {
                return NotFound();
            }
        }

    }
}
