using Quizisen.core.moodle_xml_elements.attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizisen.core.moodle_xml_elements
{
    [MoodleXmlElementAttribute(Name = "questiontext", HasFiles = true)]
    class Questiontext : MoodleXmlElement
    {
        private Text text = new Text();
        private String format = "html";

        [MoodleXmlElementAttribute(Attr = true)]
        public String Format
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
