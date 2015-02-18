using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizisen.core.moodle_xml_elements
{
    class WrongAnswer : Answer
    {
        public static void addStyle(Document doc)
        {
            Style style = doc.Styles.Add("WrongAnswer", WdStyleType.wdStyleTypeParagraph);
            style.Font.TextColor.RGB = 0xF44336;
        }
    }
}
