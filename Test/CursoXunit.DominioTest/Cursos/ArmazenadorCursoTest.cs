using Bogus;
using CursoXunit.DominioTest._Util;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CursoXunit.Dominio.Cursos;
using Xunit.Abstractions;

namespace CursoXunit.DominioTest.Cursos
{
    public class ArmazenadorCursoTest
    {
        private readonly CursoDTO _cursoDTO;
        private readonly ArmazenadorDeCurso _armazenadorDeCurso;
        private readonly Mock<ICursoRepositorio> _cursoRepositorioMock;
        private readonly ITestOutputHelper _output;

        public ArmazenadorCursoTest(ITestOutputHelper output)
        {
            var faker = new Faker();
            _cursoDTO = new CursoDTO
            {
                Name = faker.Random.Words(),
                Workload = faker.Random.Int(50, 1000),
                PublicTarget = "Estudante",
                Value = faker.Random.Int(1000, 2000)
            };

            this._output = output;
            _cursoRepositorioMock = new Mock<ICursoRepositorio>();
            _armazenadorDeCurso = new ArmazenadorDeCurso(_cursoRepositorioMock.Object);
        }
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
            var publicTargetInvalid = "Médico";
            _cursoDTO.PublicTarget = publicTargetInvalid;

            Assert.Throws<ArgumentException>(() => _armazenadorDeCurso.Armazenar(_cursoDTO))
                .HaveMessage("Publico Alvo inválido");
        }
    }
}
