using Azure;
using Microsoft.EntityFrameworkCore;
using MiFormulario.Models;
using MiFormulario.Repository;
using MiFormulario.Repository.CurriculumDAO;
using MiFormulario.Services.Contracts;
using System.Reflection.Metadata;

namespace MiFormulario.Services.ContractServices
{
    public class CurriculumService : ICurriculumService
    {
        private CurriculumRepository _repository;

        public CurriculumService(MiFormulario.Repository.ApplicationDbContext context)
        {
            _repository = new CurriculumRepository(context);
        }

        public async Task<ResponseHelper> Create(Curriculum model)
        {
            ResponseHelper responseHelper = new ResponseHelper();

            try
            {
                string filePath = "";
                string fileName = "";

                if (model.Foto != null && model.Foto.Length > 0)
                {
                    fileName = Path.GetFileName(model.Foto.FileName);
                    filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Fotos", fileName);
                }

                model.RutaFoto = fileName;

                //Copia el archivo en un directorio
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await model.Foto.CopyToAsync(fileStream);
                }

                if (_repository.Create(model) > 0)
                {
                    responseHelper.Success = true;
                    responseHelper.Message = $"Se agregó el curriculum de {model.Nombre} con éxito.";
                }
                else
                {
                    responseHelper.Message = "Ocurrió un error al agregar el dato.";
                }
            }
            catch (Exception e)
            {
                responseHelper.Message = $"Ocurrió un error al agregar el dato. Error: {e.Message}";
            }


            return responseHelper;
        }

        public ResponseHelper Delete(int id)
        {
            ResponseHelper responseHelper = new ResponseHelper();

            try
            {
                var response = _repository.Delete(id);

                if (response > 0)
                {
                    responseHelper.Success = true;
                    responseHelper.Message = $"Se elimino el curriculum con éxito.";
                }
                else
                {
                    responseHelper.Message = "Ocurrió un error al eliminar el curriculum.";
                }
            }
            catch (Exception e)
            {
                responseHelper.Message = $"Ocurrió un error al eliminar el curriculum. Error: {e.Message}";
            }


            return responseHelper;

        }

        public List<Curriculum> GetAll()
        {
            List<Curriculum> list = new List<Curriculum>();

            try
            {
                list = _repository.GetAll();
            }
            catch (Exception e)
            {

                throw;
            }

            return list;
        }

        public Curriculum GetById(int id)
        {
            Curriculum curriculum;
            try
            {
                curriculum = _repository.GetById(id);
            }
            catch
            {
                throw;
            }

            return curriculum;
        }

        public async Task<ResponseHelper> Update(Curriculum model)
        {
            ResponseHelper responseHelper = new ResponseHelper();

            try
            {
                string filePath = "";
                string fileName = "";

                if (model.Foto != null && model.Foto.Length > 0)
                {
                    fileName = Path.GetFileName(model.Foto.FileName);
                    filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Fotos", fileName);
                    model.RutaFoto = fileName;

                    //Copia el archivo en un directorio
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.Foto.CopyToAsync(fileStream);
                    }

                }

                var responseDB = 0;

                if (model != null)
                {
                    responseDB = await _repository.Update(model);

                    if (responseDB > 0)
                    {
                        responseHelper.Success = true;
                        responseHelper.Message = $"Se guardaron los cambios del currículum con éxito.";
                    }
                    else
                    {
                        responseHelper.Message = $"No hubo cambios en el curriculum de {model.Nombre}";
                    }
                }
                else
                {
                    responseHelper.Message ="El formulario no puede quedar vacio";
                }
            }
            catch (Exception e)
            {
                responseHelper.Message = $"Ocurrió un error al editar el currículum. Error: {e.Message}";
            }

            return responseHelper;
        }

    }
}
