using Quizisen.core.moodle_xml_elements.attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizisen.core.moodle_xml_elements
{
    [Relation(To = typeof(Quiz), ParentPropertyName = "questions")]
    [MoodleXmlElementAttribute(Name = "question")]
    class Question : MoodleXmlElement
    {
        private List<MoodleXmlElement> answers = new List<MoodleXmlElement>();
        private Name name = new Name();
        private Questiontext questiontext = new Questiontext();
        private string type = "";

        [MoodleXmlElementAttribute(Attr = true)]
        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        [MoodleXmlElementAttribute(Node = true)]
        public Name Name
        {
            get { return name; }
            set { name = value; }
        }

        [MoodleXmlElementAttribute(Node = true)]
        public Questiontext Questiontext
        {
            get { return questiontext; }
            set { questiontext = value; }
        }

        [MoodleXmlElementAttribute(Children = true)]
        public List<MoodleXmlElement> Answers
        {
            get { return answers; }
            set { answers = value; }
        }

        public override void prepareData()
        {
            this.Name.HtmlNode = this.HtmlNode;
            this.Questiontext.HtmlNode = this.HtmlNode;
        }
    }
}
