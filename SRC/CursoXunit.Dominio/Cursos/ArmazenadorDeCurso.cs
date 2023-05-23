using CursoXunit.Dominio.Cursos;

namespace CursoXunit.Dominio.Cursos;

public class ArmazenadorDeCurso
{
    private ICursoRepositorio _cursoRepositorio;

    public ArmazenadorDeCurso(ICursoRepositorio cursoRepositorio)
    {
        _cursoRepositorio = cursoRepositorio;
    }
    public void Armazenar(CursoDTO cursoDTO)
    {
        Enum.TryParse(typeof(PublicTarget), (string?)cursoDTO.PublicTarget, out var publicTarget);

        if (publicTarget == null)
            throw new ArgumentException("Publico Alvo inválido");

        var curso = new Curso
        (
            cursoDTO.Name,
            cursoDTO.Workload,
            cursoDTO.Value,
            (PublicTarget)publicTarget
        );
        _cursoRepositorio.Adicionar(curso);
    }
}