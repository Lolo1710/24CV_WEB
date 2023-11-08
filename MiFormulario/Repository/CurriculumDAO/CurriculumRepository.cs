using MiFormulario.Models;

namespace MiFormulario.Repository.CurriculumDAO
{
    public class CurriculumRepository
    {
        private readonly ApplicationDbContext _context;

        public CurriculumRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Curriculum> GetAll()
        {
            return _context.Curriculums.ToList();
        }

        public int Create(Curriculum model)
        {
            _context.Curriculums.Add(model);
            return _context.SaveChanges();
        }

        public async Task<int> Update(Curriculum model)
        {
            _context.Curriculums.Update(model);
            return await _context.SaveChangesAsync();
            //var curriculumActual = GetById(model.Id);

            //if (model.Id == curriculumActual.Id &&
            //    model.Nombre != curriculumActual.Nombre ||
            //       model.ApellidoPaterno != curriculumActual.ApellidoPaterno ||
            //       model.ApellidoMaterno != curriculumActual.ApellidoMaterno ||
            //       model.CURP != curriculumActual.CURP ||
            //       model.RFC != curriculumActual.RFC ||
            //       model.FechaNacimiento != curriculumActual.FechaNacimiento ||
            //       model.Dirección != curriculumActual.Dirección ||
            //       model.Email != curriculumActual.Email ||
            //       model.PorcentajeIngles != curriculumActual.PorcentajeIngles ||
            //       model.RutaFoto != curriculumActual.RutaFoto)
            //{
            //    _context.Curriculums.Update(model);
            //    return await _context.SaveChangesAsync();
            //}
            //else
            //{
            //    return 0;
            //}
        }

        public Curriculum GetById(int id)
        {
            var curriculum = _context.Curriculums.Find(id);

            return curriculum;
            //var curriculum = _context.Curriculums.FirstOrDefault(x => x.Id == id);
            //var curriculum = _context.Curriculums.Where(x => x.Id == id).FirstOrDefault();
        }

        public int Delete(int id)
        {
            var curriculum = _context.Curriculums.Find(id);

            _context.Curriculums.Remove(curriculum);

            return _context.SaveChanges();
        }
    }
}
