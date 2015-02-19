using Quizisen.core.moodle_xml_elements.attributes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Quizisen.core.moodle_xml_elements
{
    [MoodleXmlElementAttribute(Name = "file")]
    class FileElement : MoodleXmlElement
    {
        private string content = "";
        private string name = "";
        private string path = "/";
        private string encoding = "base64";

        [MoodleXmlElementAttribute(Attr = true)]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [MoodleXmlElementAttribute(Attr = true)]
        public string Path
        {
            get { return path; }
            set { path = value; }
        }

        [MoodleXmlElementAttribute(Attr = true)]
        public string Encoding
        {
            get { return encoding; }
            set { encoding = value; }
        }

        public string Content
        {
            get { return content; }
            set { content = value; }
        }

        public override void prepareData()
        {
            string folder = System.IO.Path.GetDirectoryName(Parser.Path);
            string path = folder + System.IO.Path.DirectorySeparatorChar + this.HtmlNode.Attributes["src"].Value;
            this.Content = FileToBase64(path);
            this.name = System.IO.Path.GetFileName(path);

            this.HtmlNode.Attributes["src"].Value = @"@@PLUGINFILE@@/" + this.name;
        }

        public override XmlElement toXml(XmlDocument doc)
        {
            XmlElement result = base.toXml(doc);
            result.InnerText = this.Content;
            return result;
        }

        private string FileToBase64(string path)
        {
            byte[] bytes = File.ReadAllBytes(path);
            string base64String = Convert.ToBase64String(bytes);
            return base64String;
        }
    }
}
