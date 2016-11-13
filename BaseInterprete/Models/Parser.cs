using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseInterprete.Models
{
    public class Parser
    {
        private Lexer lexer;
        private List<object> listaInstrucciones;
        private List<Variable> tablaDeSimbolos;


        public Parser(Lexer lexer)
        {
            this.lexer = lexer;
            listaInstrucciones = new List<object>();
            tablaDeSimbolos = new List<Variable>();
        }

        public void declaraciones()
        {
            while (!lexer.match(Token.FIN_ARCHIVO))
            {
                asignacion();
                expresiones();
            }

            listaInstrucciones.Add(Instruccion.FIN);
        }

        public void expresiones()
        {
            expresion();
            if (lexer.match(Token.COMA))
            {
                listaInstrucciones.Add(Instruccion.PRINT);
                lexer.advance();
                expresiones();
            }
            else if (lexer.match(Token.PUNTO_COMA))
            {
                listaInstrucciones.Add(Instruccion.POP);
                lexer.advance();
                expresiones();
            }
            else
            {
                listaInstrucciones.Add(Instruccion.PRINT);
            }
        }

        public void termino()
        {
            if (lexer.match(Token.VALOR_ENTERO))
            {
                int entero = lexer.obtenerEntero();

                listaInstrucciones.Add(Instruccion.PUSH_NUMERO_ENTERO);
                listaInstrucciones.Add(entero);

                lexer.advance();
            }
            else if (lexer.match(Token.VALOR_REAL))
            {
                double real = lexer.obtenerReal();
                //System.out.println("real: " + real);

                listaInstrucciones.Add(Instruccion.PUSH_NUMERO_REAL);
                listaInstrucciones.Add(real);

                lexer.advance();
            }
            else if (lexer.match(Token.ABRIR_PARENTESIS))
            {

                lexer.advance();
                expresion();
                if (!lexer.match(Token.CERRAR_PARENTESIS))
                {
                    //System.out.println("Error: Se esperaba )");
                    return;
                }
                //System.out.println(")");

                lexer.advance();
            }
        }

        public void expresion()
        {
            termino();
            expresionPrima();
        }

        public void expresionPrima()
        {
            if (lexer.match(Token.SUMA))
            {
                lexer.advance();
                termino();
                listaInstrucciones.Add(Instruccion.SUMA);
                expresionPrima();
            }

            if (lexer.match(Token.RESTA))
            {
                lexer.advance();
                termino();
                listaInstrucciones.Add(Instruccion.RESTA);
                expresionPrima();
            }
        }

        public void asignacion()
        {
            if (lexer.match(Token.IDENTIFICADOR) && lexer.nextTokenIs(Token.ASIGNACION))
            {
                String cadena = lexer.obtenerCadena();

                Variable id = new Variable(cadena);

                if (!tablaDeSimbolos.Contains(id))
                {
                    tablaDeSimbolos.Add(id);
                }

                lexer.advance();
                lexer.advance();

                expresion();
                if (!lexer.match(Token.PUNTO_COMA))
                {
                    //System.out.println("Error: Se esperaba ; en la instrucción de asignación.");
                    return;
                }
                lexer.advance();

                listaInstrucciones.Add(Instruccion.ASIGNACION);
                listaInstrucciones.Add(tablaDeSimbolos.IndexOf(id));
            }
        }

        public List<object> obtenerInstrucciones()
        {
            return listaInstrucciones;
        }

        public List<Variable> obtenerTablaDeSimbolos()
        {
            return tablaDeSimbolos;
        }
    }
}
