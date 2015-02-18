using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Quizisen.core.moodle_xml_elements.attributes
{
    [AttributeUsage(AttributeTargets.All, Inherited = true, AllowMultiple = true)]
    class MoodleXmlElementAttribute : Attribute
    {
        private string name;
        private bool children;
        private bool attribute;
        private bool node;
        private bool content;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public bool Children
        {
            get { return children; }
            set { children = value; }
        }

        public bool Attr
        {
            get { return attribute; }
            set { attribute = value; }
        }

        public bool Node
        {
            get { return node; }
            set { node = value; }
        }

        public bool Content
        {
            get { return content; }
            set { content = value; }
        }

        public static MoodleXmlElementAttribute get(Type type)
        {
            MoodleXmlElementAttribute[] attrs = (MoodleXmlElementAttribute[])Attribute.GetCustomAttributes(type, typeof(MoodleXmlElementAttribute));
            return attrs.First();
        }

        public static MoodleXmlElementAttribute get(PropertyInfo property)
        {
            return (MoodleXmlElementAttribute)property.GetCustomAttribute(typeof(MoodleXmlElementAttribute));
        }
    }
}
