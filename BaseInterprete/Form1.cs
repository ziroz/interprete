using BaseInterprete.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ICSharpCode;
using System.Windows.Forms.Integration;

namespace BaseInterprete
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string code = userControlTextEditor1.GetText();
            Lexer lexer = new Lexer(code);

            StringBuilder builder = new StringBuilder();

            while (!lexer.match(Token.FIN_ARCHIVO))
            {
                if (lexer.match(Token.VALOR_ENTERO))
                {
                    builder.Append("Entero " + lexer.obtenerEntero());
                }

                if (lexer.match(Token.SUMA))
                {
                    builder.Append("Suma: " + lexer.obtenerSimbolo());
                }

                if (lexer.match(Token.RESTA))
                {
                    builder.Append("Resta: " + lexer.obtenerSimbolo());
                }

                if (lexer.match(Token.REAL))
                {
                    builder.Append("Real " + lexer.obtenerReal());
                }

                if (lexer.match(Token.ABRIR_PARENTESIS))
                {
                    builder.Append("Abre Parentesis: " + lexer.obtenerSimbolo());
                }

                if (lexer.match(Token.CERRAR_PARENTESIS))
                {
                    builder.Append("Cerrar Parentesis: " + lexer.obtenerSimbolo());
                }

                
                if (lexer.match(Token.MAYOR_QUE))
                {
                    builder.Append("Mayor Que: " + lexer.obtenerSimbolo());
                }
                
                if (lexer.match(Token.MAYOR_QUE))
                {
                    builder.Append("Mayor Que: " + lexer.obtenerSimbolo());
                }
                
                if (lexer.match(Token.MAYOR_IGUAL_QUE))
                {
                    builder.Append("Mayor Igual Que: " + lexer.obtenerSimbolo());
                }
                
                if (lexer.match(Token.MENOR_IGUAL_QUE))
                {
                    builder.Append("Menor Igual Que: " + lexer.obtenerSimbolo());
                }
                
                if (lexer.match(Token.MENOR_QUE))
                {
                    builder.Append("Menor Que: " + lexer.obtenerSimbolo());
                }
                
                if (lexer.match(Token.DIFERENTE))
                {
                    builder.Append("Diferente: " + lexer.obtenerSimbolo());
                }

                if (lexer.match(Token.MULTIPLICACION))
                {
                    builder.Append("Multiplicación: " + lexer.obtenerSimbolo());
                }

                if (lexer.match(Token.DIVISION))
                {
                    builder.Append("División: " + lexer.obtenerSimbolo());
                }

                if (lexer.match(Token.MODULO))
                {
                    builder.Append("Módulo: " + lexer.obtenerSimbolo());
                }

                if (lexer.match(Token.POTENCIA))
                {
                    builder.Append("Potenciacion: " + lexer.obtenerSimbolo());
                }

                if (lexer.match(Token.ABRIR_CORCHETE))
                {
                    builder.Append("Abrir Corchete: " + lexer.obtenerSimbolo());
                }

                if (lexer.match(Token.CERRAR_CORCHETE))
                {
                    builder.Append("Cerrar Corchete: " + lexer.obtenerSimbolo());
                }

                if (lexer.match(Token.COMA))
                {
                    builder.Append("Coma: " + lexer.obtenerSimbolo());
                }

                if (lexer.match(Token.PUNTO_COMA))
                {
                    builder.Append("Punto y Coma: " + lexer.obtenerSimbolo());
                }

                if (lexer.match(Token.ASIGNACION))
                {
                    builder.Append("Asignación: " + lexer.obtenerSimbolo());
                }


                if (lexer.match(Token.IDENTIFICADOR))
                {
                    builder.Append("Variable: " + lexer.obtenerSimbolo());
                }

                builder.Append(Environment.NewLine);

                lexer.advance();

            }

            txtResult.Text = builder.ToString();
        }


    }
}
