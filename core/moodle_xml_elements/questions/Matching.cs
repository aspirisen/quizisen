using Microsoft.Office.Interop.Word;
using Quizisen.core.moodle_xml_elements.attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizisen.core.moodle_xml_elements
{
    class Matching : Question
    {
        private static Style style;

        public static Style Style
        {
            get { return style; }
        }

        public static void addStyle(Document doc)
        {
            style = doc.Styles.Add("Matching", WdStyleType.wdStyleTypeParagraph);
            style.set_BaseStyle(WdBuiltinStyle.wdStyleHeading1);
            style.Font.TextColor.RGB = 0xF32914;
        }

        private Single single = new Single();

        [MoodleXmlElementAttribute(Node = true)]
        public Single Single
        {
            get { return single; }
            set { single = value; }
        }

        public override void prepareData()
        {
            this.Type = "matching";
            base.prepareData();
        }

    }
}
