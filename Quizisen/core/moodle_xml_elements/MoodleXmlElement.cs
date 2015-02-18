using HtmlAgilityPack;
using Quizisen.core.moodle_xml_elements.attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Quizisen.core.moodle_xml_elements
{
    abstract class MoodleXmlElement
    {
        private HtmlNode htmlNode;
        private XmlElement xmlElement;
        private XmlDocument doc;

        public HtmlNode HtmlNode
        {
            get { return htmlNode; }
            set { htmlNode = value; }
        }

        public abstract void prepareData();

        public virtual XmlElement toXml(XmlDocument doc)
        {
            this.doc = doc;
            this.prepareData();

            Type thisType = this.GetType();

            string thisElementNodeName = MoodleXmlElementAttribute.get(thisType).Name.ToLower();
            this.xmlElement = doc.CreateElement(thisElementNodeName);
            PropertyInfo[] thisProperties = thisType.GetProperties();

            foreach (PropertyInfo thisProperty in thisProperties)
            {
                if (Attribute.IsDefined(thisProperty, typeof(MoodleXmlElementAttribute)))
                {
                    MoodleXmlElementAttribute thisPropertyAttribute = MoodleXmlElementAttribute.get(thisProperty);
                    this.reactToAttribute(thisPropertyAttribute, thisProperty);
                }
            }
            return this.xmlElement;
        }

        private void reactToAttribute(MoodleXmlElementAttribute attribute, PropertyInfo property)
        {
            if (attribute.Attr)
            {
                this.xmlElement.SetAttribute(property.Name.ToLower(), property.GetValue(this).ToString());
            }

            if (attribute.Children)
            {
                List<MoodleXmlElement> children = (List<MoodleXmlElement>)property.GetValue(this);
                foreach (MoodleXmlElement child in children)
                {
                    this.xmlElement.AppendChild(child.toXml(this.doc));
                }
            }

            if (attribute.Node)
            {
                MoodleXmlElement childNode = (MoodleXmlElement)property.GetValue(this);
                this.xmlElement.AppendChild(childNode.toXml(this.doc));
            }

            if (attribute.Content)
            {
                Text textElement = (Text)this;
                XmlCDataSection cdata = this.doc.CreateCDataSection(textElement.Content);

                this.xmlElement.AppendChild(cdata);
            }
        }
    }
}
