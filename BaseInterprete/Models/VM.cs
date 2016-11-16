using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseInterprete.Models
{
    public class VM
    {
        private List<object> listaInstrucciones;
        private Stack<object> pilaNumeros;
        private string cadenaResultado;
        private List<Variable> tablaDeSimbolos;

        public VM(String programa)
        {
            Parser parser = new Parser(new Lexer(programa));
            parser.declaraciones();
            cadenaResultado = "";

            listaInstrucciones = parser.obtenerInstrucciones();
            tablaDeSimbolos = parser.obtenerTablaDeSimbolos();
            pilaNumeros = new Stack<object>();
        }
        public void run()
        {
            int n = listaInstrucciones.Count();
            int i = 0;

            foreach (var item in listaInstrucciones)
            {
                cadenaResultado += "\n " + item;
            }
            /*
            while (i < n)
            {
                Instruccion operacion = (Instruccion)listaInstrucciones[i];

                switch (operacion)
                {
                    case Instruccion.FIN:
                        return;
                    case Instruccion.PRINT:
                        if (pilaNumeros.Count() > 0)
                        {
                            object ans = pilaNumeros.Pop();

                            cadenaResultado += "ans = " + ans + "\n";

                            //if (ans.intValue() == ans.doubleValue()) {
                            //    cadenaResultado += "ans = " + ans.intValue() + "\n";
                            //} else {
                            //    cadenaResultado += "ans = " + ans + "\n";
                            //}
                        }
                        break;
                    case Instruccion.POP:
                        if (pilaNumeros.Count() > 0)
                        {
                            pilaNumeros.Pop();
                        }
                        break;
                    case Instruccion.SUMA:
                        if (pilaNumeros.Count() > 1)
                        {
                            object numero2 = pilaNumeros.Pop();
                            object numero1 = pilaNumeros.Pop();

                            if (numero1.GetType() == typeof(Variable)) numero1 = ((Variable)numero1).valor;
                            if (numero2.GetType() == typeof(Variable)) numero2 = ((Variable)numero2).valor;

                            if (numero1.GetType() == typeof(Int32)
                                    && numero2.GetType() == typeof(Int32))
                            {
                                pilaNumeros.Push(Convert.ToInt32(numero1) + Convert.ToInt32(numero2));
                            }
                            else
                            {
                                pilaNumeros.Push(Convert.ToSingle(numero1) + Convert.ToSingle(numero2));
                            }

                        }
                        else
                        {
                            throw new ArithmeticException("Error: Falta operando.");
                        }
                        break;
                    case Instruccion.RESTA:
                        if (pilaNumeros.Count() > 1)
                        {
                            object numero2 = pilaNumeros.Pop();
                            object numero1 = pilaNumeros.Pop();

                            if (numero1.GetType() == typeof(Variable)) numero1 = ((Variable)numero1).valor;
                            if (numero2.GetType() == typeof(Variable)) numero2 = ((Variable)numero2).valor;

                            if (numero1.GetType() == typeof(Int32)
                                && numero2.GetType() == typeof(Int32))
                            {
                                pilaNumeros.Push(Convert.ToInt32(numero1) - Convert.ToInt32(numero2));
                            }
                            else
                            {
                                pilaNumeros.Push(Convert.ToSingle(numero1) - Convert.ToSingle(numero2));
                            }

                        }
                        else
                        {
                            throw new ArithmeticException("Error: Falta operando.");
                        }
                        break;
                    case Instruccion.MULTIPLICACION:
                        if (pilaNumeros.Count() > 1)
                        {
                            object numero2 = pilaNumeros.Pop();
                            object numero1 = pilaNumeros.Pop();

                            if (numero1.GetType() == typeof(Variable)) numero1 = ((Variable)numero1).valor;
                            if (numero2.GetType() == typeof(Variable)) numero2 = ((Variable)numero2).valor;

                            if (numero1.GetType() == typeof(Int32)
                                    && numero2.GetType() == typeof(Int32))
                            {
                                pilaNumeros.Push(Convert.ToInt32(numero1) * Convert.ToInt32(numero2));
                            }
                            else
                            {
                                pilaNumeros.Push(Convert.ToSingle(numero1) * Convert.ToSingle(numero2));
                            }

                        }
                        else
                        {
                            throw new ArithmeticException("Error: Falta operando.");
                        }
                        break;

                    case Instruccion.DIVISION:
                        if (pilaNumeros.Count() > 1)
                        {
                            object numero2 = pilaNumeros.Pop();
                            object numero1 = pilaNumeros.Pop();

                            if (numero1.GetType() == typeof(Variable)) numero1 = ((Variable)numero1).valor;
                            if (numero2.GetType() == typeof(Variable)) numero2 = ((Variable)numero2).valor;

                            if (numero2.Equals(0)) throw new ArithmeticException("No se puede dividir por 0");
                            if (numero1.GetType() == typeof(Int32)
                                    && numero2.GetType() == typeof(Int32))
                            {
                                pilaNumeros.Push(Convert.ToInt32(numero1) / Convert.ToInt32(numero2));
                            }
                            else
                            {
                                pilaNumeros.Push(Convert.ToSingle(numero1) / Convert.ToSingle(numero2));
                            }

                        }
                        else
                        {
                            throw new ArithmeticException("Error: Falta operando.");
                        }
                        break;
                    case Instruccion.PUSH_NUMERO_ENTERO:
                        ++i;
                        pilaNumeros.Push(Convert.ToInt32(listaInstrucciones[i]));
                        break;
                    case Instruccion.PUSH_IDENTIFICADOR:
                        ++i;
                        Variable variable = tablaDeSimbolos.First(m => m.nombre == listaInstrucciones[i].ToString());
                        pilaNumeros.Push(variable);
                        break;
                    case Instruccion.PUSH_NUMERO_REAL:
                        ++i;
                        pilaNumeros.Push(Convert.ToSingle(listaInstrucciones[i]));
                        break;
                    case Instruccion.ASIGNACION:
                        ++i;
                        int index = Convert.ToInt32(listaInstrucciones[i]);
                        if (pilaNumeros.Count() > 0)
                        {
                            object numero1 = pilaNumeros.Pop();

                            pilaNumeros.Push(numero1);

                            tablaDeSimbolos[index].valor = numero1;

                            cadenaResultado += "\n" + tablaDeSimbolos[index];

                        }
                        else
                        {
                            throw new ArithmeticException("Error: Falta valor.");
                        }

                        break;
                    default:
                        return;
                }

                ++i;
            }*/
        }

        public String getAnswer()
        {
            return cadenaResultado;
        }
    }
}
