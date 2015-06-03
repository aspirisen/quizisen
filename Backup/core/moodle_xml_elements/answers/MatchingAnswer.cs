using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizisen.core.moodle_xml_elements
{
    class MatchingAnswer : Answer
    {
        private static Style style;

        public static Style Style
        {
            get { return style; }
        }

        public static void addStyle(Document doc)
        {
            style = doc.Styles.Add("MatchingAnswer", WdStyleType.wdStyleTypeParagraph);
            style.Font.TextColor.RGB = 0x2443FF;
        }

        public override void prepareData()
        {
            base.prepareData();
        }
    }
}
