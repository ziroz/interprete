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

            String programa = "2. + 418 - 47";
            Lexer lexer = new Lexer(programa);

            while (!lexer.match(Token.FIN_ARCHIVO))
            {
                if (lexer.match(Token.VALOR_ENTERO))
                {
                    System.Diagnostics.Debug.WriteLine("Entero " + lexer.obtenerEntero());
                }

                if (lexer.match(Token.SUMA))
                {
                    System.Diagnostics.Debug.WriteLine("Suma");
                }

                if (lexer.match(Token.RESTA))
                {
                    System.Diagnostics.Debug.WriteLine("Resta");
                }

                if (lexer.match(Token.REAL))
                {
                    System.Diagnostics.Debug.WriteLine("Real " + lexer.obtenerReal());
                }

                if (lexer.match(Token.ABRIR_PARENTESIS))
                {
                    System.Diagnostics.Debug.WriteLine("Abre Parentesis");
                }

                if (lexer.match(Token.CERRAR_PARENTESIS))
                {
                    System.Diagnostics.Debug.WriteLine("Cerrar Parentesis");
                }

                lexer.advance();

            }
        }
    }
}
