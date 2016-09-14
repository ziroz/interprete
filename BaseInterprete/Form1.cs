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
                    builder.Append(Environment.NewLine);
                }

                if (lexer.match(Token.SUMA))
                {
                    builder.Append("Suma");
                    builder.Append(Environment.NewLine);
                }

                if (lexer.match(Token.RESTA))
                {
                    builder.Append("Resta");
                    builder.Append(Environment.NewLine);
                }

                if (lexer.match(Token.REAL))
                {
                    builder.Append("Real " + lexer.obtenerReal());
                    builder.Append(Environment.NewLine);
                }

                if (lexer.match(Token.ABRIR_PARENTESIS))
                {
                    builder.Append("Abre Parentesis");
                    builder.Append(Environment.NewLine);
                }

                if (lexer.match(Token.CERRAR_PARENTESIS))
                {
                    builder.Append("Cerrar Parentesis");
                    builder.Append(Environment.NewLine);
                }

                lexer.advance();

            }

            txtResult.Text = builder.ToString();
        }


    }
}
