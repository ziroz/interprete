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

            VM calculadora = new VM(code);

            calculadora.run();

            txtResult.Text = calculadora.getAnswer();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F5)
            {
                button1_Click(null, null);
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }      
    }
}
