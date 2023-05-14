using CursoXunit.Dominio.Cursos;
using CursoXunit.DominioTest._Util;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoXunit.DominioTest.Cursos
{
    public class ArmazenadorCursoTest
    {
        private readonly CursoDTO _cursoDTO;
        private readonly ArmazenadorDeCurso _armazenadorDeCurso;
        [Fact]
        public void DeveAdicionarCurso()
        {

            var cursoRepositorioMock = new Mock<ICursoRepositorio>();

            var armazenadorDeCurso = new ArmazenadorDeCurso(cursoRepositorioMock.Object);

            armazenadorDeCurso.Armazenar(_cursoDTO);

            cursoRepositorioMock.Verify(r => r.Adicionar(It.IsAny<Curso>()));
        }
        [Fact]
        public void NaoDeveInformarPublicoAlvoInvalido()
        {
            var publicTarget = "Médico";
            _cursoDTO.PublicTarget = publicTarget;

            Assert.Throws<ArgumentException>(() => _armazenadorDeCurso.Armazenar(_cursoDTO)).HaveMessage("Publico Alvo inválido");

        }

    }

    public class CursoDTO
    {
        public string? Name { get; set; }
        public int Workload { get; set; }
        public string PublicTarget { get; set; }
        public int Value { get; set; }
    }

    public interface ICursoRepositorio
    {
        void Adicionar(Curso curso);
        void Atualizar(Curso curso);
    }

    public class ArmazenadorDeCurso
    {
        private ICursoRepositorio _cursoRepositorio;

        public ArmazenadorDeCurso(ICursoRepositorio cursoRepositorio)
        {
            _cursoRepositorio = cursoRepositorio;
        }
        public void Armazenar(CursoDTO cursoDTO)
        {
            Enum.TryParse(typeof(PublicTarget), cursoDTO.PublicTarget, out var publicTarget);

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
}
