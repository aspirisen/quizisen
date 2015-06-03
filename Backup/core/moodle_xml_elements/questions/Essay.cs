using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Word;

namespace Quizisen.core.moodle_xml_elements
{
    class Essay : Question
    {

        private static Style style;

        public static Style Style
        {
            get { return style; }
        }

        public static void addStyle(Document doc)
        {
            style = doc.Styles.Add("Essay", WdStyleType.wdStyleTypeParagraph);
            style.set_BaseStyle(WdBuiltinStyle.wdStyleHeading1);
            style.Font.TextColor.RGB = 0x00A224;
        }

        public override void prepareData()
        {
            this.Type = "essay";
            base.prepareData();
        }

    }
}
