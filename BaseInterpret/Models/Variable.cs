using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseInterprete.Models
{
    public class Variable
    {
        public Variable(string nombreVariable)
        {
            this.nombre = nombreVariable;
        }

        public string nombre { get; set; }
        public object valor { get; set; }

        public string getTipo
        {
            get
            {
                return valor.GetType().Name;
            }
        }

        public override bool Equals(object x)
        {
            if (x.GetType() != typeof(Variable)) return false;

            if (ReferenceEquals(null, x)) return false;

            if (ReferenceEquals(this, x)) return true;

            return false;
        }

        public override string ToString()
        {
            return string.Format("ID => {0},  Tipo => {1}, Valor => {2}", nombre, getTipo, valor);
        }

    }
}
