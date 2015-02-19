using Quizisen.core.moodle_xml_elements.attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizisen.core.moodle_xml_elements
{
    [MoodleXmlElementAttribute(Name = "name")]
    class Name : MoodleXmlElement
    {
        private Text text = new Text();

        [MoodleXmlElementAttribute(Node = true)]
        public Text Text
        {
            get { return text; }
            set { text = value; }
        }

        public override void prepareData()
        {
            this.Text.HtmlNode = this.HtmlNode;
        }
    }
}
