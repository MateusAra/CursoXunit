using Bogus.DataSets;
using CursoXunit.Dominio.Cursos;
using CursoXunit.DominioTest._Util;
using ExpectedObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xunit.Abstractions;

namespace CursoXunit.DominioTest.Cursos
{
    public class CursoTests
    {
        private readonly ITestOutputHelper output;

        public CursoTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void DeveCriarCurso()
        {
            output.WriteLine("Verifica se o objeto curso é criado");
            //ARRANGE
            Curso cursoDTO = new()
            {
                Name = "TDD",
                Workload = 20,
                PublicTarget = PublicTarget.Estudante,
                Value = 12
            };

            //ACTION
            Curso curso = new Curso(cursoDTO.Name, cursoDTO.Workload, cursoDTO.Value, cursoDTO.PublicTarget);

            //ASSERT
            cursoDTO.ToExpectedObject().ShouldEqual(curso);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NaoDeveTerUmNameVazio(string noName)
        {
            output.WriteLine("Verifica se aceita nome nulo");
            //ARRANGE
            Curso cursoDTO = new()
            {
                Name = noName,
                Workload = 20,
                PublicTarget = PublicTarget.Estudante,
                Value = 12
            };
            output.WriteLine($" Input: '{noName}'");
            //ACTION AND ASSERT
            Assert.Throws<ArgumentException>(() => new Curso(
                                                            cursoDTO.Name,
                                                            cursoDTO.Workload,
                                                            cursoDTO.Value,
                                                            cursoDTO.PublicTarget)
                                                            ).HaveMessage("Nome inválido");
        }
        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        public void NaoDeveCursoTerComWorLoadMenorQueUm(double workloadMin)
        {
            output.WriteLine("Valida mensagem de erro caso o Workload seja menor que um");

            Curso cursoDTO = new()
            {
                Name = "TDD",
                Workload = workloadMin,
                PublicTarget = PublicTarget.Estudante,
                Value = 12
            };

            output.WriteLine($" Input = {workloadMin}");

            Assert.Throws<ArgumentException>(() => new Curso(
                                                            cursoDTO.Name, 
                                                            cursoDTO.Workload, 
                                                            cursoDTO.Value, 
                                                            cursoDTO.PublicTarget)
                                                            ).HaveMessage("workload deve ser maior que 1");
        }
        [Theory]
        [InlineData(-1)]
        [InlineData(-2)]
        public void NaoDeveTerCursoComValueMenorQueZero(int valueMin)
        {
            //ARRANGE
            Curso cursoDTO = new()
            {
                Name = "TDD",
                Workload = 20,
                PublicTarget = PublicTarget.Estudante,
                Value = 12
            };


            //ACTION AND ASSERT
            Assert.Throws<ArgumentException>(() =>
            new Curso(cursoDTO.Name, cursoDTO.Workload, valueMin, cursoDTO.PublicTarget)).HaveMessage("value deve ser maior que 0");
        }
    }
}
