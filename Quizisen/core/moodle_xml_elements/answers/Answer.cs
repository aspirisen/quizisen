using Quizisen.core.moodle_xml_elements.attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizisen.core.moodle_xml_elements
{
    [Relation(To = typeof(Question), ParentPropertyName = "answers")]
    [MoodleXmlElementAttribute(Name = "answer", HasFiles = true)]
    class Answer : MoodleXmlElement
    {
        private Text text = new Text();
        private int fraction = 0;
        private string format = "html";

        [MoodleXmlElementAttribute(Attr = true)]
        public int Fraction
        {
            get { return fraction; }
            set { fraction = value; }
        }

        [MoodleXmlElementAttribute(Attr = true)]
        public string Format
        {
            get { return format; }
            set { format = value; }
        }

        [MoodleXmlElementAttribute(Node = true)]
        public Text Text
        {
            get { return text; }
            set { text = value; }
        }

        public override void prepareData()
        {
            this.Text.HtmlNode = this.HtmlNode;
            base.prepareData();
        }
    }
}
