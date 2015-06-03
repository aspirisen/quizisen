using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using Microsoft.Office.Interop.Word;
using Quizisen.core;
using System.Windows.Forms;
using System.IO;
using Quizisen.core.moodle_xml_elements;

namespace Quizisen
{
    public partial class Ribbon
    {
        private void Ribbon_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void markSelection(Style style)
        {
            Selection selection = Globals.ThisAddIn.Application.Selection;
            if (selection != null && selection.Range != null)
            {
                selection.set_Style(style);
            }
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

        private void markAsRightAnswer_Click(object sender, RibbonControlEventArgs e)
        {
            this.markSelection(RightAnswer.Style);
        }

        private void markAsWrongAnswer_Click(object sender, RibbonControlEventArgs e)
        {
            this.markSelection(WrongAnswer.Style);
        }

        private void markAsChoiceQuestion_Click(object sender, RibbonControlEventArgs e)
        {
            this.markSelection(Choice.Style);
        }

        private void truefalse_Click(object sender, RibbonControlEventArgs e)
        {
            this.markSelection(TrueFalse.Style);
        }

        private void essay_Click(object sender, RibbonControlEventArgs e)
        {
            this.markSelection(Essay.Style);
        }

        private void matchingAnswer_Click(object sender, RibbonControlEventArgs e)
        {
            this.markSelection(MatchingAnswer.Style);
        }

        private void matching_Click(object sender, RibbonControlEventArgs e)
        {
            this.markSelection(Matching.Style);
        }

        private void questionMatching_Click(object sender, RibbonControlEventArgs e)
        {
            this.markSelection(Subquestion.Style);
        }
    }
}
