using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Quizisen.core.moodle_xml_elements.attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    class RelationAttribute : Attribute
    {
        private Type to;
        private String parentPropertyName;

        public String ParentPropertyName
        {
            get { return parentPropertyName; }
            set { parentPropertyName = value; }
        }

        public Type To
        {
            get { return to; }
            set { to = value; }
        }

        public static RelationAttribute get(Type type)
        {
            return (RelationAttribute)Attribute.GetCustomAttribute(type, typeof(RelationAttribute)); ;
        }

    }
}
