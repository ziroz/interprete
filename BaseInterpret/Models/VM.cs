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
        private Stack<object> pilaDatos;
        private string cadenaResultado;
        private List<Variable> tablaDeSimbolos;

        public VM(String programa)
        {
            Parser parser = new Parser(new Lexer(programa));
            parser.declaraciones();
            cadenaResultado = "";

            listaInstrucciones = parser.obtenerInstrucciones();
            tablaDeSimbolos = parser.obtenerTablaDeSimbolos();
            pilaDatos = new Stack<object>();
        }
        public void run()
        {
            int n = listaInstrucciones.Count();
            int i = 0;

            /*
            foreach (var item in listaInstrucciones)
            {
                cadenaResultado += "\n " + item;
            }
            */
            while (i < n)
            {
                Instruccion operacion = (Instruccion)listaInstrucciones[i];

                switch (operacion)
                {
                    case Instruccion.FIN:
                        return;
                    case Instruccion.PRINT:
                        if (pilaDatos.Count() > 0)
                        {
                            object ans = pilaDatos.Pop();

                            cadenaResultado += "ans = " + ans + "\n";

                            //if (ans.intValue() == ans.doubleValue()) {
                            //    cadenaResultado += "ans = " + ans.intValue() + "\n";
                            //} else {
                            //    cadenaResultado += "ans = " + ans + "\n";
                            //}
                        }
                        break;
                    case Instruccion.POP:
                        if (pilaDatos.Count() > 0)
                        {
                            pilaDatos.Pop();
                        }
                        break;
                    case Instruccion.SUMA:
                        if (pilaDatos.Count() > 1)
                        {
                            object numero2 = getValue<object>(pilaDatos.Pop());
                            object numero1 = getValue<object>(pilaDatos.Pop());


                            if (numero1.GetType() == typeof(String) || numero2.GetType() == typeof(String))
                            {
                                pilaDatos.Push(getValue<string>(numero1) + getValue<string>(numero2));
                            }else
                            if (numero1.GetType() == typeof(Int32)
                                    && numero2.GetType() == typeof(Int32))
                            {
                                pilaDatos.Push(getValue<int>(numero1) + getValue<int>(numero2));
                            }
                            else
                            {
                                pilaDatos.Push(getValue<float>(numero1) + getValue<float>(numero2));
                            }

                        }
                        else
                        {
                            throw new ArithmeticException("Error: Falta operando.");
                        }
                        break;
                    case Instruccion.RESTA:
                        if (pilaDatos.Count() > 1)
                        {
                            object numero2 = getValue<object>(pilaDatos.Pop());
                            object numero1 = getValue<object>(pilaDatos.Pop());

                            if (numero1.GetType() == typeof(Int32)
                                && numero2.GetType() == typeof(Int32))
                            {
                                pilaDatos.Push(getValue<int>(numero1) - getValue<int>(numero2));
                            }
                            else
                            {
                                pilaDatos.Push(getValue<float>(numero1) - getValue<float>(numero2));
                            }

                        }
                        else
                        {
                            throw new ArithmeticException("Error: Falta operando.");
                        }
                        break;
                    case Instruccion.MULTIPLICACION:
                        if (pilaDatos.Count() > 1)
                        {
                            object numero2 = getValue<object>(pilaDatos.Pop());
                            object numero1 = getValue<object>(pilaDatos.Pop());

                            if (numero1.GetType() == typeof(Int32)
                                    && numero2.GetType() == typeof(Int32))
                            {
                                pilaDatos.Push(Convert.ToInt32(numero1) * Convert.ToInt32(numero2));
                            }
                            else
                            {
                                pilaDatos.Push(getValue<float>(numero1) * getValue<float>(numero2));
                            }

                        }
                        else
                        {
                            throw new ArithmeticException("Error: Falta operando.");
                        }
                        break;

                    case Instruccion.DIVISION:
                        if (pilaDatos.Count() > 1)
                        {
                            object numero2 = getValue<object>(pilaDatos.Pop());
                            object numero1 = getValue<object>(pilaDatos.Pop());

                            if (numero2.Equals(0)) throw new ArithmeticException("No se puede dividir por 0");

                            pilaDatos.Push(getValue<float>(numero1) / getValue<float>(numero2));

                        }
                        else
                        {
                            throw new ArithmeticException("Error: Falta operando.");
                        }
                        break;


                    case Instruccion.O_LOGICO:
                        if (pilaDatos.Count() > 1)
                        {
                            object numero2 = getValue<object>(pilaDatos.Pop());
                            object numero1 = getValue<object>(pilaDatos.Pop());

                            if (numero1.GetType() != typeof(bool)) throw new Exception("Se esperaba variable booleana");
                            if (numero2.GetType() != typeof(bool)) throw new Exception("Se esperaba variable booleana");

                            pilaDatos.Push((bool)numero1 || (bool)numero2);

                        }
                        else
                        {
                            throw new ArithmeticException("Error: Falta operando.");
                        }
                        break;


                    case Instruccion.Y_LOGICO:
                        if (pilaDatos.Count() > 1)
                        {
                            object elemento2 = getValue<object>(pilaDatos.Pop());
                            object elemento1 = getValue<object>(pilaDatos.Pop());

                            if (elemento1.GetType() != typeof(bool)) throw new Exception("Se esperaba variable booleana");
                            if (elemento2.GetType() != typeof(bool)) throw new Exception("Se esperaba variable booleana");

                            pilaDatos.Push((bool)elemento1 && (bool)elemento2);

                        }
                        else
                        {
                            throw new ArithmeticException("Error: Falta operando.");
                        }
                        break;

                    case Instruccion.NO_LOGICO:
                        if (pilaDatos.Count() > 0)
                        {
                            object elemento1 = getValue<object>(pilaDatos.Pop());

                            if (elemento1.GetType() != typeof(bool)) throw new Exception("Se esperaba variable booleana");

                            pilaDatos.Push(!getValue<bool>(elemento1));

                        }
                        else
                        {
                            throw new ArithmeticException("Error: Falta operando.");
                        }
                        break;

                    case Instruccion.DIFERENTE:
                    case Instruccion.IGUAL:
                    case Instruccion.MAYOR_QUE:
                    case Instruccion.MENOR_QUE:
                    case Instruccion.MAYOR_IGUAL_QUE:
                    case Instruccion.MENOR_IGUAL_QUE:
                        if (pilaDatos.Count() > 1)
                        {
                            object numero2 = getValue<object>(pilaDatos.Pop());
                            object numero1 = getValue<object>(pilaDatos.Pop());

                            if (numero1.GetType() != numero2.GetType()) throw new Exception("solo se pueden comparar variables del mismo tipo");

                            //Los manejamos como tipos de datos de dato dynamic para no tener que validar si es string, int..

                            var valor1 = getValue(numero1, numero1.GetType());
                            var valor2 = getValue(numero2, numero2.GetType());

                            if (operacion == Instruccion.IGUAL) pilaDatos.Push(valor1 == valor2);
                            else if (operacion == Instruccion.DIFERENTE) pilaDatos.Push(valor1 != valor2);
                            else if (operacion == Instruccion.MAYOR_QUE) pilaDatos.Push(valor1 > valor2);
                            else if (operacion == Instruccion.MENOR_QUE) pilaDatos.Push(valor1 < valor2);
                            else if (operacion == Instruccion.MENOR_IGUAL_QUE) pilaDatos.Push(valor1 <= valor2);
                            else if (operacion == Instruccion.MAYOR_IGUAL_QUE) pilaDatos.Push(valor1 >= valor2);
                            

                        }
                        else
                        {
                            throw new ArithmeticException("Error: Falta operando.");
                        }
                        break;

                    case Instruccion.PUSH_NUMERO_ENTERO:
                        ++i;
                        pilaDatos.Push(Convert.ToInt32(listaInstrucciones[i]));
                        break;
                    case Instruccion.PUSH_VARIABLE_CADENA:
                        ++i;
                        pilaDatos.Push(listaInstrucciones[i]);
                        break;
                    case Instruccion.PUSH_VARIABLE_FALSE:
                    case Instruccion.PUSH_VARIABLE_TRUE:
                        ++i;
                        pilaDatos.Push(listaInstrucciones[i]);
                        break;
                    case Instruccion.PUSH_IDENTIFICADOR:
                        ++i;
                        Variable variable = tablaDeSimbolos.FirstOrDefault(m => m.nombre == listaInstrucciones[i].ToString());

                        if (variable == null) throw new Exception(string.Format("Variable {0} no declarada.", listaInstrucciones[i].ToString()));

                        pilaDatos.Push(variable);
                        break;
                    case Instruccion.PUSH_NUMERO_REAL:
                        ++i;
                        pilaDatos.Push(Convert.ToSingle(listaInstrucciones[i]));
                        break;
                    case Instruccion.ASIGNACION:
                        ++i;
                        int index = Convert.ToInt32(listaInstrucciones[i]);
                        if (pilaDatos.Count() > 0)
                        {
                            object numero1 = getValue<object>(pilaDatos.Pop());

                            tablaDeSimbolos[index].valor = numero1;

                            if (listaInstrucciones.Count > i + 1 && (Instruccion)listaInstrucciones[i + 1] == Instruccion.PRINT)
                            {
                                pilaDatos.Push(numero1);
                            }

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
            }
        }

        private T getValue<T>(object element)
        {
            if (element.GetType() == typeof(Variable))
            {
                element = ((Variable)element).valor;
            }

            return (T)getValue(element, typeof(T));
        }

        private dynamic getValue(object element, Type tipo) 
        {
            return Convert.ChangeType(element, tipo);
        }

        public String getAnswer()
        {
            return cadenaResultado;
        }
    }
}
