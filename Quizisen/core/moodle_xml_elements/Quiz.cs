using Quizisen.core.moodle_xml_elements.attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizisen.core.moodle_xml_elements
{
    [MoodleXmlElementAttribute(Name = "quiz")]
    class Quiz : MoodleXmlElement
    {
        private List<MoodleXmlElement> questions = new List<MoodleXmlElement>();

        [MoodleXmlElementAttribute(Children = true)]
        public List<MoodleXmlElement> Questions
        {
            get { return questions; }
            set { questions = value; }
        }

        public override void prepareData()
        {
        }
    }
}
