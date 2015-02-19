using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using Microsoft.Office.Interop.Word;
using Quizisen.core;
using System.Windows.Forms;
using System.IO;

namespace Quizisen
{
    public partial class Ribbon
    {
        private void Ribbon_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void parse_Click(object sender, RibbonControlEventArgs e)
        {
            DialogResult result = saveFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                Document doc = Globals.ThisAddIn.Application.ActiveDocument;
                Parser parser = new Parser(doc);
                parser.parse(saveFileDialog.FileName);
            }
        }
    }
}
