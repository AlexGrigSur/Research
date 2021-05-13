using System;
using System.Collections.Generic;
using Research_Reflections.Attributes;

namespace Research_Reflections
{
    // https://www.youtube.com/watch?v=i2W2wA-Udro&t=604s&ab_channel=%D0%9F%D1%80%D0%BE%D0%B3%D1%80%D0%B0%D0%BC%D0%BC%D0%B8%D1%80%D0%BE%D0%B2%D0%B0%D0%BD%D0%B8%D0%B5-%D1%8D%D1%82%D0%BE%D0%BF%D1%80%D0%BE%D1%81%D1%82%D0%BE
    class GetCustomAttributes
    {
        /// <summary>
        /// Function that return isPreferable property from isPreferableAttribute attribute
        /// </summary>
        /// <param name="classToScan">object that may contain specified attribute</param>
        /// <returns>null if object doesn't contain isPreferableAttribute attribute, else - bool isPreferable property</returns>
        static public bool? GetAttribute/*<T>*/(object classToScan)/* where T : Attribute*/// class object
        {
            Console.WriteLine("********************************");
            Console.WriteLine("GetAttribute");
            Dictionary<string, string> attributesValues = new Dictionary<string, string>();

            Type type = classToScan.GetType();
            var attributeList = type.GetCustomAttributes(typeof(/*T*/IsPreferableAttribute), false);

            foreach (var item in attributeList)
            {
                var attribute = (IsPreferableAttribute/*<T>*/)item;

                if (attribute != null)
                {
                    Console.WriteLine(attribute.isPreferableProperty);
                    return attribute.isPreferableProperty;
                }
            }
            return null;
        }

} /* ???  descAttribute?Console.WriteLine(descAttribute.Description);*/
}
