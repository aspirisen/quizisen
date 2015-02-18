using Quizisen.core.moodle_xml_elements.attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizisen.core.moodle_xml_elements
{
    [MoodleXmlElementAttribute(Name = "text")]
    class Text : MoodleXmlElement
    {

        private String content = "";

        [MoodleXmlElementAttribute(Content = true)]
        public string Content
        {
            get { return content; }
            set { content = value; }
        }

        public override void prepareData()
        {
            if (this.HtmlNode != null)
            {
                this.Content = this.HtmlNode.InnerHtml;
            }
        }
    }
}
