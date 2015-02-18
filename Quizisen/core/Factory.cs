using HtmlAgilityPack;
using Quizisen.core.moodle_xml_elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizisen.core
{
    class Factory
    {
        private static string spaceName = "Quizisen.core.moodle_xml_elements.";

        public static MoodleXmlElement get(HtmlNode node)
        {
            MoodleXmlElement result = null;
            string className = node.Attributes["class"].Value;
            Type type = Type.GetType(spaceName + className);

            if (type != null)
            {
                result = (MoodleXmlElement)Activator.CreateInstance(type);
            }

            return result;
        }
    }
}
