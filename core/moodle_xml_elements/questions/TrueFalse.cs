using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Word;

namespace Quizisen.core.moodle_xml_elements
{
    class TrueFalse : Question
    {

        private static Style style;

        public static Style Style
        {
            get { return style; }
        }

        public static void addStyle(Document doc)
        {
            style = doc.Styles.Add("TrueFalse", WdStyleType.wdStyleTypeParagraph);
            style.set_BaseStyle(WdBuiltinStyle.wdStyleHeading1);
            style.Font.TextColor.RGB = 0x3F51B5;
        }

        public override void prepareData()
        {
            this.Type = "truefalse";
            this.addFractionToAnswers();
            base.prepareData();
        }

        private void addFractionToAnswers()
        {
            foreach (Answer answer in this.Answers)
            {

                if (answer is RightAnswer)
                {
                    answer.Fraction = 100;
                }

                answer.HtmlNode.InnerHtml = answer.HtmlNode.InnerText.ToLower();
            }
        }

    }
}
