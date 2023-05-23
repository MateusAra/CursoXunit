using CursoXunit.Dominio.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoXunit.Dominio.Cursos
{
    public class Curso : Entity
    {
        public Curso()
        {
        }

        public Curso(string name, double workload, int value, PublicTarget publicTarget)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Nome inválido");
            if (workload < 1)
                throw new ArgumentException("workload deve ser maior que 1");
            if (value < 0)
                throw new ArgumentException("value deve ser maior que 0");

            this.Name = name;
            this.Workload = workload;
            this.Value = value;
            this.PublicTarget = publicTarget;
        }

        public string? Name { get; set; }
        public double Workload { get; set; }
        public int Value { get; set; }
        public PublicTarget PublicTarget { get; set; }
    }
}
