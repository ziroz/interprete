﻿using System;
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
                asignaciones();
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

        public void factor()
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
            }else if (lexer.match(Token.IDENTIFICADOR))
            {
                string cadena = lexer.obtenerVariable();

                /*   Acá posiblemente se validan las palabras reservadas    */

                listaInstrucciones.Add(Instruccion.PUSH_IDENTIFICADOR);
                listaInstrucciones.Add(cadena);

                lexer.advance();
            }
            else if (lexer.match(Token.CADENA_STRING))
            {
                string cadena = lexer.obtenerCadena();

                /*   Acá posiblemente se validan las palabras reservadas    */

                listaInstrucciones.Add(Instruccion.PUSH_VARIABLE_CADENA);
                listaInstrucciones.Add(cadena);

                lexer.advance();
            }
            else if (lexer.match(Token.RESERVADA_TRUE))
            {
                listaInstrucciones.Add(Instruccion.PUSH_VARIABLE_TRUE);
                listaInstrucciones.Add(true);

                lexer.advance();
            }
            else if (lexer.match(Token.RESERVADA_FALSE))
            {
                listaInstrucciones.Add(Instruccion.PUSH_VARIABLE_FALSE);
                listaInstrucciones.Add(false);

                lexer.advance();
            }
        }
       
        public void terminoPrimo()
        {
            if (lexer.match(Token.SUMA))
            {
                lexer.advance();
                termino();
                listaInstrucciones.Add(Instruccion.SUMA);
                terminoPrimo();
            }

            if (lexer.match(Token.RESTA))
            {
                lexer.advance();
                termino();
                listaInstrucciones.Add(Instruccion.RESTA);
                terminoPrimo();
            }
        }
        
        public void factorPrimo()
        {
            if (lexer.match(Token.MULTIPLICACION))
            {
                lexer.advance();
                factor();
                listaInstrucciones.Add(Instruccion.MULTIPLICACION);
                factorPrimo();
            }

            if (lexer.match(Token.DIVISION))
            {
                lexer.advance();
                factor();
                listaInstrucciones.Add(Instruccion.DIVISION);
                factorPrimo();
            }
        }


        public void expresion()
        {
            termino();
            terminoPrimo();
        }

        public void termino()
        {
            factor();
            factorPrimo();
        }


        public void asignaciones()
        {
            if (lexer.match(Token.IDENTIFICADOR) && lexer.nextTokenIs(Token.ASIGNACION))
            {
                asignacion();
                if (!lexer.match(Token.PUNTO_COMA))
                {
                    //System.out.println("Error: Se esperaba ; en la instrucción de asignación.");
                    return;
                }
                lexer.advance();
                asignaciones();
            }
        }

        public void asignacion()
        {
            String cadena = lexer.obtenerVariable();

            Variable id = new Variable(cadena);

            if (!tablaDeSimbolos.Contains(id))
            {
                tablaDeSimbolos.Add(id);
            }

            lexer.advance();
            lexer.advance();

            asignaciones();

            expresion();

            listaInstrucciones.Add(Instruccion.ASIGNACION);
            listaInstrucciones.Add(tablaDeSimbolos.IndexOf(id));
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
