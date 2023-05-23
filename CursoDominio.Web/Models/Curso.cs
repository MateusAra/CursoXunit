

namespace CursoDominio.Web.Models
{
    public class Curso : CursoXunit.Dominio.Cursos.Curso
    {
        public string? Name { get; set; }
        public int Workload { get; set; }
        public string? PublicTarget { get; set; }
        public int Value { get; set; }
    }
}
