using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizisen.core.moodle_xml_elements
{
    class RightAnswer : Answer
    {
        public static void addStyle(Document doc)
        {
            Style style = doc.Styles.Add("RightAnswer", WdStyleType.wdStyleTypeParagraph);
            style.Font.TextColor.RGB = 0x4CAF50;
        }
    }
}
