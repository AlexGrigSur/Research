using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Research_Reflections.Attributes
{
    class IsPreferableAttribute : Attribute
    {
        public bool isPreferableProperty { get; private set; }

        public IsPreferableAttribute()
        { }

        public IsPreferableAttribute(bool _isPreferable) =>
            isPreferableProperty = _isPreferable;
    }
}
