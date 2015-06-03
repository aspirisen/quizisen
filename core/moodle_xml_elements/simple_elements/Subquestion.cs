using Microsoft.Office.Interop.Word;
using Quizisen.core.moodle_xml_elements.attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizisen.core.moodle_xml_elements
{
    [Relation(To = typeof(Matching), ParentPropertyName = "answers")]
    [MoodleXmlElementAttribute(Name = "subquestion")]
    class Subquestion : Question
    {
        private static Style style;

        public static Style Style
        {
            get { return style; }
        }

        public static void addStyle(Document doc)
        {
            style = doc.Styles.Add("Subquestion", WdStyleType.wdStyleTypeParagraph);
            style.set_BaseStyle(WdBuiltinStyle.wdStyleHeading1);
            style.Font.TextColor.RGB = 0x03A9F4;
        }

        private Text text = new Text();

        [MoodleXmlElementAttribute(Node = true)]
        public Text Text
        {
            get { return text; }
            set { text = value; }
        }

        public override void prepareData()
        {
            this.Text.HtmlNode = this.HtmlNode.CloneNode(true);
            base.prepareData();
        }


    }
}
