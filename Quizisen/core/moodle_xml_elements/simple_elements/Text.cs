using HtmlAgilityPack;
using Quizisen.core.moodle_xml_elements.attributes;
using System;
using System.Collections.Generic;
using System.IO;
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
                HtmlNode nodeClone = this.HtmlNode.CloneNode(true);
                this.changeImgSrc(nodeClone);
                this.Content = nodeClone.InnerHtml;
            }

            base.prepareData();
        }

        public void changeImgSrc(HtmlNode node)
        {
            var images = node.Descendants("img");
            foreach (HtmlNode img in images)
            {
                img.Attributes["src"].Value = @"@@PLUGINFILE@@/" + Path.GetFileName(img.Attributes["src"].Value);
            }
        }
    }
}
