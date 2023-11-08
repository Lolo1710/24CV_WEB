using MiFormulario.Models;

namespace MiFormulario.Services.Contracts
{
    public interface ICurriculumService
    {
        List<Curriculum> GetAll();
        Curriculum GetById(int id);
        Task<ResponseHelper> Create(Curriculum model);
        Task<ResponseHelper> Update(Curriculum model);
        ResponseHelper Delete(int id);
    }
}
