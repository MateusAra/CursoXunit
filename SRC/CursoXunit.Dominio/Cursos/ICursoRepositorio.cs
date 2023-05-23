using CursoXunit.Dominio.Cursos;

namespace CursoXunit.Dominio.Cursos;

public interface ICursoRepositorio
{
    void Adicionar(Curso curso);
    void Atualizar(Curso curso);
    Curso ObterPeloNome(string Name);
}