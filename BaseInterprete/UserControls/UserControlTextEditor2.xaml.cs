using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BaseInterprete
{
    /// <summary>
    /// Lógica de interacción para UserControl1.xaml
    /// </summary>
    public partial class UserControlTextEditor2 : UserControl
    {
        public UserControlTextEditor2()
        {
            InitializeComponent();

            TextEditor.Options = new ICSharpCode.AvalonEdit.TextEditorOptions()
            {
                EnableRectangularSelection = true,
                CutCopyWholeLine = true,
                HighlightCurrentLine = true,
                EnableTextDragDrop = true,
                AllowScrollBelowDocument = true
            };
        }

        public string GetText()
        {
            return TextEditor.Text;
        }
    }
}
