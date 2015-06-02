using Microsoft.Office.Interop.Word;
using Quizisen.core.moodle_xml_elements.attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizisen.core.moodle_xml_elements
{
    class Choice : Question
    {
        private static Style style;

        public static Style Style
        {
            get { return style; }
        }

        public static void addStyle(Document doc)
        {
            style = doc.Styles.Add("Choice", WdStyleType.wdStyleTypeParagraph);
            style.set_BaseStyle(WdBuiltinStyle.wdStyleHeading1);
            style.Font.TextColor.RGB = 0x03A9F4;
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
            this.Type = "multichoice";

            int rightAnswers = this.countRightAnswers();

            if (rightAnswers != 0)
            {
                double fraction = 100 / this.countRightAnswers();
                this.addFractionToAnswers(fraction);

                if (rightAnswers == 1)
                {
                    this.Single.Content = "true";
                }
                else
                {
                    this.Single.Content = "false";
                }
            }

            base.prepareData();
        }

        private void addFractionToAnswers(double fraction)
        {
            foreach (Answer answer in this.Answers)
            {
                if (answer is RightAnswer)
                {
                    answer.Fraction = (int) Math.Round(fraction);
                }
            }
        }
        private int countRightAnswers()
        {
            int rightAnswers = 0;

            foreach (Answer answer in this.Answers)
            {
                if (answer is RightAnswer)
                {
                    rightAnswers++;
                }
            }

            return rightAnswers;
        }
    }
}
