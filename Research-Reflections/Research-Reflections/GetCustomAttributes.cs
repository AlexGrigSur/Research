using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Research_Reflections.Classes;

namespace Research_Reflections
{
    // https://www.codeproject.com/Questions/5246576/Get-custom-attribute-value-using-extension-method
    // https://edn.embarcadero.com/article/30250 - current attempt
    class GetCustomAttributes
    {
        static public string? GetAttribute(object value) // class object
        {
            Type type = value.GetType();
            var attributesList = type.GetCustomAttributes(true);

            if (attributesList.Length == 0)
                return null;

            Console.WriteLine(attributesList[0]); // has single value with right attribute

            var descAttribute = attributesList[0] as DescriptionAttribute; // always null, wrong cast

            if (descAttribute != null)
            {
                Console.WriteLine(descAttribute);
                return descAttribute.ToString();
            }
            return null;

        } /* ???  descAttribute?Console.WriteLine(descAttribute.Description);*/
    }
}
