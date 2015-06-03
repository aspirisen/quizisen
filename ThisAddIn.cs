using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Word = Microsoft.Office.Interop.Word;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Word;
using Quizisen.core.moodle_xml_elements;

namespace Quizisen
{
    public partial class ThisAddIn
    {

        private void addQuestionStyles(Word.Document doc)
        {
            Choice.addStyle(doc);
            RightAnswer.addStyle(doc);
            WrongAnswer.addStyle(doc);
            TrueFalse.addStyle(doc);
            Essay.addStyle(doc);

            Matching.addStyle(doc);
            Subquestion.addStyle(doc);
            MatchingAnswer.addStyle(doc);
        }

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            this.Application.DocumentOpen += new Word.ApplicationEvents4_DocumentOpenEventHandler(this.addQuestionStyles);
            ((Word.ApplicationEvents4_Event)this.Application).NewDocument += new Word.ApplicationEvents4_NewDocumentEventHandler(this.addQuestionStyles);
            this.Application.Startup += new Word.ApplicationEvents4_StartupEventHandler(this.application_startup);
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }

        private void application_startup()
        {
            this.addQuestionStyles(Globals.ThisAddIn.Application.ActiveDocument);
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }

        #endregion
    }
}
