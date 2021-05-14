using System;

namespace Research_Reflections.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class IsPreferableAttribute : Attribute
    {
        public bool IsPreferableProperty { get; private set; }

        public IsPreferableAttribute(bool isPreferable)
        {
            IsPreferableProperty = isPreferable;
        }
    }
}
