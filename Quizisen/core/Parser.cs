using HtmlAgilityPack;
using Microsoft.Office.Interop.Word;
using Quizisen.core.moodle_xml_elements;
using Quizisen.core.moodle_xml_elements.attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Quizisen.core
{
    class Parser
    {
        private Document doc;
        private HtmlDocument html = new HtmlDocument();
        private Stack<MoodleXmlElement> moodleXmlElementsStack = new Stack<MoodleXmlElement>();
        private static string path;

        public static string Path
        {
            get { return path; }
            set { path = value; }
        }

        public Parser(Document doc)
        {
            this.doc = doc;
        }

        public void parse()
        {
            Path = this.saveDocumentAsHtml(this.doc);
            this.html.Load(path);

            Quiz quiz = new Quiz();
            this.moodleXmlElementsStack.Push(quiz);
            this.populateQuizByHtml();

            XmlDocument moodleXmlOut = new XmlDocument();
            moodleXmlOut.AppendChild(quiz.toXml(moodleXmlOut));
            moodleXmlOut.Save(@"D:\C#\quizisen\Quizisen\bin\Debug\out.xml");
        }

        private void populateQuizByHtml()
        {
            HtmlNodeCollection nodes = this.html.DocumentNode.SelectNodes("//div/p");

            foreach (HtmlNode node in nodes)
            {
                MoodleXmlElement currentMoodleXmlElement = Factory.get(node);

                if (currentMoodleXmlElement != null)
                {
                    currentMoodleXmlElement.HtmlNode = node;
                    Type currentMoodleXmlElementType = currentMoodleXmlElement.GetType();

                    RelationAttribute ralatedTo = RelationAttribute.get(currentMoodleXmlElementType);
                    if (ralatedTo != null)
                    {
                        this.notifyFirstRelatedElement(currentMoodleXmlElement, ralatedTo);
                    }

                    this.moodleXmlElementsStack.Push(currentMoodleXmlElement);
                }
            }
        }

        private void notifyFirstRelatedElement(MoodleXmlElement child, RelationAttribute relatedTo)
        {
            foreach (MoodleXmlElement parentElement in this.moodleXmlElementsStack)
            {
                Type parentType = parentElement.GetType();

                if (parentType.Equals(relatedTo.To) || parentType.IsSubclassOf(relatedTo.To))
                {
                    bool found = this.notifyRelatedElementProperties(parentType, parentElement, child);
                    if (found)
                    {
                        break;
                    }
                }
            }
        }

        private bool notifyRelatedElementProperties(Type parentType, MoodleXmlElement parentElement, MoodleXmlElement child)
        {
            PropertyInfo[] properties = parentType.GetProperties();
            bool found = false;

            foreach (PropertyInfo property in properties)
            {
                MoodleXmlElementAttribute xmlAttributes = MoodleXmlElementAttribute.get(property);

                if (xmlAttributes != null && xmlAttributes.Children == true)
                {
                    List<MoodleXmlElement> includedElements = (List<MoodleXmlElement>)property.GetValue(parentElement);
                    includedElements.Add(child);
                    found = true;
                    break;
                }
            }

            return found;
        }

        private string saveDocumentAsHtml(Document doc)
        {
            string tempRoot = System.IO.Path.GetTempPath();
            Path = tempRoot + @"\" + doc.Name + ".htm";
            object oMissing = System.Reflection.Missing.Value;

            WdSaveFormat format = WdSaveFormat.wdFormatFilteredHTML;

            Application wordApp = new Microsoft.Office.Interop.Word.Application();
            Document tempDoc = wordApp.Documents.Add();

            tempDoc.Range().InsertXML(doc.WordOpenXML);

            this.removeStyleColors(tempDoc);
            tempDoc.SaveAs(path,
              format, ref oMissing, ref oMissing,
              ref oMissing, ref oMissing, ref oMissing, ref oMissing,
              ref oMissing, ref oMissing, ref oMissing, ref oMissing,
              ref oMissing, ref oMissing, ref oMissing, ref oMissing);

            (tempDoc as _Document).Close(false);
            (wordApp as _Application).Quit(false);
            tempDoc = null;
            wordApp = null;

            return path;
        }

        private void removeStyleColors(Document doc)
        {
            foreach (Style style in doc.Styles)
            {
                style.Font.TextColor.RGB = 0x000000;
            }
        }
    }
}
