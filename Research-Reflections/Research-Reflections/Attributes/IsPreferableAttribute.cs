using System;

namespace Research_Reflections.Attributes
{
    class IsPreferableAttribute : Attribute
    {
        public bool isPreferableProperty { get; private set; }

        public IsPreferableAttribute(bool _isPreferable) =>
            isPreferableProperty = _isPreferable;
    }
}
